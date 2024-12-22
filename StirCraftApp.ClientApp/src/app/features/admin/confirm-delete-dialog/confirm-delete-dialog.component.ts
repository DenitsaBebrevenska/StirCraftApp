import { Component, inject } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Router } from '@angular/router';
import { IngredientsService } from '../../../core/services/ingredients.service';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-confirm-delete-dialog',
  standalone: true,
  imports: [
    MatButton
  ],
  templateUrl: './confirm-delete-dialog.component.html',
  styleUrl: './confirm-delete-dialog.component.scss'
})
export class ConfirmDeleteDialogComponent {
  ingredientsService = inject(IngredientsService);
  private dialogReference = inject(MatDialogRef<ConfirmDeleteDialogComponent>);
  private snack = inject(SnackbarService);
  private router = inject(Router);
  data = inject(MAT_DIALOG_DATA);

  approveDeletion() {
    this.dialogReference.close(true);
    this.ingredientsService.deleteIngredient(this.data.id).subscribe({
      next: () => {
        this.snack.success('Ingredient deleted successfully');
        this.router.navigate(['/admin/ingredients']);
      },
      error: err => {
        this.snack.error('An error occurred while deleting the ingredient');
        console.error(err);
      }
    });
  }

  cancelDeletion() {
    this.dialogReference.close(true);
  }
}
