import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { PagingParams } from '../../../shared/models/pagingParams';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Pagination } from '../../../shared/models/pagination';
import { RecipeShort } from '../../../shared/models/recipe/recipeShort';
import { MatCard, MatCardActions, MatCardContent, MatCardHeader } from '@angular/material/card';
import { BriefRecipe } from '../../../shared/models/briefRecipe';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-favorites',
  standalone: true,
  imports: [
    MatCard,
    MatCardHeader,
    MatCardActions,
    MatPaginator,
    RouterLink
  ],
  templateUrl: './favorites.component.html',
  styleUrl: './favorites.component.scss'
})
export class FavoritesComponent implements OnInit {
  private recipesService = inject(RecipesService);
  private snackbar = inject(SnackbarService);
  pagingParams = new PagingParams();
  recipes?: Pagination<BriefRecipe>;
  pageSizeOptions = [5, 10, 20];

  ngOnInit(): void {
    this.loadUserFavorites();
  }

  loadUserFavorites() {
    this.recipesService.getUserFavoriteRecipes(this.pagingParams).subscribe(
      {
        next: response => this.recipes = response,
        error: err => console.error(err)
      }
    );
  }

  handlePage(event: PageEvent) {
    this.pagingParams.pageIndex = event.pageIndex + 1;
    this.pagingParams.pageSize = event.pageSize;
    this.loadUserFavorites();
  }

  removeFromFavorites(recipeId: number) {
    this.recipesService.toggleFavorite(recipeId).subscribe({
      next: () => {
        this.snackbar.success('Recipe removed from favorites');
        this.loadUserFavorites();
      },
      error: (err) => {
        console.error(err);
        this.snackbar.error('Failed to remove recipe from favorites');
      }
    });
  }

}
