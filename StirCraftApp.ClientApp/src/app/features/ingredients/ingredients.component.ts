import { Component, inject, OnInit } from '@angular/core';
import { IngredientsService } from '../../core/services/ingredients.service';
import { Pagination } from '../../shared/models/pagination';
import { IngredientParams } from '../../shared/models/ingredient/ingredientParams';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatIcon } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { IngredientShort } from '../../shared/models/ingredient/ingredientShort';
import { MatListOption, MatSelectionList, MatSelectionListChange } from '@angular/material/list';
import { RecipesService } from '../../core/services/recipes.service';
import { RecipeParams } from '../../shared/models/recipe/recipeParams';

@Component({
  selector: 'app-ingredients',
  standalone: true,
  imports: [
    MatPaginator,
    MatIcon,
    FormsModule,
    MatSelectionList,
    MatListOption
  ],
  templateUrl: './ingredients.component.html',
  styleUrl: './ingredients.component.scss'
})

export class IngredientsComponent implements OnInit {
  private ingredientsService = inject(IngredientsService);
  private router = inject(Router);
  ingredients?: Pagination<IngredientShort>;
  filterOptions = [
    {name: "All", value: ""},
    {name: "Allergens", value: "true"},
    {name: "NonAllergens", value: "false"}
  ];

  ingredientParams = new IngredientParams();
  pageSizeOptions = [20, 35, 50];

  ngOnInit(): void{
    this.initializeIngredeints();
  }

  initializeIngredeints() { 
    this.getIngredients();
  }
  
  getIngredients(){
    this.ingredientsService.getIngredients(this.ingredientParams)
    .subscribe({
      next: response => this.ingredients = response,
      error: error => console.error(error)
    });
  }

  onSortChange(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if(selectedOption) {
      this.ingredientParams.isAllergen = selectedOption.value;
      this.ingredientParams.pageIndex = 1;
      this.getIngredients();
    }
  }
  
  onSearchChange(){
    this.ingredientParams.pageIndex = 1;
    this.getIngredients();
  }

  handlePage(event: PageEvent) {
    this.ingredientParams.pageIndex = event.pageIndex + 1;
    this.ingredientParams.pageSize = event.pageSize;
    this.getIngredients();
  }

  onClickIngredientName(id: number){
   const params: RecipeParams = new RecipeParams();
   params.ingredientId = id;
  
   this.router.navigate(['/recipes'], { queryParams: params });

  }
}
