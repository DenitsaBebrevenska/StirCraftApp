import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IngredientParams } from '../../shared/models/ingredientParams';
import { Pagination } from '../../shared/models/pagination';
import { Ingredient } from '../../shared/models/ingredientDetailed';

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

    return this.http.get<Pagination<Ingredient>>(this.baseUrl + 'ingredients', { params });
  }

  getIngredient(id: number) {
    return this.http.get<Ingredient>(this.baseUrl + 'ingredients/' + id);
  }
}
