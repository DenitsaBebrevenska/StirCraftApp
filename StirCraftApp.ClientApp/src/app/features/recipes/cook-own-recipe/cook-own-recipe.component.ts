import { Component, inject } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { ActivatedRoute } from '@angular/router';
import { RecipeDetailed } from '../../../shared/models/recipe/recipeDetailed';
import { CookService } from '../../../core/services/cook.service';
import { RecipeOwnDetailed } from '../../../shared/models/recipe/recipeOwnDetailed';

@Component({
  selector: 'app-cook-own-recipe',
  standalone: true,
  imports: [],
  templateUrl: './cook-own-recipe.component.html',
  styleUrl: './cook-own-recipe.component.scss'
})
export class CookOwnRecipeComponent {
  private cookService = inject(CookService);
  private activatedRoute = inject(ActivatedRoute);
  recipe?: RecipeOwnDetailed;

  ngOnInit(): void {
    this.loadRecipe();
  }

  loadRecipe() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.cookService.getCookOwnRecipe(+id).subscribe(
      {
        next: response => this.recipe = response,
        error: err => console.error(err)
      }
    );
  }
}
