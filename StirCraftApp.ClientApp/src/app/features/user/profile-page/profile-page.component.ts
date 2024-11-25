import { Component, inject, OnInit } from '@angular/core';
import { UserProfile } from '../../../shared/models/user/userProfile';
import { UserService } from '../../../core/services/user.service';
import { RouterLink } from '@angular/router';

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
  private userService = inject(UserService);
  user: UserProfile | undefined;

  ngOnInit(): void {
    this.loadUser();
  }

  loadUser(){
    this.userService.getUserProfile().subscribe({
      next: response => this.user = response,
      error: err => console.log(err)
    });
  }

  changeAvatar(){
    console.log("Change Avatar");
  }

}
