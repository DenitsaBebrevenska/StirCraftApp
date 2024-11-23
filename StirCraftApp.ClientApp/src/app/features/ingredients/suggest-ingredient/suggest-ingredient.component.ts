import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatCard } from '@angular/material/card';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { IngredientsService } from '../../../core/services/ingredients.service';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Router } from '@angular/router';
import { IngredientSuggest } from '../../../shared/models/ingredient/ingredientSuggest';

@Component({
  selector: 'app-suggest-ingredient',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatCard,
    TextInputComponent
  ],
  templateUrl: './suggest-ingredient.component.html',
  styleUrl: './suggest-ingredient.component.scss'
})
export class SuggestIngredientComponent {
  private ingredientsService = inject(IngredientsService);
  private formBuilder = inject(FormBuilder);
  private snack = inject(SnackbarService);
  private router = inject(Router);
  validationErrors?: string[];
  dto: IngredientSuggest = {
    name: ''
  }

  suggestIngredientForm = this.formBuilder.group({
    name: ['', Validators.required]
  });

  onSubmit(){
    this.dto = {
      name: this.suggestIngredientForm.value.name ?? ''
    };

    this.ingredientsService.suggestIngredient(this.dto).subscribe({
      next: () => {
        this.snack.success('Successfully suggested an ingredient.');
        this.router.navigateByUrl('/ingredients');
      },
      error: errors => this.validationErrors = errors
  });
  this.suggestIngredientForm.reset();
  }
}
