import { Component, inject, OnInit} from '@angular/core';
import { RecipesService } from '../../core/services/recipes.service';
import { RecipeShort } from '../../shared/models/recipeShort';
import { RecipeItemComponent } from "./recipe-item/recipe-item.component";
import { CategoriesService } from '../../core/services/categories.service';

@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [
    RecipeItemComponent
],
  templateUrl: './recipes.component.html',
  styleUrl: './recipes.component.scss'
})
export class RecipesComponent implements OnInit{
  private recipesService = inject(RecipesService);
  recipes: RecipeShort[] = [];
  private categoriesService = inject(CategoriesService);
  categories: string[] = [];

  ngOnInit(): void {
    this.initializeRecipes();
  }

  initializeRecipes() { 
    this.recipesService.getDifficultyLevels();
    this.categoriesService.getCategories();
    this.recipesService.getRecipes()
      .subscribe({
        next: response => this.recipes = response.data,
        error: error => console.error(error)
      });
  }
}
