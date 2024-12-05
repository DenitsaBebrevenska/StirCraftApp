import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from '../../shared/models/user/user';
import { map } from 'rxjs/operators';
import { UserInfo } from '../../shared/models/user/userInfo';
import { Avatar } from '../../shared/models/user/avatar';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  currentUser = signal<UserInfo | null>(null);

  logIn(values: any) {
    let params = new HttpParams();
    params = params.append('useCookies', true);
    return this.http.post<User>(this.baseUrl + 'login', values, { params });
  }

  register(values: any) {
    return this.http.post(this.baseUrl + 'account/register', values);
  }

  getCurrentUserInfo() {
    return this.http.get<UserInfo>(this.baseUrl + 'account/user-info')
      .pipe(
        map(user => {
          this.currentUser.set(user);
          return user;
        })
      );
  }

  logout() {
    this.currentUser.set(null);
    return this.http.post(this.baseUrl + 'account/logout', {});

  }

  getAuthState() {
    return this.http.get<{ isAuthenticated: boolean }>(this.baseUrl + 'account/auth-state');
  }

  updateAvatar(avatarDto: Avatar) {
    return this.http.put(this.baseUrl + 'account/avatar', avatarDto);
  }
}
