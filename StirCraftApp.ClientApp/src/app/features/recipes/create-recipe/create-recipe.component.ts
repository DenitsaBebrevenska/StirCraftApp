import { Component, inject, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatCard } from '@angular/material/card';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { SelectOptionComponent } from '../../../shared/components/select-option/select-option.component';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Router } from '@angular/router';
import { RecipeCreateForm } from '../../../shared/models/recipe/recipeCreateForm';
import { RecipesService } from '../../../core/services/recipes.service';
import { CategoriesService } from '../../../core/services/categories.service';
import { TextAreaComponent } from "../../../shared/components/text-area/text-area.component";
import { Category } from '../../../shared/models/recipe/category';
import { IngredientsService } from '../../../core/services/ingredients.service';
import { MatIcon } from '@angular/material/icon';
import { RecipeIngredient } from '../../../shared/models/recipe/recipeIngredient';
import { RecipeCreateFormIngredient } from '../../../shared/models/recipe/recipeCreateFormIngredient';
import { MatDialog } from '@angular/material/dialog';
import { MeasurementUnitsService } from '../../../core/services/measurement-units.service';
import { MeasurementUnitParams } from '../../../shared/models/measurementUnit/measurementUnitParams';
import { IngredientShort } from '../../../shared/models/ingredient/ingredientShort';
import { MeasurementUnit } from '../../../shared/models/measurementUnit/measurementUnit';

@Component({
  selector: 'app-create-recipe',
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
  templateUrl: './create-recipe.component.html',
  styleUrl: './create-recipe.component.scss'
})

export class CreateRecipeComponent implements OnInit{
  private recipesService = inject(RecipesService);
  private categoriesService = inject(CategoriesService); 
  private formBuilder = inject(FormBuilder);
  private snack = inject(SnackbarService);
  private router = inject(Router);
  private ingredientsService = inject(IngredientsService);
  private measurementUnitsService = inject(MeasurementUnitsService);
  recipeDto = new RecipeCreateForm();
  validationErrors?: string[];
  categories: Category[] = [];
  difficultyLevels: string[] = [];
  ingredientsInDb: IngredientShort[] = [];
  measurementUnits: MeasurementUnit[] = [];
  
  categoriesOptions: { value: number, label: string }[] = [];
  difficultyOptions: { value: string, label: string }[] =[];
  ingredientsOptions: { value: number, label: string }[] = [];
  measurementUnitsOptions: { value: string | null, label: string }[] =[];

  ngOnInit(): void {

    this.categoriesService.getCategories()
      .subscribe({
        next: response => {
          this.categories = response;
          this.categoriesOptions = this.categories.map(category => ({ value: category.id, label: category.name }));
        },
        error: err => console.error(err)
      });
     
      this.recipesService.getDifficultyLevels()
      .subscribe({
        next: response => {
          this.difficultyOptions = response.map(difficulty => ({ value: difficulty, label: difficulty }));
        },
        error: err => console.error(err)
      });

      this.ingredientsService.getAllNonPagedIngredients()
      .subscribe({
        next: response => 
        this.ingredientsOptions = response
        .map(ingredient => ({ value: ingredient.id, label: ingredient.name })),
        error: error => console.error(error)
      });

      this.measurementUnitsService.getUnits(new MeasurementUnitParams)
      .subscribe({
        next: response => {
        this.measurementUnitsOptions = response
        .map(measurementUnit => ({ value: measurementUnit.id.toString(), label: measurementUnit.abbreviation })),
        this.measurementUnitsOptions.unshift({ value: null, label: 'No unit' });},
        error: error => console.error(error)
      });
  }

  createIngredient(){
    return this.formBuilder.group({
      ingredientId: ['', Validators.required],
      quantity: [null, Validators.min(1)],
      measurementUnitId: [null]
    });
  }

  addIngredientLine(){
    (this.createRecipeForm.get('ingredients') as FormArray).push(this.createIngredient());
  }

  removeIngredientLine(index: number): void {
    (this.createRecipeForm.get('ingredients') as FormArray).removeAt(index);
  }

  get ingredients(): FormArray{
    return this.createRecipeForm.get('ingredients') as FormArray;
  }

  createRecipeForm = this.formBuilder.group({
    name: ['', Validators.required],
    preparationSteps: ['', Validators.required],
    image1: [''],
    image2: [''],
    image3: [''],
    difficultyLevel: [null, Validators.required],
    categories: [null, Validators.required],
    ingredients: this.formBuilder.array([this.createIngredient()]),
  });

  onSubmit(){
    if(this.createRecipeForm.invalid){
      return;
    }

    const formValue = this.createRecipeForm.value;
    this.recipeDto = {
      name: formValue.name!,
      preparationSteps: formValue.preparationSteps!,
      difficultyLevel: formValue.difficultyLevel!,
      recipeIngredients: formValue.ingredients!.map(ingredient => ({
        ingredientId: +ingredient.ingredientId!,
        quantity: +ingredient.quantity! || undefined,
        measurementUnitId: +ingredient.measurementUnitId! || undefined,
      })),
      recipeImages: [
        { url: formValue.image1! },
        { url: formValue.image2! },
        { url: formValue.image3! }
      ].filter(image => image.url), // Exclude empty image URLs
      categoryRecipes: formValue.categories!
  };


    this.recipesService.createRecipe(this.recipeDto).subscribe({
      next: () => {
        this.snack.success('Successfully added recipe.'); 
        this.router.navigateByUrl('/recipes');
      },
      error: errors => this.validationErrors = errors
  });
  }
 
}
