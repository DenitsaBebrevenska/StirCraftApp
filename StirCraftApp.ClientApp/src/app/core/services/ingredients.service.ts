import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IngredientParams } from '../../shared/models/ingredient/ingredientParams';
import { Pagination } from '../../shared/models/pagination';
import { IngredientDetailed } from '../../shared/models/ingredient/ingredientDetailed';
import { IngredientCreateForm } from '../../shared/models/ingredient/ingredientCreateForm';
import { IngredientShort } from '../../shared/models/ingredient/ingredientShort';
import { IngredientSuggest } from '../../shared/models/ingredient/ingredientSuggest';
import { IngredientAdminParams } from '../../shared/models/ingredient/igredientAdminParams';
import { IngredientAdminShort } from '../../shared/models/ingredient/ingredientAdminShort';


@Injectable({
  providedIn: 'root'
})
export class IngredientsService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  searchName: string = '';

  getIngredients(ingredientParams: IngredientParams) {
    let params = new HttpParams();

    if (ingredientParams.searchName) {
      params = params.append('ingredientName', ingredientParams.searchName);
    }

    if (ingredientParams.isAllergen) {
      params = params.append('isAllergen', ingredientParams.isAllergen.toString());
    }

    params = params.append('pageIndex', ingredientParams.pageIndex);
    params = params.append('pageSize', ingredientParams.pageSize);

    return this.http.get<Pagination<IngredientShort>>(this.baseUrl + 'ingredients', { params });
  }

  getAdminIngredients(ingredientAdminParams: IngredientAdminParams) {
    let params = new HttpParams();

    if (ingredientAdminParams.searchName) {
      params = params.append('ingredientName', ingredientAdminParams.searchName);
    }

    if (ingredientAdminParams.isAdminApproved) {
      params = params.append('isAdminApproved', ingredientAdminParams.isAdminApproved.toString());
    }

    params = params.append('pageIndex', ingredientAdminParams.pageIndex);
    params = params.append('pageSize', ingredientAdminParams.pageSize);

    return this.http.get<Pagination<IngredientAdminShort>>(this.baseUrl + 'admin/ingredients', { params });
  }

  getAllNonPagedIngredients() {
    return this.http.get<IngredientShort[]>(this.baseUrl + 'ingredients/all');
  }

  getIngredient(id: number) {
    return this.http.get<IngredientDetailed>(this.baseUrl + 'admin/ingredients/' + id);
  }

  createIngredient(ingredient: IngredientCreateForm) {
    return this.http.post(this.baseUrl + 'admin/ingredients/create', ingredient);
  }

  suggestIngredient(ingredient: IngredientSuggest) {
    return this.http.post(this.baseUrl + 'ingredients/suggest', ingredient);
  }

  updateIngredient(id: number, ingredient: IngredientDetailed) {
    return this.http.put(this.baseUrl + 'admin/ingredients/' + id, ingredient);
  }

  deleteIngredient(id: number) {
    return this.http.delete(this.baseUrl + 'admin/ingredients/' + id);
  }
}
