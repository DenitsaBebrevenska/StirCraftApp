import { Component } from '@angular/core';
import {MatButton} from '@angular/material/button'
import { RouterLink, RouterLinkActive } from '@angular/router';
import { MatProgressBar } from '@angular/material/progress-bar';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    MatButton,
    MatProgressBar
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

}
