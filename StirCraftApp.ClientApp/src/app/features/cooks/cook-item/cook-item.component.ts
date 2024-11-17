import { Component, Input } from '@angular/core';
import { CookShort } from '../../../shared/models/cookShort';
import { MatCard, MatCardContent, MatCardHeader } from '@angular/material/card';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-cook-item',
  standalone: true,
  imports: [
    MatCard,
    MatCardHeader,
    MatCardContent,
    RouterLink
  ],
  templateUrl: './cook-item.component.html',
  styleUrl: './cook-item.component.scss'
})
export class CookItemComponent {
  @Input() cook?: CookShort;
}
