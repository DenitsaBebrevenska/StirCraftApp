import { Component, inject, OnInit } from '@angular/core';
import { CooksService } from '../../core/services/cooks.service';
import { Pagination } from '../../shared/models/pagination';
import { CookShort } from '../../shared/models/cook/cookShort';
import { CookParams } from '../../shared/models/cook/cookParams';
import { CookItemComponent } from './cook-item/cook-item.component';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { MatListOption, MatSelectionList, MatSelectionListChange } from '@angular/material/list';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-cooks',
  standalone: true,
  imports: [
    CookItemComponent,
    MatButton,
    MatIcon,
    MatMenu,
    MatListOption,
    MatSelectionList,
    MatMenuTrigger,
    MatPaginator,
    FormsModule
  ],
  templateUrl: './cooks.component.html',
  styleUrl: './cooks.component.scss'
})
export class CooksComponent implements OnInit {
  private cooksService = inject(CooksService);
  cooks?: Pagination<CookShort>;
  sortOptions = [
    { name: "Rank-Descending", value: "default" },
    { name: "Rank-Ascending", value: "rankAsc" },
    { name: "Recipe Count-Ascending", value: "recipeCountAsc" },
    { name: "Recipe Count-Descending", value: "recipeCountDesc" }
  ];

  cookParams = new CookParams();
  pageSizeOptions = [5, 10, 15, 20];

  ngOnInit(): void {
    this.initializeCooks();
  }

  initializeCooks() {
    this.getCooks();
  }

  getCooks() {
    this.cooksService.getCooks(this.cookParams)
      .subscribe({
        next: response => this.cooks = response,
        error: error => console.error(error)
      });
  }

  onSortChange(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if (selectedOption) {
      this.cookParams.sort = selectedOption.value;
      this.cookParams.pageIndex = 1;
      this.getCooks();
    }
  }

  handlePage(event: PageEvent) {
    this.cookParams.pageIndex = event.pageIndex + 1;
    this.cookParams.pageSize = event.pageSize;
    this.getCooks();
  }

  onSearchChange() {
    this.cookParams.pageIndex = 1;
    this.initializeCooks();
  }

}
