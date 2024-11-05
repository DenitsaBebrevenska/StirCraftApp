import { Component, Input } from '@angular/core';
import { Recipe } from '../../../shared/models/recipe';
import { MatCard, MatCardContent, MatCardHeader } from '@angular/material/card';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-recipe-item',
  standalone: true,
  imports: [
    MatCard,
    MatCardHeader,
    MatCardContent,
    RouterLink
  ],
  templateUrl: './recipe-item.component.html',
  styleUrl: './recipe-item.component.scss'
})
export class RecipeItemComponent {
  @Input() recipe?: Recipe;
}
