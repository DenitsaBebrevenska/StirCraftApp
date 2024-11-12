import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from '../../shared/models/user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  currentUser = signal<User | null>(null);

 logIn(values: any){
  let params = new HttpParams();
  params = params.append('useCookies', true);
  return this.http.post<User>(this.baseUrl + 'login', values, { params });
 }

 register(values: any){
  return this.http.post(this.baseUrl + 'account/register', values);
 }

 getCurrentUserInfo(){
  return this.http.get<User>(this.baseUrl + 'account/user-info')
  .pipe(
    map(user => {
      this.currentUser.set(user);
      return user;
    })
  ); 
 }

 logout(){
  return this.http.post(this.baseUrl + 'account/logout', {});
 }
}
