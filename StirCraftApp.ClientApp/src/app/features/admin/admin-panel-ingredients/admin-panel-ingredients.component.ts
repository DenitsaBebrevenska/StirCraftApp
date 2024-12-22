import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatIcon } from '@angular/material/icon';
import { MatListOption, MatSelectionList, MatSelectionListChange } from '@angular/material/list';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Router, RouterLink } from '@angular/router';
import { IngredientsService } from '../../../core/services/ingredients.service';
import { Pagination } from '../../../shared/models/pagination';
import { IngredientDetailed } from '../../../shared/models/ingredient/ingredientDetailed';
import { IngredientAdminParams } from '../../../shared/models/ingredient/igredientAdminParams';
import { IngredientAdminShort } from '../../../shared/models/ingredient/ingredientAdminShort';
import { MatCard } from '@angular/material/card';
import { IngredientParams } from '../../../shared/models/ingredient/ingredientParams';

@Component({
  selector: 'app-admin-panel-ingredients',
  standalone: true,
  imports: [
    MatPaginator,
    MatIcon,
    FormsModule,
    MatSelectionList,
    MatListOption,
    MatCard
  ],
  templateUrl: './admin-panel-ingredients.component.html',
  styleUrl: './admin-panel-ingredients.component.scss'
})
export class AdminPanelIngredientsComponent {
  private ingredientsService = inject(IngredientsService);
  private router = inject(Router);
  ingredientParams = new IngredientParams();
  ingredients?: Pagination<IngredientAdminShort>;
  filterOptions = [
    { name: "All", value: "" },
    { name: "Approved", value: "true" },
    { name: "Not Approved", value: "false" }
  ];

  ingredientAdminParams = new IngredientAdminParams();
  pageSizeOptions = [20, 35, 50];

  ngOnInit(): void {
    this.initializeIngredeints();
  }

  initializeIngredeints() {
    this.getIngredients();
  }

  getIngredients() {
    this.ingredientsService.getAdminIngredients(this.ingredientAdminParams)
      .subscribe({
        next: response => this.ingredients = response,
        error: error => console.error(error)
      });
  }

  onSortChange(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if (selectedOption) {
      this.ingredientAdminParams.isAdminApproved = selectedOption.value;
      this.ingredientAdminParams.pageIndex = 1;
      this.getIngredients();
    }
  }

  onSearchChange() {
    this.ingredientAdminParams.pageIndex = 1;
    this.getIngredients();
  }

  handlePage(event: PageEvent) {
    this.ingredientAdminParams.pageIndex = event.pageIndex + 1;
    this.ingredientAdminParams.pageSize = event.pageSize;
    this.getIngredients();
  }

  onClickIngredientName(id: number) {
    this.router.navigate(['admin/ingredients/', id]);
  }

  clearInputField() {
    this.ingredientParams.searchName = '';
    this.getIngredients();
  }
}
