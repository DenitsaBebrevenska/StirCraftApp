import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { CookParams } from '../../shared/models/cook/cookParams';
import { CookShort } from '../../shared/models/cook/cookShort';
import { CookDetailed } from '../../shared/models/cook/cookDetailed';
import { Pagination } from '../../shared/models/pagination';
import { CookRankLeaderBoard } from '../../shared/models/cook/cookRankLeaderBoard';

@Injectable({
  providedIn: 'root'
})
export class CooksService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getCooks(cookParams: CookParams) {
    let httpParams = new HttpParams();

    if (cookParams.sort) {
      httpParams = httpParams.append('sort', cookParams.sort);
    }

    if (cookParams.cookName) {
      httpParams = httpParams.append('cookName', cookParams.cookName);
    }

    httpParams = httpParams.append('pageIndex', cookParams.pageIndex);
    httpParams = httpParams.append('pageSize', cookParams.pageSize);

    return this.http.get<Pagination<CookShort>>(this.baseUrl + 'cooks', { params: httpParams });
  }

  getCook(id: number) {
    return this.http.get<CookDetailed>(this.baseUrl + 'cooks/' + id);
  }

  getTopTenCooks() {
    return this.http.get<Pagination<CookRankLeaderBoard>>(this.baseUrl + 'cooks/top/10');
  }


}
