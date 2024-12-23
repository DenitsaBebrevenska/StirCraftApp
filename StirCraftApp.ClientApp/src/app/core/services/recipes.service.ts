import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { RecipeShort } from '../../shared/models/recipe/recipeShort';
import { RecipeDetailed } from '../../shared/models/recipe/recipeDetailed';
import { RecipeParams } from '../../shared/models/recipe/recipeParams';
import { environment } from '../../../environments/environment.development';
import { RecipeCook } from '../../shared/models/recipe/recipeCook';
import { BriefRecipe } from '../../shared/models/briefRecipe';
import { RecipeOwn } from '../../shared/models/recipe/recipeOwn';
import { RecipeCreateForm } from '../../shared/models/recipe/recipeCreateForm';
import { PagingParams } from '../../shared/models/pagingParams';
import { CommentForm } from '../../shared/models/recipe/commentForm';
import { EditComment } from '../../shared/models/recipe/editComment';
import { ToggleFavoriteRecipe } from '../../shared/models/recipe/toggleFavoriteRecipe';
import { RecipeOwnDetailed } from '../../shared/models/recipe/recipeOwnDetailed';
import { RecipeAdminNotes } from '../../shared/models/recipe/recipeAdminNotes';

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

    if (recipeParams.categories.length > 0) {
      params = params.append('categories', recipeParams.categories.join(','));
    }

    if (recipeParams.difficultyLevels.length > 0) {
      params = params.append('difficultyLevels', recipeParams.difficultyLevels.join(','));
    }

    if (recipeParams.sort) {
      params = params.append('sort', recipeParams.sort);
    }

    if (recipeParams.searchName) {
      params = params.append('recipeName', recipeParams.searchName);
    }

    if (recipeParams.ingredientId) {
      params = params.append('ingredientId', recipeParams.ingredientId);
    }

    params = params.append('pageIndex', recipeParams.pageIndex);
    params = params.append('pageSize', recipeParams.pageSize);

    return this.http.get<Pagination<RecipeShort>>(this.baseUrl + 'recipes', { params });
  }

  getRecipe(id: number) {
    return this.http.get<RecipeDetailed>(this.baseUrl + 'recipes/' + id);
  }

  getCookRecipes(id: number, pagingParams: PagingParams) {
    let params = new HttpParams();
    params = params.append('pageIndex', pagingParams.pageIndex);
    params = params.append('pageSize', pagingParams.pageSize);
    return this.http.get<Pagination<RecipeCook>>(this.baseUrl + 'recipes/cook/' + id, { params });
  }

  getIngredientRecipes(id: number) {
    return this.http.get<Pagination<RecipeShort>>(this.baseUrl + 'recipes/ingredient/' + id);
  }

  getTopNRecipes(count: number) {
    return this.http.get<BriefRecipe[]>(this.baseUrl + 'recipes/top/' + count);
  }

  createRecipe(recipe: RecipeCreateForm) {
    return this.http.post(this.baseUrl + 'recipes', recipe);
  }

  updateRecipe(id: number, recipe: RecipeCreateForm) {
    return this.http.put(this.baseUrl + 'recipes/' + id, recipe);
  }

  deleteRecipe(id: number) {
    return this.http.delete(this.baseUrl + 'recipes/' + id);
  }

  getDifficultyLevels() {
    return this.http.get<string[]>(this.baseUrl + 'recipes/difficultyLevels');
  }

  getDifficultyLevelsNames() {
    if (this.difficultyLevels.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'recipes/difficultyLevels')
      .subscribe({
        next: response => this.difficultyLevels = response
      });
  }

  toggleFavorite(recipeId: number) {
    return this.http.post<ToggleFavoriteRecipe>(this.baseUrl + 'recipes/' + recipeId + '/toggle-favorite', null);
  }

  rateRecipe(recipeId: number, rating: number) {
    return this.http.post<number>(this.baseUrl + 'recipes/' + recipeId + '/rate/' + rating, null);
  }

  getUserFavoriteRecipes(pagingParams: PagingParams) {
    let params = new HttpParams();
    params = params.append('pageIndex', pagingParams.pageIndex);
    params = params.append('pageSize', pagingParams.pageSize);
    return this.http.get<Pagination<BriefRecipe>>(this.baseUrl + 'recipes/user-favorites', { params });
  }

  getRecipesPendingApproval(pagingParams: PagingParams) {
    let params = new HttpParams();
    params = params.append('pageIndex', pagingParams.pageIndex);
    params = params.append('pageSize', pagingParams.pageSize);
    return this.http.get<Pagination<BriefRecipe>>(this.baseUrl + 'admin/recipes/pending-approval', { params });
  }

  getRecipePendingApprovalById(id: number) {
    return this.http.get<RecipeOwnDetailed>(this.baseUrl + 'admin/recipes/pending-approval/' + id);
  }

  approveRecipe(id: number) {
    return this.http.post(this.baseUrl + 'admin/recipes/pending-approval/' + id + '/approve', null);
  }

  updateAdminNotes(id: number, adminNotes: RecipeAdminNotes) {
    return this.http.put(this.baseUrl + 'admin/recipes/pending-approval/' + id + '/notes', adminNotes);
  }

}
