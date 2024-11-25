import { Component, inject, OnInit } from '@angular/core';
import { MatCard, MatCardContent, MatCardHeader } from '@angular/material/card';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { RecipesService } from '../../core/services/recipes.service';
import { CookieService } from 'ngx-cookie-service';
import { RecipeParams } from '../../shared/models/recipe/recipeParams';
import { Pagination } from '../../shared/models/pagination';
import { RecipeCook } from '../../shared/models/recipe/recipeCook';
import { RecipeOwn } from '../../shared/models/recipe/recipeOwn';

@Component({
  selector: 'app-cook-panel',
  standalone: true,
  imports: [
    MatPaginator,
    MatCard,
    RouterLink,
    MatCardHeader,
    MatCardContent
  ],
  templateUrl: './cook-panel.component.html',
  styleUrl: './cook-panel.component.scss'
})
export class CookPanelComponent implements OnInit{
  private recipesService = inject(RecipesService);
  private activatedRoute = inject(ActivatedRoute);
  pageSizeOptions = [5, 10, 20];
  recipeParams = new RecipeParams();
  recipes?: Pagination<RecipeOwn>;

  ngOnInit(): void {
    this.loadCookRecipes();
  }


  loadCookRecipes() {
    this.recipesService.getOwnRecipes()
      .subscribe({
        next: response => this.recipes = response,
        error: error => console.error(error)
      });
  }

  
  handlePage(event: PageEvent) {
    this.recipeParams.pageIndex = event.pageIndex + 1;
    this.recipeParams.pageSize = event.pageSize;
    this.loadCookRecipes();
  }

  createRecipe() {
    // Logic to navigate to recipe creation form
    console.log('Create Recipe button clicked!');
  }
  
  editRecipe(recipeId: number) {
    // Logic to navigate to the edit page for the selected recipe
    console.log(`Edit Recipe with ID: ${recipeId}`);
  }
  
  deleteRecipe(recipeId: number) {
    // Logic to delete the selected recipe
    console.log(`Delete Recipe with ID: ${recipeId}`);
  }
}
