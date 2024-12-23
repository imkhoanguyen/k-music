import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Song, SongParams } from '../../shared/models/song';
import { PaginatedResult, Pagination } from '../../shared/models/pagination';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SongService {
  private http = inject(HttpClient);
  private baseUrl = `${environment.apiUrl}admin/`;
  private paginationResult: PaginatedResult<Song[]> = new PaginatedResult<
    Song[]
  >();

  getSongs(songParams: SongParams) {
    let params = new HttpParams();
    params = params.append('pageNumber', songParams.pageNumber);
    params = params.append('pageSize', songParams.pageSize);
    params = params.append('orderBy', songParams.orderBy);

    if (songParams.searchTerm) {
      params = params.append('search', songParams.searchTerm);
    }

    if (songParams.genreList && songParams.genreList.length > 0) {
      songParams.genreList.forEach((genreId: number) => {
        params = params.append('genreList', genreId.toString());
      });
    }

    return this.http
      .get<Song[]>(this.baseUrl + 'song', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          this.paginationResult.result = response.body as Song[];

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            this.paginationResult.pagination = JSON.parse(pagination);
          }
          return this.paginationResult;
        })
      );
  }

  addSong(formData: FormData) {
    return this.http.post<Song>(this.baseUrl + 'song', formData);
  }

  updateSong(songId: number, formData: FormData) {
    return this.http.put<Song>(this.baseUrl + `song/${songId}`, formData);
  }

  deleteSong(songId: number) {
    return this.http.delete(this.baseUrl + `song/${songId}`);
  }

  updateSongVip(songId: number, vip: boolean) {
    return this.http.put(this.baseUrl + `song/update-vip/${songId}`, vip);
  }

  getSong(songId: number) {
    return this.http.get<Song>(this.baseUrl + `song/${songId}`);
  }
}
