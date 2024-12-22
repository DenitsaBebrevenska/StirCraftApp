import { Component, inject, Input } from '@angular/core';
import { BriefRecipe } from '../../models/briefRecipe';
import { MatIcon } from '@angular/material/icon';
import { Router, RouterLink } from '@angular/router';

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
  private router = inject(Router);
  currentSlide = 0;

  nextSlide() {

    if (this.currentSlide === this.carouselRecipes.length - 1) {
      this.currentSlide = 0;
    } else {
      this.currentSlide++;
    }
  }

  previousSlide() {
    if (this.currentSlide === 0) {
      this.currentSlide = this.carouselRecipes.length - 1;
    } else {
      this.currentSlide--;
    }

  }

  navigateToRecipe(id: number) {
    this.router.navigate(['/recipes', id]);
  }
}
