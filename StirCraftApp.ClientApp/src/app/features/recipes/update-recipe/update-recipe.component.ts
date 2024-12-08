import { Component, inject, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { SelectOptionComponent } from '../../../shared/components/select-option/select-option.component';
import { TextAreaComponent } from '../../../shared/components/text-area/text-area.component';
import { MatCard } from '@angular/material/card';
import { MatIcon } from '@angular/material/icon';
import { RecipesService } from '../../../core/services/recipes.service';
import { CategoriesService } from '../../../core/services/categories.service';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IngredientsService } from '../../../core/services/ingredients.service';
import { MeasurementUnitsService } from '../../../core/services/measurement-units.service';
import { RecipeCreateForm } from '../../../shared/models/recipe/recipeCreateForm';
import { Category } from '../../../shared/models/recipe/category';
import { IngredientShort } from '../../../shared/models/ingredient/ingredientShort';
import { MeasurementUnit } from '../../../shared/models/measurementUnit/measurementUnit';
import { MeasurementUnitParams } from '../../../shared/models/measurementUnit/measurementUnitParams';
import { CookService } from '../../../core/services/cook.service';
import { RecipeOwnDetailed } from '../../../shared/models/recipe/recipeOwnDetailed';
import { catchError, tap, throwError } from 'rxjs';

@Component({
  selector: 'app-update-recipe',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    TextInputComponent,
    SelectOptionComponent,
    FormsModule,
    TextAreaComponent,
    MatCard,
    MatIcon
  ],
  templateUrl: './update-recipe.component.html',
  styleUrl: './update-recipe.component.scss'
})
export class UpdateRecipeComponent implements OnInit {
  private cookService = inject(CookService);
  private recipesService = inject(RecipesService);
  private categoriesService = inject(CategoriesService);
  private formBuilder = inject(FormBuilder);
  private snack = inject(SnackbarService);
  private router = inject(Router);
  private ingredientsService = inject(IngredientsService);
  private measurementUnitsService = inject(MeasurementUnitsService);
  private activatedRoute = inject(ActivatedRoute);

  recipeDto = new RecipeCreateForm();
  validationErrors?: string[];
  categories: Category[] = [];
  difficultyLevels: string[] = [];
  ingredientsInDb: IngredientShort[] = [];
  measurementUnits: MeasurementUnit[] = [];
  recipe?: RecipeOwnDetailed;
  categoriesOptions: { value: number, label: string }[] = [];
  difficultyOptions: { value: string, label: string }[] = [];
  ingredientsOptions: { value: number, label: string }[] = [];
  measurementUnitsOptions: { value: number | null, label: string }[] = [];
  id: any;

  editRecipeForm = this.formBuilder.group({
    name: ['', Validators.required],
    preparationSteps: ['', Validators.required],
    difficultyLevel: ['', Validators.required],
    ingredients: this.formBuilder.array([]),
    image1: [''],
    image2: [''],
    image3: [''],
    categories: [<number[]>[], Validators.required]
  });

  ngOnInit(): void {
    this.id = this.activatedRoute.snapshot.paramMap.get('id');

    if (!this.id) return;

    this.cookService.getCookOwnRecipe(+this.id).pipe(
      tap(),
      catchError(err => {
        console.error(err);
        return throwError(() => err);
      })
    ).subscribe({
      next: recipe => {
        this.recipe = recipe;

        setTimeout(() => {
          const ingredientsFormArray = this.editRecipeForm.get('ingredients') as FormArray;

          recipe.ingredients.forEach((ingredient) => {
            ingredientsFormArray.push(
              this.formBuilder.group({
                name: [ingredient.ingredientId, Validators.required],
                quantity: [ingredient.quantity ?? '', Validators.min(1)],
                measurementUnit: [ingredient.measurementUnitId || null],
              })
            );
          });

          this.editRecipeForm.patchValue({
            name: this.recipe!.name,
            preparationSteps: this.recipe!.preparationSteps,
            image1: this.recipe!.images[0]?.url || '',
            image2: this.recipe!.images[1]?.url || '',
            image3: this.recipe!.images[2]?.url || '',
            difficultyLevel: this.recipe!.difficultyLevel,
            categories: this.recipe!.categories.map(category => category.id)
          });

        }, 0); // setTimeout is needed to avoid ExpressionChangedAfterItHasBeenCheckedError
      },
      error: err => console.error(err)
    });


    this.categoriesService.getCategories().subscribe({
      next: response => {
        this.categories = response;
        this.categoriesOptions = this.categories.map(category => ({ value: category.id, label: category.name }));
      },
      error: err => console.error(err)
    });

    this.recipesService.getDifficultyLevels().subscribe({
      next: response => {
        this.difficultyOptions = response.map(difficulty => ({ value: difficulty, label: difficulty }));
      },
      error: err => console.error(err)
    });

    this.ingredientsService.getAllNonPagedIngredients().subscribe({
      next: response => this.ingredientsOptions = response.map(ingredient => ({ value: ingredient.id, label: ingredient.name })),
      error: error => console.error(error)
    });

    this.measurementUnitsService.getUnits().subscribe({
      next: response => {
        this.measurementUnitsOptions = response.map(measurementUnit => ({ value: measurementUnit.id, label: measurementUnit.abbreviation }));
        this.measurementUnitsOptions.unshift({ value: null, label: 'No unit' });
      },
      error: error => console.error(error)
    });
  }

  createIngredient() {
    return this.formBuilder.group({
      name: [null, Validators.required],
      quantity: [null, Validators.min(1)],
      measurementUnit: [null],
    });
  }

  addIngredientLine() {
    (this.editRecipeForm.get('ingredients') as FormArray).push(this.createIngredient());
  }

  removeIngredientLine(index: number): void {
    (this.editRecipeForm.get('ingredients') as FormArray).removeAt(index);
  }

  get ingredients(): FormArray {
    return this.editRecipeForm.get('ingredients') as FormArray;
  }

  onSubmit() {
    if (this.editRecipeForm.invalid) {
      return;
    }

    const formValue = this.editRecipeForm.value;

    const recipeDTO = {
      id: this.recipe!.id,
      name: formValue.name!,
      preparationSteps: formValue.preparationSteps!,
      difficultyLevel: formValue.difficultyLevel!,
      recipeIngredients: formValue.ingredients!.map((ingredient: any) => ({
        id: this.recipe!.ingredients.find(i => i.ingredientId === +ingredient.name)?.id,
        ingredientId: +ingredient.name!,
        quantity: +ingredient.quantity! || undefined,
        measurementUnitId: +ingredient.measurementUnit || undefined
      })),
      recipeImages: [
        { id: this.recipe!.images[0]?.id, url: formValue.image1! },
        { id: this.recipe!.images[1]?.id, url: formValue.image2! },
        { id: this.recipe!.images[2]?.id, url: formValue.image3! }
      ].filter(image => image.url), // Exclude empty image URLs
      categoryRecipes: formValue.categories!
    };

    this.recipesService.updateRecipe(this.id, recipeDTO).subscribe({
      next: () => {
        this.snack.success('Successfully updated the recipe.');
        this.router.navigateByUrl('/recipes');
      },
      error: errors => this.validationErrors = errors
    });
  }
}
