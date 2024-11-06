import { HttpClient, HttpParams } from '@angular/common/http';
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

  getRecipes(categories?: string[], difficultyLevels?: string[], sort?: string) {
    let params = new HttpParams();

    if(categories && categories.length > 0) {
      params = params.append('categories', categories.join(','));
    }

    if(difficultyLevels && difficultyLevels.length > 0) {
      params = params.append('difficultyLevels', difficultyLevels.join(','));
    }

    if(sort) {
      params = params.append('sort', sort);
    }

    return this.http.get<Pagination<RecipeShort>>(this.baseUrl + 'recipes', { params });
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
