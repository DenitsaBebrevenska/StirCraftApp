import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { Recipe } from '../../shared/models/recipe';

@Injectable({
  providedIn: 'root'
})

export class RecipesService {
  baseUrl = 'https://localhost:7222/api/';
  private http = inject(HttpClient);
  
  getRecipes() {
    return this.http.get<Pagination<Recipe>>(this.baseUrl + 'recipes');
  }
}
