import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { ActivatedRoute, RouterLink, RouterLinkActive } from '@angular/router';
import { CooksService } from '../../../core/services/cooks.service';
import { CookDetailed } from '../../../shared/models/cookDetailed';
import { Pagination } from '../../../shared/models/pagination';
import { RecipeShort } from '../../../shared/models/recipeShort';

@Component({
  selector: 'app-cook-details',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './cook-details.component.html',
  styleUrl: './cook-details.component.scss'
})
export class CookDetailsComponent implements OnInit {
  private activatedRoute = inject(ActivatedRoute);
  private cookService = inject(CooksService);
  id: string | null | undefined;

  cook?: CookDetailed;
  recipes?: Pagination<RecipeShort>;

  ngOnInit(): void {
    this.loadCook();
  }

  loadCook() {
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!this.id) return;
    this.cookService.getCook(+this.id).subscribe(
      {
        next: response => this.cook = response,
        error: err => console.error(err)
      }
    );
  }

}

