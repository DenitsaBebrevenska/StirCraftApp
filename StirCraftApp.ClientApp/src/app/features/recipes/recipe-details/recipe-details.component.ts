import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { ActivatedRoute } from '@angular/router';
import { RecipeDetailed } from '../../../shared/models/recipe/recipeDetailed';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatCard } from '@angular/material/card';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { TextAreaComponent } from '../../../shared/components/text-area/text-area.component';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-recipe-details',
  standalone: true,
  imports: [
    MatButton,
    MatIcon,
    MatCard,
    TextInputComponent,
    TextAreaComponent,
    ReactiveFormsModule
  ],
  templateUrl: './recipe-details.component.html',
  styleUrl: './recipe-details.component.scss'
})
export class RecipeDetailsComponent implements OnInit {

  private recipeService = inject(RecipesService);
  private activatedRoute = inject(ActivatedRoute);
  private formBuilder = inject(FormBuilder);
  validationErrors?: string[];
  ratingOptions = [1, 2, 3, 4, 5];
  recipe?: RecipeDetailed;

  commentForm = this.formBuilder.group({
    title: ['', Validators.required],
    body: ['', Validators.required]
  });

  replyForm = this.formBuilder.group({
    body: ['', Validators.required]
  });

  ngOnInit(): void {
    this.loadRecipe();
    this.loadSavedState();
  }

  loadRecipe() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.recipeService.getRecipe(+id).subscribe(
      {
        next: recipe => this.recipe = recipe,
        error: err => console.error(err)
      }
    );
  }

  loadSavedState() {
    if (this.recipe) {
      const favoriteKey = `favorite_${this.recipe.id}`;
      const favorite = localStorage.getItem(favoriteKey);
      if (favorite !== null) this.recipe.isFavorite = JSON.parse(favorite);

      const ratingKey = `rating_${this.recipe.id}`;
      const rating = localStorage.getItem(ratingKey);
      if (rating !== null) this.recipe.rating = parseInt(rating);
    }
  }

  toggleFavorite() {

    if (!this.recipe) return;

    this.recipeService.toggleFavorite(this.recipe.id).subscribe({
      next: isFavorite => {
        this.recipe!.isFavorite = isFavorite;
      }
    });

    this.saveState();
    window.location.reload();
  }

  rateRecipe(rating: number) {
    if (!this.recipe) return;

    this.recipeService.rateRecipe(this.recipe.id, +rating).subscribe({
      next: newRating => {
        this.recipe!.rating = newRating;
      }
    });
    this.saveState();
    window.location.reload();
  }

  saveState() {
    if (this.recipe) {
      localStorage.setItem(`favorite_${this.recipe.id}`, String(this.recipe.isFavorite));
      localStorage.setItem(`rating_${this.recipe.id}`, String(this.recipe.rating));
    }
  }

  onSubmit() { }
}
