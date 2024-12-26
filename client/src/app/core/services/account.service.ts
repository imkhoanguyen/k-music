import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Song, SongParams } from '../../shared/models/song';
import { PaginatedResult } from '../../shared/models/pagination';
import { map } from 'rxjs';
import { Playlist, PlaylistParams } from '../../shared/models/playlist';
import { Singer, SingerParams } from '../../shared/models/singer';

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

  getPlaylistLiked(prm: PlaylistParams) {
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
      .get<Playlist[]>(this.baseUrl + 'account/get-playlist-liked', {
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

  getSingerLiked(singerParams: SingerParams) {
    let paginationResult: PaginatedResult<Singer[]> = new PaginatedResult<
      Singer[]
    >();
    let params = new HttpParams();
    params = params.append('pageNumber', singerParams.pageNumber);
    params = params.append('pageSize', singerParams.pageSize);
    params = params.append('orderBy', singerParams.orderBy);

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
      .get<Singer[]>(this.baseUrl + 'account/get-singer-liked', {
        observe: 'response',
        params,
      })
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
}
