import { Component, inject } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recipe-delete-comment-dialog',
  standalone: true,
  imports: [],
  templateUrl: './recipe-delete-comment-dialog.component.html',
  styleUrl: './recipe-delete-comment-dialog.component.scss'
})
export class RecipeDeleteCommentDialogComponent {
  recipesService = inject(RecipesService);
  private dialogReference = inject(MatDialogRef<RecipeDeleteCommentDialogComponent>);
  private snack = inject(SnackbarService);
  private router = inject(Router);
  data = inject(MAT_DIALOG_DATA);

  approveDeletion() {
    this.dialogReference.close(true);
    this.recipesService.deleteComment(this.data.recipeId, this.data.commentId).subscribe({
      next: () => {
        this.snack.success('Comment deleted successfully');
        window.location.reload();
      },
      error: err => {
        this.snack.error('An error occurred while deleting the comment');
        console.error(err);
      }
    });
  }

  cancelDeletion() {
    this.dialogReference.close(true);
  }
}
