import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Playlist, PlaylistParams } from '../../shared/models/playlist';
import { PaginatedResult } from '../../shared/models/pagination';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PlaylistService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  private paginationResult: PaginatedResult<Playlist[]> = new PaginatedResult<
    Playlist[]
  >();

  getPlaylists(prm: PlaylistParams) {
    let params = new HttpParams();
    params = params.append('pageNumber', prm.pageNumber);
    params = params.append('pageSize', prm.pageSize);
    params = params.append('orderBy', prm.orderBy);

    // quan trọng mất là lỗi liền :)
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
    return this.http.get<Playlist>(this.baseUrl + `playlist/${id}`);
  }

  addPlaylist(frmDt: FormData) {
    return this.http.post<Playlist>(this.baseUrl + 'playlist', frmDt);
  }

  updatePlaylist(id: number, frmDt: FormData) {
    return this.http.put<Playlist>(this.baseUrl + `playlist/${id}`, frmDt);
  }
}
