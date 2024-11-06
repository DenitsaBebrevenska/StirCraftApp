import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { RecipeShort } from '../../shared/models/recipeShort';
import { RecipeDetailed } from '../../shared/models/recipeDetailed';

@Injectable({
  providedIn: 'root'
})

export class RecipesService {
  baseUrl = 'https://localhost:7222/api/';
  private http = inject(HttpClient);
  difficultyLevels: string[] = [];

  getRecipes() {
    return this.http.get<Pagination<RecipeShort>>(this.baseUrl + 'recipes');
  }

  getRecipe(id: number) {
    return this.http.get<RecipeDetailed>(this.baseUrl + 'recipes/' + id);
  }

  getDifficultyLevels() {
    if (this.difficultyLevels.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'recipes/difficultyLevels')
    .subscribe({
      next: response => this.difficultyLevels = response
    });
  }
}
