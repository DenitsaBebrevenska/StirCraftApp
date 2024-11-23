import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IngredientParams } from '../../shared/models/ingredientParams';
import { Pagination } from '../../shared/models/pagination';
import { IngredientDetailed } from '../../shared/models/ingredientDetailed';
import { IngredientCreateForm } from '../../shared/models/ingredientCreateForm';
import { IngredientShort } from '../../shared/models/ingredientShort';
import { IngredientSuggest } from '../../shared/models/ingredientSuggest';


@Injectable({
  providedIn: 'root'
})
export class IngredientsService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  searchName: string = '';

  getIngredients(ingredientParams: IngredientParams) {
    let params = new HttpParams();

    if(ingredientParams.searchName) {
      params = params.append('ingredientName', ingredientParams.searchName);
    }

    if(ingredientParams.isAllergen){
      params = params.append('isAllergen', ingredientParams.isAllergen.toString());
    }

    params = params.append('pageIndex', ingredientParams.pageIndex);
    params = params.append('pageSize', ingredientParams.pageSize);

    return this.http.get<Pagination<IngredientShort>>(this.baseUrl + 'ingredients', { params });
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
}
