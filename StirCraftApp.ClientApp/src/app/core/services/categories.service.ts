import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  categories: string[] = [];

  getCategories() {
    if (this.categories.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'categories')
    .subscribe({
      next: response => this.categories = response
    });
  }
}
