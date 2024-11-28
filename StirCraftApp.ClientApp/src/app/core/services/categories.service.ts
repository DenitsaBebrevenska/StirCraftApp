import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Category } from '../../shared/models/recipe/category';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  categories: string[] = [];

  getCategoriesNames() {
    if (this.categories.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'categories/names')
    .subscribe({
      next: response => this.categories = response
    });
  }

  getCategories(){
    return this.http.get<Category[]>(this.baseUrl + 'categories');
  }
}
