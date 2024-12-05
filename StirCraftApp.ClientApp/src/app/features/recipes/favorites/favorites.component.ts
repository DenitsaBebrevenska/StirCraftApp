import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { PagingParams } from '../../../shared/models/pagingParams';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Pagination } from '../../../shared/models/pagination';
import { RecipeShort } from '../../../shared/models/recipe/recipeShort';
import { MatCard, MatCardActions, MatCardContent, MatCardHeader } from '@angular/material/card';

@Component({
  selector: 'app-favorites',
  standalone: true,
  imports: [
    MatCard,
    MatCardHeader,
    MatCardContent,
    MatCardActions,
    MatPaginator
  ],
  templateUrl: './favorites.component.html',
  styleUrl: './favorites.component.scss'
})
export class FavoritesComponent implements OnInit {
  private recipesService = inject(RecipesService);
  pagingParams = new PagingParams();
  recipes?: Pagination<RecipeShort>;
  pageSizeOptions = [5, 10, 20];

  ngOnInit(): void {
    this.loadUserFavorites();
  }

  loadUserFavorites() {
    this.recipesService.getUserFavoriteRecipes(this.pagingParams).subscribe();
  }

  handlePage(event: PageEvent) {
    this.pagingParams.pageIndex = event.pageIndex + 1;
    this.pagingParams.pageSize = event.pageSize;
    this.loadUserFavorites();
  }

}
