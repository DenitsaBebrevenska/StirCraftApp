import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { IngredientsService } from '../../../core/services/ingredients.service';
import { Router } from '@angular/router';
import { MatCard } from '@angular/material/card';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { SelectOptionComponent } from "../../../shared/components/select-option/select-option.component";
import { IngredientCreateForm } from '../../../shared/models/ingredient/ingredientCreateForm';

@Component({
  selector: 'app-create-ingredient',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatCard,
    TextInputComponent,
    SelectOptionComponent
  ],
  templateUrl: './create-ingredient.component.html',
  styleUrl: './create-ingredient.component.scss'
})
export class CreateIngredientComponent {
  private ingredientsService = inject(IngredientsService);
  private formBuilder = inject(FormBuilder);
  private snack = inject(SnackbarService);
  private router = inject(Router);
  validationErrors?: string[];

  dto: IngredientCreateForm = {
    name: '',
    isAllergen: false
  };

  allergenOptions = [
    { value: true, label: 'Yes' },
    { value: false, label: 'No' },
  ];

  createIngredientForm = this.formBuilder.group({
    name: ['', Validators.required],
    isAllergen: [null, Validators.required]
  });

  onSubmit() {
    this.dto = {
      name: this.createIngredientForm.value.name ?? '',
      isAllergen: this.createIngredientForm.value.isAllergen ?? false
    };

    this.ingredientsService.createIngredient(this.dto).subscribe({
      next: () => {
        this.snack.success('Successfully added ingredient.');
        this.router.navigateByUrl('/ingredients');
      },
      error: errors => this.validationErrors = errors
    });
  }
}
