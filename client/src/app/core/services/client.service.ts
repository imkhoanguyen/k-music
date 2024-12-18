import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PaginatedResult } from '../../shared/models/pagination';
import { Playlist, PlaylistParams } from '../../shared/models/playlist';
import { map } from 'rxjs';
import { Song, SongParams } from '../../shared/models/song';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getPlaylists(prm: PlaylistParams) {
    let paginationResult: PaginatedResult<Playlist[]> = new PaginatedResult<
      Playlist[]
    >();
    let params = new HttpParams();
    params = params.append('pageNumber', prm.pageNumber);
    params = params.append('pageSize', prm.pageSize);
    params = params.append('orderBy', prm.orderBy);

    if (prm.searchTerm) {
      params = params.append('search', prm.searchTerm);
    }

    return this.http
      .get<Playlist[]>(this.baseUrl + 'client/get-all-playlist', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          paginationResult.result = response.body as Playlist[];

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            paginationResult.pagination = JSON.parse(pagination);
          }
          return paginationResult;
        })
      );
  }

  getSongs(songParams: SongParams) {
    let paginationResult: PaginatedResult<Song[]> = new PaginatedResult<
      Song[]
    >();
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
          paginationResult.result = response.body as Song[];

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            paginationResult.pagination = JSON.parse(pagination);
          }
          return paginationResult;
        })
      );
  }
}
