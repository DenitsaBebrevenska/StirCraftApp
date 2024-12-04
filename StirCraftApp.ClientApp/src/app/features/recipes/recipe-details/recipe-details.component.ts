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
import { CommentForm } from '../../../shared/models/recipe/commentForm';
import { EditComment } from '../../../shared/models/recipe/editComment';

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
  commentValidationErrors?: string[];
  commentEditValidationErrors?: string[];
  replyValidationErrors?: string[];
  replyEditValidtionErrors?: string[];
  ratingOptions = [1, 2, 3, 4, 5];
  isInEditMode = false;
  currentRating: number = 0;
  isLiked?: boolean;
  recipe?: RecipeDetailed;
  editingCommentId?: number;

  commentForm = this.formBuilder.group({
    title: ['', Validators.required],
    body: ['', Validators.required]
  });

  commentEditForm = this.formBuilder.group({
    title: ['', Validators.required],
    body: ['', Validators.required]
  });


  replyForm = this.formBuilder.group({
    body: ['', Validators.required]
  });

  commentDto: CommentForm = {
    title: '',
    body: ''
  }

  ngOnInit(): void {
    this.loadRecipe();
  }

  loadRecipe() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.recipeService.getRecipe(+id).subscribe(
      {
        next: response => {
          this.recipe = response,
            this.isLiked = response.isLikedByCurrentUser,
            this.currentRating = response.currentUserRating || 0
        },
        error: err => console.error(err)
      }
    );
  }

  toggleFavorite() {
    if (!this.recipe) return;

    this.recipeService.toggleFavorite(this.recipe.id).subscribe({
      next: response => {
        // Directly update the local state
        this.isLiked = response.isFavorite;

        // Optimistically update likes count
        if (this.recipe) {
          this.recipe.likes = response.totalLikes;
        }

        this.snackBar.success(`Recipe ${response.isFavorite == true ? 'added to' : 'removed from'} favorites`);
      },
      error: () => {
        this.snackBar.error('Failed to update favorite status');
      }
    });
  }

  rateRecipe(value: number) {
    if (!this.recipe || value < 0 || value > 5) return;

    // Optimistically update the UI first
    this.currentRating = value;

    this.recipeService.rateRecipe(this.recipe.id, +value).subscribe({
      next: response => {
        // Update current user's rating
        if (this.recipe) {
          this.recipe.currentUserRating = value;
          this.recipe.rating = +response;

        }

        this.snackBar.success(`You rated this recipe ${value} stars`);
      },
      error: () => {
        // If the server call fails, revert the rating
        this.currentRating = this.recipe?.currentUserRating || 0;
        this.snackBar.error('Failed to submit rating');
      }
    });
  }

  onCommentSubmit() {
    if (this.commentForm.invalid) {
      return;
    }

    const formValue = this.commentForm.value;
    this.commentDto = {
      title: formValue.title!,
      body: formValue.body!
    };

    if (this.recipe) {
      this.recipeService.addComment(this.recipe.id, this.commentDto).subscribe({
        next: () => {
          this.snackBar.success('Successfully added comment.');
          this.loadRecipe();
        },
        error: errors => this.commentValidationErrors = errors
      });
    }

  }

  startCommentEditing(comment: any) {
    this.commentEditForm.patchValue({
      title: comment.title,
      body: comment.body
    });

    this.editingCommentId = comment.id;
    this.isInEditMode = true;
  }


  saveComment() {
    // Check if form is valid
    if (this.commentEditForm.invalid) {
      return;
    }

    // Prepare the updated comment data
    const updatedComment: EditComment = {
      id: this.editingCommentId!,
      title: this.commentEditForm.get('title')?.value || '',
      body: this.commentEditForm.get('body')?.value || ''
    };

    // Call service method to update comment
    this.recipeService.updateComment(this.recipe!.id, this.editingCommentId!, updatedComment).subscribe({
      next: () => {
        // Reset edit mode and refresh recipe details
        this.isInEditMode = false;
        this.editingCommentId = undefined;
        this.snackBar.success('Comment updated successfully');

        // Optionally reload the recipe to get updated comments
        this.loadRecipe();
      },
      error: (errors) => {
        // Handle any errors
        this.commentEditValidationErrors = errors;
        this.snackBar.error('Failed to update comment');
      }
    });
  }


  cancelCommentEditing() {
    // Reset edit mode
    this.isInEditMode = false;
    this.editingCommentId = undefined;
  }

  onReplySubmit() { }

  onEditCommentSubmit() { }

}

