import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Singer, SingerParams } from '../../shared/models/singer';
import { PaginatedResult } from '../../shared/models/pagination';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SingerService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  private paginationResult: PaginatedResult<Singer[]> = new PaginatedResult<
    Singer[]
  >();

  getSingers(singerParams: SingerParams) {
    let params = new HttpParams();
    params = params.append('pageNumber', singerParams.pageNumber);
    params = params.append('pageSize', singerParams.pageSize);
    params = params.append('orderBy', singerParams.orderBy);

    // quan trọng mất là lỗi liền :)
    if (singerParams.searchTerm) {
      params = params.append('search', singerParams.searchTerm);
    }

    if (singerParams.gender) {
      params = params.append('gender', singerParams.gender);
    }

    if (singerParams.location) {
      params = params.append('location', singerParams.location);
    }

    return this.http
      .get<Singer[]>(this.baseUrl + 'singer', { observe: 'response', params })
      .pipe(
        map((response) => {
          this.paginationResult.result = response.body as Singer[];
          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            this.paginationResult.pagination = JSON.parse(pagination);
          }
          return this.paginationResult;
        })
      );
  }

  addSinger(formData: FormData) {
    return this.http.post<Singer>(this.baseUrl + 'singer', formData);
  }

  updateSinger(id: number, formData: FormData) {
    return this.http.put<Singer>(this.baseUrl + `singer/${id}`, formData);
  }

  deleteSinger(id: number) {
    return this.http.delete(this.baseUrl + `singer/${id}`);
  }

  getLocations() {
    return this.http.get<string[]>(this.baseUrl + 'singer/locations');
  }

  getAllSinger() {
    return this.http.get<Singer[]>(this.baseUrl + 'singer/get-all');
  }
}
