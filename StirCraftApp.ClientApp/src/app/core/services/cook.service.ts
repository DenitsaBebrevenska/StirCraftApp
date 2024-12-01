import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Pagination } from '../../shared/models/pagination';
import { RecipeShort } from '../../shared/models/recipe/recipeShort';
import { RecipeParams } from '../../shared/models/recipe/recipeParams';
import { RecipeOwn } from '../../shared/models/recipe/recipeOwn';
import { PagingParams } from '../../shared/models/pagingParams';
import { RecipeOwnDetailed } from '../../shared/models/recipe/recipeOwnDetailed';


@Injectable({
  providedIn: 'root'
})
export class CookService implements OnInit{
  ngOnInit(): void {
   
  }
  
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getCookOwnRecipes(pagingParams: PagingParams){
    let params = new HttpParams();
    params = params.append('pageIndex', pagingParams.pageIndex);
    params = params.append('pageSize', pagingParams.pageSize);

    return this.http.get<Pagination<RecipeOwn>>(this.baseUrl + 'cook/recipes', {params});
  }

  getCookOwnRecipe(id: number){
    return this.http.get<RecipeOwnDetailed>(this.baseUrl + 'cook/recipes/' + id);
  }
}