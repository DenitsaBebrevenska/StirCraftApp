import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  baseUrl = 'https://localhost:7222/api/';
  private http = inject(HttpClient)
  title = 'StirCraftClientApp';

  ngOnInit(): void {
    this.http.get(this.baseUrl + 'recipes')
      .subscribe({
        next: data => console.log(data),
        error: error => console.error(error),
        complete: () => console.log('complete') 
      });
  }
}
