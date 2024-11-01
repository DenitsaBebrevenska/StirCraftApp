import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../core/services/recipes.service';
import { Recipe } from '../../shared/models/recipe';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [
    MatCardModule, 
    MatButtonModule
  ],
  templateUrl: './recipes.component.html',
  styleUrl: './recipes.component.scss'
})
export class RecipesComponent implements OnInit{
  private recipeService = inject(RecipesService);
  recipes: Recipe[] = [];
  
  ngOnInit(): void {
    this.recipeService.getRecipes()
      .subscribe({
        next: response => {
          this.recipes = response.data,
          console.log(response);
        },
        error: error => console.error(error)
      });
  }
}
