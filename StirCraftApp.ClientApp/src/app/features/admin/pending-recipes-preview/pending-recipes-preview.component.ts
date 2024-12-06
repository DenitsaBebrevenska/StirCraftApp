import { Component, inject, OnInit } from '@angular/core';
import { MatCard, MatCardHeader } from '@angular/material/card';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Pagination } from '../../../shared/models/pagination';
import { BriefRecipe } from '../../../shared/models/briefRecipe';
import { PagingParams } from '../../../shared/models/pagingParams';
import { RecipesService } from '../../../core/services/recipes.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-pending-recipes-preview',
  standalone: true,
  imports: [
    MatCard,
    MatPaginator,
    MatCardHeader,
    RouterLink
  ],
  templateUrl: './pending-recipes-preview.component.html',
  styleUrl: './pending-recipes-preview.component.scss'
})
export class PendingRecipesPreviewComponent implements OnInit {
  private recipesService = inject(RecipesService);
  recipes?: Pagination<BriefRecipe>;
  pagingParams = new PagingParams();
  pageSizeOptions = [5, 10, 20, 50];

  ngOnInit(): void {
    this.getRecipes();
  }


  getRecipes() {
    this.recipesService.getRecipesPendingApproval(this.pagingParams).subscribe((response) => {
      this.recipes = response;
    });
  }


  handlePage(event: PageEvent) {
    this.pagingParams.pageIndex = event.pageIndex + 1;
    this.pagingParams.pageSize = event.pageSize;
    this.getRecipes();
  }
}
