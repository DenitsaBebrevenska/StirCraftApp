import { Component, inject, OnInit} from '@angular/core';
import { RecipesService } from '../../core/services/recipes.service';
import { RecipeShort } from '../../shared/models/recipeShort';
import { RecipeItemComponent } from "./recipe-item/recipe-item.component";
import { CategoriesService } from '../../core/services/categories.service';
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [
    RecipeItemComponent,
    MatButton,
    MatIcon
],
  templateUrl: './recipes.component.html',
  styleUrl: './recipes.component.scss'
})
export class RecipesComponent implements OnInit{
  private recipesService = inject(RecipesService);
  recipes: RecipeShort[] = [];
  private categoriesService = inject(CategoriesService);
  categories: string[] = [];
  private dialogService = inject(MatDialog);

  ngOnInit(): void {
    this.initializeRecipes();
  }

  initializeRecipes() { 
    this.recipesService.getDifficultyLevels();
    this.categoriesService.getCategories();
    this.recipesService.getRecipes()
      .subscribe({
        next: response => this.recipes = response.data,
        error: error => console.error(error)
      });
  }

  openFiltersDialog() {
    const dialogReference = this.dialogService.open(FiltersDialogComponent, {
      minWidth: '300px',
    });
  }
}
