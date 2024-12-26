import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Song, SongParams } from '../../shared/models/song';
import { PaginatedResult } from '../../shared/models/pagination';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;

  likeSong(songId: number) {
    return this.http.post(this.baseUrl + 'account/like-song', { songId });
  }

  unLikeSong(songId: number) {
    return this.http.post(this.baseUrl + 'account/unlike-song', { songId });
  }

  checkLikeSong(songId: number) {
    return this.http.post<boolean>(this.baseUrl + 'account/check-like-song', {
      songId,
    });
  }

  likeSinger(singerId: number) {
    return this.http.post(this.baseUrl + 'account/like-singer', { singerId });
  }

  unLikeSinger(singerId: number) {
    return this.http.post(this.baseUrl + 'account/unlike-singer', { singerId });
  }

  checkLikeSinger(singerId: number) {
    return this.http.post<boolean>(this.baseUrl + 'account/check-like-singer', {
      singerId,
    });
  }

  likePlaylist(playlistId: number) {
    return this.http.post(this.baseUrl + 'account/like-playlist', {
      playlistId,
    });
  }

  unLikePlaylist(playlistId: number) {
    return this.http.post(this.baseUrl + 'account/unlike-playlist', {
      playlistId,
    });
  }

  checkLikePlaylist(playlistId: number) {
    return this.http.post<boolean>(
      this.baseUrl + 'account/check-like-playlist',
      {
        playlistId,
      }
    );
  }

  getSongLiked(songParams: SongParams) {
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
      .get<Song[]>(this.baseUrl + 'account/get-song-liked', {
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
