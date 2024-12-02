import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { ActivatedRoute } from '@angular/router';
import { RecipeDetailed } from '../../../shared/models/recipe/recipeDetailed';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatCard } from '@angular/material/card';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { TextAreaComponent } from '../../../shared/components/text-area/text-area.component';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { SnackbarService } from '../../../core/services/snackbar.service';

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
  private snackBar = inject(SnackbarService);
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

  toggleFavorite() {

    if (!this.recipe) return;

    this.recipeService.toggleFavorite(this.recipe.id).subscribe({
      next: isFavorite => {
        this.recipe!.isLikedByCurrentUser = isFavorite;
      }
    });

    window.location.reload();
  }

  rateRecipe(value: number) {
    if (!this.recipe || value < 0 || value > 5) return;

    this.recipeService.rateRecipe(this.recipe!.id, +value).subscribe({});
    window.location.reload();
  }

  onSubmit() { }
}
