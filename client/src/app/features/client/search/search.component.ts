import { Component, inject, OnInit } from '@angular/core';
import { PlaylistService } from '../../../core/services/playlist.service';
import { SongService } from '../../../core/services/song.service';
import { SingerService } from '../../../core/services/singer.service';
import { Playlist, PlaylistParams } from '../../../shared/models/playlist';
import { Pagination } from '../../../shared/models/pagination';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { ActivatedRoute, Router } from '@angular/router';
import { Song, SongParams } from '../../../shared/models/song';
import { Singer, SingerParams } from '../../../shared/models/singer';
import { NzEmptyModule } from 'ng-zorro-antd/empty';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [
    NzCardModule,
    NzGridModule,
    NzListModule,
    NzPaginationModule,
    NzEmptyModule,
  ],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent implements OnInit {
  private playlistService = inject(PlaylistService);
  private songService = inject(SongService);
  private singerService = inject(SingerService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  search = '';

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.playlistPrm.pageSize = 4;
      this.songPrm.pageSize = 4;
      this.singerPrm.pageSize = 4;
      this.search = params['q'] || '';
      this.loadPaylists();
      this.loadSongs();
      this.loadSingers();
    });
  }

  // playlist
  playlists: Playlist[] = [];
  playlistPrm = new PlaylistParams();
  playlistPagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadPaylists() {
    this.playlistPrm.searchTerm = this.search;
    this.playlistService.getPlaylistsPublic(this.playlistPrm).subscribe({
      next: (response) => {
        this.playlists = response.result as Playlist[];
        this.playlistPagination = response.pagination as Pagination;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  onPlaylistPageIndexChange(newPageNumber: number) {
    this.playlistPrm.pageNumber = newPageNumber;
    this.loadPaylists();
  }

  onPlaylistPageSizeChange(newPageSize: number) {
    this.playlistPrm.pageSize = newPageSize;
    this.loadPaylists();
  }

  openPlaylistDetail(playlistId: number) {
    this.router.navigate(['/playlist', playlistId]);
  }

  // song
  songs: Song[] = [];
  songPrm = new SongParams();
  songPagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadSongs() {
    this.songPrm.searchTerm = this.search;
    this.songService.getSongs(this.songPrm).subscribe({
      next: (response) => {
        this.songs = response.result as Song[];
        this.songPagination = response.pagination as Pagination;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  onSongPageIndexChange(newPageNumber: number) {
    this.songPrm.pageNumber = newPageNumber;
    this.loadSongs();
  }

  onSongPageSizeChange(newPageSize: number) {
    this.songPrm.pageSize = newPageSize;
    this.loadSongs();
  }

  openSongDetail(songId: number) {
    this.router.navigate(['/song', songId]);
  }

  //singer
  singers: Singer[] = [];
  singerPrm = new SingerParams();
  singerPagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadSingers() {
    this.singerPrm.searchTerm = this.search;
    this.singerService.getSingers(this.singerPrm).subscribe({
      next: (response) => {
        this.singers = response.result as Singer[];
        this.singerPagination = response.pagination as Pagination;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  onSingerPageIndexChange(newPageNumber: number) {
    this.singerPrm.pageNumber = newPageNumber;
    this.loadSingers();
  }

  onSingerPageSizeChange(newPageSize: number) {
    this.singerPrm.pageSize = newPageSize;
    this.loadSingers();
  }

  openSingerDetail(singerId: number) {
    this.router.navigate(['/singer', singerId]);
  }
}
