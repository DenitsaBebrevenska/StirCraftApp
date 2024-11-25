import { HttpClient } from '@angular/common/http';
import { inject, Injectable, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class CookService implements OnInit{
  ngOnInit(): void {
   
  }
  
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

}
