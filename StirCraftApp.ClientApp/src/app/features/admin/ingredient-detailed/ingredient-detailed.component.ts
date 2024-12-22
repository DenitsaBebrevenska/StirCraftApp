import { Component, inject, OnInit } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { IngredientDetailed } from '../../../shared/models/ingredient/ingredientDetailed';
import { IngredientsService } from '../../../core/services/ingredients.service';
import { MatIcon } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDeleteDialogComponent } from '../confirm-delete-dialog/confirm-delete-dialog.component';
import { MatButton } from '@angular/material/button';


@Component({
  selector: 'app-ingredient-detailed',
  standalone: true,
  imports: [
    MatCard,
    MatIcon,
    MatButton,
    RouterLink
  ],
  templateUrl: './ingredient-detailed.component.html',
  styleUrl: './ingredient-detailed.component.scss'
})
export class IngredientDetailedComponent implements OnInit {
  private activatedRoute = inject(ActivatedRoute);
  private ingredientsService = inject(IngredientsService);
  private dialogService = inject(MatDialog);
  id: string | null | undefined;
  ingredient: IngredientDetailed | undefined;

  ngOnInit(): void {
    this.loadIngredient();
  }

  loadIngredient() {
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!this.id) return;
    this.ingredientsService.getIngredient(+this.id).subscribe(
      {
        next: response => this.ingredient = response,
        error: err => console.error(err)
      }
    );
  }

  openDialog() {
    this.dialogService.open(ConfirmDeleteDialogComponent, {
      minWidth: '400px',
      data: {
        title: 'Delete ingredient',
        message: 'Are you sure you want to delete this ingredient?',
        id: this.id
      }
    });
  }

}
