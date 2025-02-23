import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetSEOIndexesQuery } from '../models/get-seo-indexes-query.model';
import { BaseResponse } from '../models/base-response.model';

@Injectable({
  providedIn: 'root'
})
export class SEOMonitorService {
  private readonly apiUrl = 'http://localhost:5001/api/SEOMonitor';

  constructor(private http: HttpClient) { }

  getSeoIndexes(query: GetSEOIndexesQuery): Observable<BaseResponse<number[]>> {
    let params = new HttpParams()
      .set('searchEngineType', query.searchEngineType.toString());

    if (query.keyword) {
      params = params.set('keyword', query.keyword);
    }

    if (query.targetWebsite) {
      params = params.set('targetWebsite', query.targetWebsite);
    }

    return this.http.get<BaseResponse<number[]>>(
      `${this.apiUrl}/GetSeoIndexes`,
      {
        params,
        headers: {
          'Accept': 'application/json'
        }
      }
    );
  }
}