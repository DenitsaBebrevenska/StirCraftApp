import { Component, inject, OnInit } from '@angular/core';
import { CooksService } from '../../core/services/cooks.service';
import { CookRankLeaderBoard } from '../../shared/models/cookRankLeaderBoard';

@Component({
  selector: 'app-leaderboard',
  standalone: true,
  imports: [],
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
      next: response => this.topTenCooks = response,
      error: error => console.log(error)
    });
  }
}
