import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { ActivatedRoute } from '@angular/router';
import { CooksService } from '../../../core/services/cooks.service';
import { CookDetailed } from '../../../shared/models/cookDetailed';
import { Pagination } from '../../../shared/models/pagination';
import { RecipeShort } from '../../../shared/models/recipeShort';

@Component({
  selector: 'app-cook-details',
  standalone: true,
  imports: [],
  templateUrl: './cook-details.component.html',
  styleUrl: './cook-details.component.scss'
})
export class CookDetailsComponent implements OnInit {
  private recipeService = inject(RecipesService);
  private activatedRoute = inject(ActivatedRoute);
  private cookService = inject(CooksService);

  cook?: CookDetailed;
  recipes?: Pagination<RecipeShort>;

  ngOnInit(): void {
    this.loadCook();
  }

  loadCook() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.cookService.getCook(+id).subscribe(
      {
        next: response => this.cook = response,
        error: err => console.error(err)
      }
    );
  }

  loadCookRecipes() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.recipeService.getCookRecipes(+id).subscribe(
      {
        next: response => this.recipes = response,
        error: err => console.error(err)
      }
    );
  }
}

