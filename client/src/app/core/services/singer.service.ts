import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import {
  Singer,
  SingerDetail,
  SingerDetail1,
  SingerParams,
} from '../../shared/models/singer';
import { PaginatedResult } from '../../shared/models/pagination';
import { map } from 'rxjs';
import { Song, SongHaveLike, SongParams } from '../../shared/models/song';

@Injectable({
  providedIn: 'root',
})
export class SingerService {
  private baseUrl = `${environment.apiUrl}admin/`;
  private customerUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getSingers(singerParams: SingerParams) {
    let paginationResult: PaginatedResult<Singer[]> = new PaginatedResult<
      Singer[]
    >();
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
          paginationResult.result = response.body as Singer[];
          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            paginationResult.pagination = JSON.parse(pagination);
          }
          return paginationResult;
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

  getSingerDetail(id: number, prm: SongParams) {
    let paginationResult: PaginatedResult<Song[]> = new PaginatedResult<
      Song[]
    >();

    let params = new HttpParams();
    params = params.append('pageNumber', prm.pageNumber);
    params = params.append('pageSize', prm.pageSize);
    params = params.append('orderBy', prm.orderBy);

    return this.http
      .get<any>(this.baseUrl + `singer/${id}`, { observe: 'response', params })
      .pipe(
        map((response) => {
          paginationResult.result = response.body;

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            console.log('vao');
            paginationResult.pagination = JSON.parse(pagination);
          }
          let singerDetail: SingerDetail = response.body;
          singerDetail.PaginatedResult = paginationResult;
          return singerDetail;
        })
      );
  }

  getSingerDetail1(id: number, prm: SongParams) {
    let paginationResult: PaginatedResult<SongHaveLike[]> = new PaginatedResult<
      SongHaveLike[]
    >();

    let params = new HttpParams();
    params = params.append('pageNumber', prm.pageNumber);
    params = params.append('pageSize', prm.pageSize);
    params = params.append('orderBy', prm.orderBy);

    return this.http
      .get<any>(this.customerUrl + `singer/${id}`, {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          paginationResult.result = response.body;

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            console.log('vao');
            paginationResult.pagination = JSON.parse(pagination);
          }
          let singerDetail: SingerDetail1 = response.body;
          singerDetail.PaginatedResult = paginationResult;
          return singerDetail;
        })
      );
  }
}
