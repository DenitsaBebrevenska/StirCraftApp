import { Component, inject } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { ActivatedRoute, Router } from '@angular/router';
import { IngredientDetailed } from '../../../shared/models/ingredient/ingredientDetailed';
import { IngredientsService } from '../../../core/services/ingredients.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { SelectOptionComponent } from '../../../shared/components/select-option/select-option.component';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-edit-ingredient',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatCard,
    MatButton,
    TextInputComponent,
    SelectOptionComponent,
  ],
  templateUrl: './edit-ingredient.component.html',
  styleUrl: './edit-ingredient.component.scss'
})
export class EditIngredientComponent {
  private activatedRoute = inject(ActivatedRoute);
  private ingredientsService = inject(IngredientsService);
  private formBuilder = inject(FormBuilder);
  private snack = inject(SnackbarService);
  private router = inject(Router);
  validationErrors?: string[];

  id: string | null | undefined;
  ingredient: IngredientDetailed | undefined;

  allergenOptions = [
    { value: true, label: 'Yes' },
    { value: false, label: 'No' },
  ];
  approvalOptions = [
    { value: true, label: 'Yes' },
    { value: false, label: 'No' },
  ]

  editIngredientForm = this.formBuilder.group({
    name: ['', Validators.required],
    isAllergen: [null as boolean | null, Validators.required],
    isAdminApproved: [null as boolean | null, Validators.required],
  });

  ngOnInit(): void {
    this.loadIngredient();
  }

  loadIngredient() {
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!this.id) return;
    this.ingredientsService.getIngredient(+this.id).subscribe(
      {
        next: response => this.editIngredientForm.patchValue({
          name: response.name,
          isAllergen: response.isAllergen,
          isAdminApproved: response.isAdminApproved
        }),
        error: err => console.error(err)
      }
    );
  }

  onSubmit() {
    if (this.editIngredientForm.invalid) return;

    const updatedIngredient: IngredientDetailed = {
      id: Number(this.id),
      name: this.editIngredientForm.get('name')?.value ?? '',
      isAllergen: this.editIngredientForm.get('isAllergen')?.value ?? false,
      isAdminApproved: this.editIngredientForm.get('isAdminApproved')?.value ?? false
    }

    this.ingredientsService.updateIngredient(Number(this.id), updatedIngredient).subscribe({
      next: () => {
        this.snack.success('Successfully updated ingredient.');
        this.router.navigateByUrl('/admin/ingredients');
      },
      error: errors => this.validationErrors = errors
    });
  }
}
