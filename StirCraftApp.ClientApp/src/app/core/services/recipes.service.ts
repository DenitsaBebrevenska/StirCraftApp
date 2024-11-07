import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { RecipeShort } from '../../shared/models/recipeShort';
import { RecipeDetailed } from '../../shared/models/recipeDetailed';
import { RecipeParams } from '../../shared/models/recipeParams';

@Injectable({
  providedIn: 'root'
})

export class RecipesService {
  baseUrl = 'https://localhost:7222/api/';
  private http = inject(HttpClient);
  difficultyLevels: string[] = [];
  searchName: string = '';

  getRecipes(recipeParams: RecipeParams) {
    let params = new HttpParams();

    if(recipeParams.categories.length > 0) {
      params = params.append('categories', recipeParams.categories.join(','));
    }

    if(recipeParams.difficultyLevels.length > 0) {
      params = params.append('difficultyLevels', recipeParams.difficultyLevels.join(','));
    }

    if(recipeParams.sort) {
      params = params.append('sort', recipeParams.sort);
    }

    if(recipeParams.searchName) {
      params = params.append('recipeName', recipeParams.searchName);
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
