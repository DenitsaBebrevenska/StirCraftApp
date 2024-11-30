import { Component, inject, OnInit } from '@angular/core';
import { RecipeParams } from '../../../shared/models/recipe/recipeParams';
import { RecipesService } from '../../../core/services/recipes.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Pagination } from '../../../shared/models/pagination';
import { RecipeCook } from '../../../shared/models/recipe/recipeCook';
import { CookService } from '../../../core/services/cook.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatCard, MatCardActions, MatCardContent, MatCardHeader } from '@angular/material/card';
import { RecipeShort } from '../../../shared/models/recipe/recipeShort';
import { RecipeOwn } from '../../../shared/models/recipe/recipeOwn';
import { PagingParams } from '../../../shared/models/pagingParams';
import { MatDialog } from '@angular/material/dialog';
import { CookDeleteRecipeDialogComponent } from '../cook-delete-recipe-dialog/cook-delete-recipe-dialog.component';


@Component({
  selector: 'app-cook-own-recipes',
  standalone: true,
  imports: [
    MatCard,
    MatPaginator,
    MatCardHeader,
    MatCardContent,
    MatCardActions,
    RouterLink
  ],
  templateUrl: './cook-own-recipes.component.html',
  styleUrl: './cook-own-recipes.component.scss'
})
export class CookOwnRecipesComponent implements OnInit {
  pagingParams = new PagingParams();
  pageSizeOptions = [5, 10, 20];
  id?: number;

  ngOnInit(): void {
    this.getRecipesCook();
  }

  private cookService = inject(CookService);
  private dialogService = inject(MatDialog);
  private activatedRoute = inject(ActivatedRoute);
  
  recipes?: Pagination<RecipeOwn>;

  getRecipesCook(){
  
    this.cookService.getCookOwnRecipes(this.pagingParams).subscribe(
      {
        next: response => this.recipes = response,
        error: err => console.error(err)
      }
    );
  }

  handlePage(event: PageEvent) {
    this.pagingParams.pageIndex = event.pageIndex + 1;
    this.pagingParams.pageSize = event.pageSize;
    this.getRecipesCook();
  }

  openDialog(recipeId:number, recipeName: string){ {
    this.dialogService.open(CookDeleteRecipeDialogComponent, {
       minWidth: '400px',
       data: {
         title: 'Delete recipe',
         message: `Are you sure you want to delete recipe ${recipeName}?`,
         id: recipeId
       }
     });
   }

}
}
