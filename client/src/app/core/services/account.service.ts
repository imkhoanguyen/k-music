import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

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
}
