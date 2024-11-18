import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { Pagination } from '../../../shared/models/pagination';
import { RecipeCook } from '../../../shared/models/recipeCook';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { MatCard, MatCardContent, MatCardHeader } from '@angular/material/card';

@Component({
  selector: 'app-recipe-cook',
  standalone: true,
  imports: [
    MatCard,
    MatCardHeader,
    MatCardContent,
    RouterLink
  ],
  templateUrl: './recipe-cook.component.html',
  styleUrl: './recipe-cook.component.scss'
})
export class RecipeCookComponent implements OnInit {

  ngOnInit(): void {
    this.getRecipesCook();
  }

  private recipesService = inject(RecipesService);
  private activatedRoute = inject(ActivatedRoute);
  
  recipesCook?: Pagination<RecipeCook>;

  getRecipesCook(){
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.recipesService.getCookRecipes(+id).subscribe(
      {
        next: recipe => this.recipesCook = recipe,
        error: err => console.error(err)
      }
    );
  }
}
