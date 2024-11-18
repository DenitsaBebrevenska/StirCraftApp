import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../core/services/recipes.service';
import { CarouselRecipe } from '../../shared/models/carouselRecipe';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  private RecipesService = inject(RecipesService);
  topThreeRecipes: CarouselRecipe[] = [];

  ngOnInit() {
    this.loadTopThreeRecipes();
  }

  loadTopThreeRecipes() {
    this.RecipesService.getTopThreeRecipes().subscribe({
      next: response => this.topThreeRecipes = response,
      error: err => console.log(err)
    });
  }
}
