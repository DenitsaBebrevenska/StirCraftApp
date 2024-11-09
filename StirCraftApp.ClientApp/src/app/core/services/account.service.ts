import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { User } from '../../shared/models/user';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  currentUser = signal<User | null>(null);

  /* login(values: any) {
    return this.http.post(this.baseUrl + 'account/login', values).pipe(
      map((user: User) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUser.next(user);
        }
      })
    );
  } */
}
