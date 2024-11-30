import { Component, inject } from '@angular/core';
import { IngredientsService } from '../../../core/services/ingredients.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Router } from '@angular/router';
import { RecipesService } from '../../../core/services/recipes.service';

@Component({
  selector: 'app-cook-delete-recipe-dialog',
  standalone: true,
  imports: [],
  templateUrl: './cook-delete-recipe-dialog.component.html',
  styleUrl: './cook-delete-recipe-dialog.component.scss'
})
export class CookDeleteRecipeDialogComponent {
  recipesService = inject(RecipesService);
  private dialogReference = inject(MatDialogRef<CookDeleteRecipeDialogComponent>);
  private snack = inject(SnackbarService);
  private router = inject(Router);
  data = inject(MAT_DIALOG_DATA);

  approveDeletion(){    
    this.dialogReference.close(true);
    this.recipesService.deleteRecipe(this.data.id).subscribe({
      next: () => {
        this.snack.success('Recipe deleted successfully');
        window.location.reload();
      },
      error: err => {
        this.snack.error('An error occurred while deleting the recipe');
        console.error(err);
      }
    });
  }

  cancelDeletion(){
    this.dialogReference.close(true);
  }
}
