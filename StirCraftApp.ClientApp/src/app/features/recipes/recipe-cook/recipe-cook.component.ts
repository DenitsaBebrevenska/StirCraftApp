import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { Pagination } from '../../../shared/models/pagination';
import { RecipeCook } from '../../../shared/models/recipe/recipeCook';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { MatCard, MatCardContent, MatCardHeader } from '@angular/material/card';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { RecipeParams } from '../../../shared/models/recipe/recipeParams';
import { PagingParams } from '../../../shared/models/pagingParams';

@Component({
  selector: 'app-recipe-cook',
  standalone: true,
  imports: [
    MatCard,
    MatCardHeader,
    MatCardContent,
    RouterLink,
    MatPaginator
  ],
  templateUrl: './recipe-cook.component.html',
  styleUrl: './recipe-cook.component.scss'
})
export class RecipeCookComponent implements OnInit {
  pagingParams = new PagingParams();
  pageSizeOptions = [5, 10, 20];
  
  ngOnInit(): void {
    this.getRecipesCook();
  }

  private recipesService = inject(RecipesService);
  private activatedRoute = inject(ActivatedRoute);
  
  recipesCook?: Pagination<RecipeCook>;

  getRecipesCook(){
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.recipesService.getCookRecipes(+id, this.pagingParams).subscribe(
      {
        next: recipe => this.recipesCook = recipe,
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
