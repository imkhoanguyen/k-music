import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import {
  AddOrDeleteRequest,
  Playlist,
  PlaylistDetail,
  PlaylistParams,
  QuickViewResponse,
} from '../../shared/models/playlist';
import { PaginatedResult } from '../../shared/models/pagination';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PlaylistService {
  private baseUrl = `${environment.apiUrl}admin/`;
  private customerUrl = environment.apiUrl;
  private http = inject(HttpClient);
  private paginationResult: PaginatedResult<Playlist[]> = new PaginatedResult<
    Playlist[]
  >();

  getPlaylists(prm: PlaylistParams) {
    let params = new HttpParams();
    params = params.append('pageNumber', prm.pageNumber);
    params = params.append('pageSize', prm.pageSize);
    params = params.append('orderBy', prm.orderBy);

    if (prm.searchTerm) {
      params = params.append('search', prm.searchTerm);
    }

    return this.http
      .get<Playlist[]>(this.baseUrl + 'playlist', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          this.paginationResult.result = response.body as Playlist[];

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            this.paginationResult.pagination = JSON.parse(pagination);
          }
          return this.paginationResult;
        })
      );
  }

  getPlaylist(id: number) {
    return this.http.get<PlaylistDetail>(this.baseUrl + `playlist/${id}`);
  }

  addPlaylist(frmDt: FormData) {
    return this.http.post<Playlist>(this.baseUrl + 'playlist', frmDt);
  }

  updatePlaylist(id: number, frmDt: FormData) {
    return this.http.put<Playlist>(this.baseUrl + `playlist/${id}`, frmDt);
  }

  addAutoPlaylist(frmDt: FormData) {
    return this.http.post<Playlist>(this.baseUrl + 'playlist/add-auto', frmDt);
  }

  deleteSongs(playlistId: number, songIdList: number[]) {
    return this.http.delete(
      this.baseUrl + `playlist/${playlistId}/delete-song`,
      {
        body: songIdList,
      }
    );
  }

  addSongs(playlistId: number, songIdList: number[]) {
    return this.http.post<PlaylistDetail>(
      `${this.baseUrl}playlist/${playlistId}/add-song`,
      songIdList
    );
  }

  deletePlaylist(playlistId: number) {
    return this.http.delete(this.baseUrl + `playlist/${playlistId}`);
  }

  getQuickViewPlaylist(prm: PlaylistParams, songId: number) {
    let paginationResult: PaginatedResult<QuickViewResponse[]> =
      new PaginatedResult<QuickViewResponse[]>();
    let params = new HttpParams();
    params = params.append('pageNumber', prm.pageNumber);
    params = params.append('pageSize', prm.pageSize);
    params = params.append('orderBy', prm.orderBy);
    params = params.append('songId', songId);
    if (prm.searchTerm) {
      params = params.append('search', prm.searchTerm);
    }

    return this.http
      .get<QuickViewResponse[]>(
        this.customerUrl + 'playlist/get-quickview-playlist',
        {
          observe: 'response',
          params,
        }
      )
      .pipe(
        map((response) => {
          paginationResult.result = response.body as QuickViewResponse[];

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            paginationResult.pagination = JSON.parse(pagination);
          }
          return paginationResult;
        })
      );
  }

  AddOrDelete(request: AddOrDeleteRequest) {
    return this.http.post<boolean>(
      this.customerUrl + 'playlist/add-or-delete-song',
      request
    );
  }
}
