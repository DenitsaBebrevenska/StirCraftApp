import { Component, inject } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { MatDivider } from '@angular/material/divider';
import { CategoriesService } from '../../../core/services/categories.service';
import { MatButton } from '@angular/material/button';
import { MatButtonToggleGroup } from '@angular/material/button-toggle';
import { MatButtonToggle } from '@angular/material/button-toggle';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';

@Component({
  selector: 'app-filters-dialog',
  standalone: true,
  imports: [
    MatDivider,
    MatButton,
    MatButtonToggleGroup,
    MatButtonToggle,
    FormsModule,
    MatFormField,
    MatInput 
  ],
  templateUrl: './filters-dialog.component.html',
  styleUrl: './filters-dialog.component.scss'
})
export class FiltersDialogComponent {
  recipesService = inject(RecipesService);
  categoriesService = inject(CategoriesService);
  private dialogReference = inject(MatDialogRef<FiltersDialogComponent>);
  data = inject(MAT_DIALOG_DATA);

  selectedCategories: string[] = this.data.selectedCategories;
  selectedDifficultyLevels: string[] = this.data.selectedDifficultyLevels;
  searchName: string = this.data.searchName;

  applyFilters() {
    this.dialogReference.close({
      selectedCategories: this.selectedCategories,
      selectedDifficultyLevels: this.selectedDifficultyLevels,
      searchName: this.searchName
    });
  }

  resetFilters() {
    this.selectedCategories = [];
    this.selectedDifficultyLevels = [];
    this.searchName = '';
  }

}
