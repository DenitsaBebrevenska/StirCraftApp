import { Component, inject, OnInit} from '@angular/core';
import { RecipesService } from '../../core/services/recipes.service';
import { RecipeShort } from '../../shared/models/recipe/recipeShort';
import { RecipeItemComponent } from "./recipe-item/recipe-item.component";
import { CategoriesService } from '../../core/services/categories.service';
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { MatListOption, MatSelectionListChange} from '@angular/material/list';
import { MatSelectionList } from '@angular/material/list';
import { RecipeParams } from '../../shared/models/recipe/recipeParams';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Pagination } from '../../shared/models/pagination';
import { FormsModule } from '@angular/forms';


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
    MatMenuTrigger, 
    MatPaginator,
    FormsModule
],
  templateUrl: './recipes.component.html',
  styleUrl: './recipes.component.scss'
})

export class RecipesComponent implements OnInit{
  private recipesService = inject(RecipesService);
  recipes?: Pagination<RecipeShort>;
  private categoriesService = inject(CategoriesService);
  categories: string[] = [];
  private dialogService = inject(MatDialog);
  sortOptions = [
    {name: "Rating-Descending", value: "default"},
    {name: "Rating-Ascending", value: "ratingAsc"},
    {name: "Difficulty-Ascending", value: "difficultyLevelAsc"},
    {name: "Difficulty-Descending", value: "difficultyLevelDesc"}
  ];

  recipesParams = new RecipeParams();
  pageSizeOptions = [5, 10, 15, 20];

  ngOnInit(): void {
    this.initializeRecipes();
  }

  initializeRecipes() { 
    this.recipesService.getDifficultyLevels();
    this.categoriesService.getCategories();
    this.getRecipes();
  }

  getRecipes(){
    this.recipesService.getRecipes(this.recipesParams)
    .subscribe({
      next: response => this.recipes = response,
      error: error => console.error(error)
    });
  }

  onSearchChange(){
    this.recipesParams.pageIndex = 1;
    this.getRecipes();
  }

  handlePage(event: PageEvent) {
    this.recipesParams.pageIndex = event.pageIndex + 1;
    this.recipesParams.pageSize = event.pageSize;
    this.getRecipes();
  }

  onSortChange(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if(selectedOption) {
      this.recipesParams.sort = selectedOption.value;
      this.recipesParams.pageIndex = 1;
      this.getRecipes();
    }
  }

  openFiltersDialog() {
    const dialogReference = this.dialogService.open(FiltersDialogComponent, {
      minWidth: '400px',
      data: {
        selectedCategories: this.recipesParams.categories,
        selectedDifficultyLevels: this.recipesParams.difficultyLevels,
        searchName: this.recipesParams.searchName
      }
    });

    dialogReference.afterClosed()
    .subscribe({
      next: result =>{
        this.recipesParams.categories = result.selectedCategories;
        this.recipesParams.difficultyLevels = result.selectedDifficultyLevels;
        this.recipesParams.searchName = result.searchName;
        this.recipesParams.pageIndex = 1;
        this.getRecipes();
      }
    });
  }
}
