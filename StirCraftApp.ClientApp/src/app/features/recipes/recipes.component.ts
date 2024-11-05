import { Component, inject, OnInit} from '@angular/core';
import { RecipesService } from '../../core/services/recipes.service';
import { RecipeShort } from '../../shared/models/recipeShort';
import { RecipeItemComponent } from "./recipe-item/recipe-item.component";

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
  private recipeService = inject(RecipesService);
  recipes: RecipeShort[] = [];
  
  ngOnInit(): void {
    this.recipeService.getRecipes()
      .subscribe({
        next: response => this.recipes = response.data,
        error: error => console.error(error)
      });
  }
}
