import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Genre, GenreParams } from '../../shared/models/genre';
import { map } from 'rxjs/internal/operators/map';
import { PaginatedResult } from '../../shared/models/pagination';

@Injectable({
  providedIn: 'root',
})
export class GenreService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  private paginationResult: PaginatedResult<Genre[]> = new PaginatedResult<
    Genre[]
  >();

  getGenres(genreParams: GenreParams) {
    let params = new HttpParams();
    params = params.append('pageNumber', genreParams.pageNumber);
    params = params.append('pageSize', genreParams.pageSize);
    params = params.append('orderBy', genreParams.orderBy);

    // quan trọng mất là lỗi liền :)
    if (genreParams.searchTerm) {
      params = params.append('search', genreParams.searchTerm);
    }

    return this.http
      .get<Genre[]>(this.baseUrl + 'genre', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          this.paginationResult.result = response.body as Genre[];

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            this.paginationResult.pagination = JSON.parse(pagination);
          }
          return this.paginationResult;
        })
      );
  }

  addGenre(genre: Genre) {
    return this.http.post<Genre>(this.baseUrl + 'genre', genre);
  }

  updateGenre(genreId: number, genre: Genre) {
    return this.http.put(this.baseUrl + `genre/${genreId}`, genre);
  }

  deleteGenre(genreId: number) {
    return this.http.delete(this.baseUrl + `genre/${genreId}`);
  }

  getAllGenre() {
    return this.http.get<Genre[]>(this.baseUrl + 'genre/get-all');
  }
}