import { Component, Input } from '@angular/core';
import { BriefRecipe } from '../../models/briefRecipe';
import { MatIcon } from '@angular/material/icon';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-carousel',
  standalone: true,
  imports: [
    MatIcon
  ],
  templateUrl: './carousel.component.html',
  styleUrl: './carousel.component.scss'
})

export class CarouselComponent {
  @Input() carouselRecipes: BriefRecipe[] = [];

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
