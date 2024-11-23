import { Component, inject, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CooksService } from '../../../core/services/cooks.service';
import { CookRankLeaderBoard } from '../../../shared/models/cook/cookRankLeaderBoard';


@Component({
  selector: 'app-leaderboard',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './leaderboard.component.html',
  styleUrl: './leaderboard.component.scss'
})

export class LeaderboardComponent implements OnInit {
  private cooksService = inject(CooksService);
  topTenCooks?: CookRankLeaderBoard[];

  ngOnInit() {
    this.getTopTenCooks();
  }

  getTopTenCooks(){
    this.cooksService.getTopTenCooks().subscribe({
      next: response => this.topTenCooks = response.data,
      error: error => console.log(error)
    });
  }
}
