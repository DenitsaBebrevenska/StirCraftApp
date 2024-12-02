import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../core/services/recipes.service';
import { CarouselRecipe } from '../../shared/models/carouselRecipe';
import { CarouselComponent } from "../../shared/components/carousel/carousel.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CarouselComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  private RecipesService = inject(RecipesService);
  carouselRecipes: CarouselRecipe[] = [];
  count = 5;

  ngOnInit() {
    this.topRecipes();
  }

  topRecipes() {
    this.RecipesService.getTopNRecipes(this.count).subscribe({
      next: response => this.carouselRecipes = response,
      error: err => console.log(err)
    });
  }

}
