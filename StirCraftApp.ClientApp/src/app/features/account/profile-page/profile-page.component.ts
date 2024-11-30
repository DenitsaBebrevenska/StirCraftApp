import { Component, inject, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AccountService } from '../../../core/services/account.service';
import { UserInfo } from '../../../shared/models/user/userInfo';

@Component({
  selector: 'app-profile-page',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './profile-page.component.html',
  styleUrl: './profile-page.component.scss'
})
export class ProfilePageComponent implements OnInit {
  private accountService = inject(AccountService);
  user: UserInfo | undefined;

  ngOnInit(): void {
    this.loadUser();
  }

  loadUser(){
    this.accountService.getCurrentUserInfo().subscribe({
      next: response => this.user = response,
      error: err => console.log(err)
    });
  }

  changeAvatar(){
    console.log("Change Avatar");
  }

}
