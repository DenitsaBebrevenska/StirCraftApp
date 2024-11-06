import { Component, inject, OnInit} from '@angular/core';
import { RecipesService } from '../../core/services/recipes.service';
import { RecipeShort } from '../../shared/models/recipeShort';
import { RecipeItemComponent } from "./recipe-item/recipe-item.component";
import { CategoriesService } from '../../core/services/categories.service';
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { MatListOption, MatSelectionListChange} from '@angular/material/list';
import { MatSelectionList } from '@angular/material/list';


@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [
    RecipeItemComponent,
    MatButton,
    MatIcon,
    MatMenu,
    MatListOption,
    MatSelectionList, 
    MatMenuTrigger
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
  selectedCategories: string[] = [];
  selectedDifficultyLevels: string[] = [];
  selectedSort: string = "Rating-Descending";
  sortOptions = [
    {name: "Difficulty Level-Ascending", value: "difficultyLevelAsc"},
    {name: "Difficulty Level-Descending", value: "difficultyLevelDesc"},
    {name: "Rating-Ascending", value: "ratingAsc"},
    {name: "Rating-Descending", value: "default"}
  ];

  ngOnInit(): void {
    this.initializeRecipes();
  }

  initializeRecipes() { 
    this.recipesService.getDifficultyLevels();
    this.categoriesService.getCategories();
    this.getRecipes();
  }

  getRecipes(){
    this.recipesService.getRecipes(this.selectedCategories, this.selectedDifficultyLevels, this.selectedSort)
    .subscribe({
      next: response => this.recipes = response.data,
      error: error => console.error(error)
    });
  }

  onSortChange(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if(selectedOption) {
      this.selectedSort = selectedOption.value;
      this.getRecipes();
    }
  }

  openFiltersDialog() {
    const dialogReference = this.dialogService.open(FiltersDialogComponent, {
      minWidth: '400px',
      data: {
        selectedCategories: this.selectedCategories,
        selectedDifficultyLevels: this.selectedDifficultyLevels,
      }
    });

    dialogReference.afterClosed()
    .subscribe({
      next: result =>{
        this.selectedCategories = result.selectedCategories;
        this.selectedDifficultyLevels = result.selectedDifficultyLevels;
        this.getRecipes();
      }
    });
  }
}
