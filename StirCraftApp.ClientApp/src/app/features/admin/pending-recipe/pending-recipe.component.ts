import { Component, inject, OnInit } from '@angular/core';
import { RecipeOwnDetailed } from '../../../shared/models/recipe/recipeOwnDetailed';
import { RecipesService } from '../../../core/services/recipes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { RecipeOwn } from '../../../shared/models/recipe/recipeOwn';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { RecipeAdminNotes } from '../../../shared/models/recipe/recipeAdminNotes';
import { TextAreaComponent } from '../../../shared/components/text-area/text-area.component';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-pending-recipe',
  standalone: true,
  imports: [
    MatButton,
    ReactiveFormsModule,
    TextAreaComponent
  ],
  templateUrl: './pending-recipe.component.html',
  styleUrl: './pending-recipe.component.scss'
})
export class PendingRecipeComponent implements OnInit {
  private recipesService = inject(RecipesService);
  private activatedRoute = inject(ActivatedRoute);
  private formBuilder = inject(FormBuilder);
  private router = inject(Router);
  recipe?: RecipeOwnDetailed;
  private snack = inject(SnackbarService);
  validationErrors?: string[];
  notesForm = this.formBuilder.group({
    notes: ['']
  });

  ngOnInit(): void {
    this.loadRecipe();
  }

  loadRecipe() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.recipesService.getRecipePendingApprovalById(+id).subscribe(
      {
        next: response => {
          this.recipe = response,
            this.notesForm.patchValue({
              notes: this.recipe.adminNotes || ''
            });
        },
        error: err => console.error(err)
      }
    );
  }

  onSubmit() {
    if (this.notesForm.invalid || !this.recipe) {
      return;
    }

    const adminNotes: RecipeAdminNotes = {
      adminNotes: this.notesForm.get('notes')!.value || ''
    };

    this.recipesService.updateAdminNotes(this.recipe.id, adminNotes).subscribe({
      next: () => {
        this.snack.success('Admin notes updated successfully');
        this.router.navigate(['/admin/recipes/pending-approval']);
      },
      error: (error) => {
        this.validationErrors = error.messages;
      }
    });
  }

  approveRecipe() {
    if (!this.recipe) return;
    this.recipesService.approveRecipe(this.recipe.id).subscribe({
      next: () => {
        this.snack.success('Recipe successfully approved');
        this.router.navigate(['/admin/recipes/pending-approval']);
      },
      error: (error) => {
        this.validationErrors = error.messages
      }
    });
  }
}
