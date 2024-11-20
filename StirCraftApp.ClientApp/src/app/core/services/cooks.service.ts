import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { CookParams } from '../../shared/models/cookParams';
import { CookShort } from '../../shared/models/cookShort';
import { CookDetailed } from '../../shared/models/cookDetailed';
import { Pagination } from '../../shared/models/pagination';
import { CookRankLeaderBoard } from '../../shared/models/cookRankLeaderBoard';

@Injectable({
  providedIn: 'root'
})
export class CooksService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  
  getCooks(cookParams: CookParams) {
    let httpParams = new HttpParams();

    if(cookParams.sort) {
      httpParams = httpParams.append('sort', cookParams.sort);
    }

    httpParams = httpParams.append('pageIndex', cookParams.pageIndex);
    httpParams = httpParams.append('pageSize', cookParams.pageSize);

    return this.http.get<Pagination<CookShort>>(this.baseUrl + 'cooks', { params: httpParams });
  }

  getCook(id: number) {
    return this.http.get<CookDetailed>(this.baseUrl + 'cooks/' + id);
  }

  getTopTenCooks(){
    return this.http.get<Pagination<CookRankLeaderBoard>>(this.baseUrl + 'cooks/top/10');
  }
}
