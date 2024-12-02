import { Component, Input } from '@angular/core';
import { CarouselRecipe } from '../../models/carouselRecipe';
import { MatIcon } from '@angular/material/icon';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-carousel',
  standalone: true,
  imports: [
    MatIcon,
    RouterLink
  ],
  templateUrl: './carousel.component.html',
  styleUrl: './carousel.component.scss'
})

export class CarouselComponent {
  @Input() carouselRecipes: CarouselRecipe[] = [];

  currentSlide = 1;

  nextSlide() {
    if (this.currentSlide === this.carouselRecipes.length) {
      this.currentSlide = 1;
    } else {
      this.currentSlide++;
    }
  }

  previousSlide() {
    if (this.currentSlide === 1) {
      this.currentSlide = this.carouselRecipes.length;
    } else {
      this.currentSlide--;
    }

  }
}
