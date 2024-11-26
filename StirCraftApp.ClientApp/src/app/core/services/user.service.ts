import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { UserProfile } from '../../shared/models/user/userInfo';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getUserProfile(){
    return this.http.get<UserProfile>(this.baseUrl + 'user/profile');
  }
}
