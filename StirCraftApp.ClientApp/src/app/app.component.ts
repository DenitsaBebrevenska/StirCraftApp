import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { Recipe } from './shared/models/recipe';
import { RecipesService } from './core/services/recipes.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent implements OnInit {
  private recipeService = inject(RecipesService);
  title = 'StirCraftClientApp';
  recipes: Recipe[] = [];

  ngOnInit(): void {
    this.recipeService.getRecipes()
      .subscribe({
        next: response => this.recipes = response.data,
        error: error => console.error(error)
      });
  }
}
