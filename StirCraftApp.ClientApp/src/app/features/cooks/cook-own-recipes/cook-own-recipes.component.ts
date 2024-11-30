import { Component, inject, OnInit } from '@angular/core';
import { RecipeParams } from '../../../shared/models/recipe/recipeParams';
import { RecipesService } from '../../../core/services/recipes.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Pagination } from '../../../shared/models/pagination';
import { RecipeCook } from '../../../shared/models/recipe/recipeCook';
import { CookService } from '../../../core/services/cook.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatCard, MatCardContent, MatCardHeader } from '@angular/material/card';
import { RecipeShort } from '../../../shared/models/recipe/recipeShort';
import { RecipeOwn } from '../../../shared/models/recipe/recipeOwn';
import { PagingParams } from '../../../shared/models/pagingParams';

@Component({
  selector: 'app-cook-own-recipes',
  standalone: true,
  imports: [
    MatCard,
    MatPaginator,
    MatCardHeader,
    MatCardContent,
    RouterLink
  ],
  templateUrl: './cook-own-recipes.component.html',
  styleUrl: './cook-own-recipes.component.scss'
})
export class CookOwnRecipesComponent implements OnInit {
  pagingParams = new PagingParams();
  pageSizeOptions = [5, 10, 20];
  
  ngOnInit(): void {
    this.getRecipesCook();
  }

  private cookService = inject(CookService);
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
}

