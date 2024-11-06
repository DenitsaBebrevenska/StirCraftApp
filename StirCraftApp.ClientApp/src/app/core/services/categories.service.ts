import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  baseUrl = 'https://localhost:7222/api/';
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
