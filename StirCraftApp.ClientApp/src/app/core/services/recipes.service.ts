import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { RecipeShort } from '../../shared/models/recipe/recipeShort';
import { RecipeDetailed } from '../../shared/models/recipe/recipeDetailed';
import { RecipeParams } from '../../shared/models/recipe/recipeParams';
import { environment } from '../../../environments/environment.development';
import { RecipeCook } from '../../shared/models/recipe/recipeCook';
import { CarouselRecipe } from '../../shared/models/carouselRecipe';
import { RecipeOwn } from '../../shared/models/recipe/recipeOwn';
import { RecipeCreateForm } from '../../shared/models/recipe/recipeCreateForm';

@Injectable({
  providedIn: 'root'
})

export class RecipesService {
  baseUrl = environment.apiUrl;
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

    if(recipeParams.ingredientId){
      params = params.append('ingredientId', recipeParams.ingredientId);
    }

    params = params.append('pageIndex', recipeParams.pageIndex);
    params = params.append('pageSize', recipeParams.pageSize);

    return this.http.get<Pagination<RecipeShort>>(this.baseUrl + 'recipes', { params });
  }

  getRecipe(id: number) {
    return this.http.get<RecipeDetailed>(this.baseUrl + 'recipes/' + id);
  }

  getCookRecipes(id: number){
    return this.http.get<Pagination<RecipeCook>>(this.baseUrl + 'recipes/cook/' + id);
  }

  getOwnRecipes(){
    return this.http.get<Pagination<RecipeOwn>>(this.baseUrl + 'recipes/own/');
  }

  getIngredientRecipes(id: number){
    return this.http.get<Pagination<RecipeShort>>(this.baseUrl + 'recipes/ingredient/' + id);
  }

  getTopNRecipes(count: number) {
    return this.http.get<CarouselRecipe[]>(this.baseUrl + 'recipes/top/' + count);
  }

  createRecipe(recipe: RecipeCreateForm) {
    return this.http.post(this.baseUrl + 'recipes', recipe);
  }

  getDifficultyLevels(){
    return this.http.get<string[]>(this.baseUrl + 'recipes/difficultyLevels');
  }

  getDifficultyLevelsNames() {
    if (this.difficultyLevels.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'recipes/difficultyLevels')
    .subscribe({
      next: response => this.difficultyLevels = response
    });
  }

}
