import { Component, inject, Input, OnInit } from '@angular/core';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { Router } from '@angular/router';
import { Song, SongParams } from '../../../../shared/models/song';
import { Pagination } from '../../../../shared/models/pagination';
import { Genre } from '../../../../shared/models/genre';
import { CommonModule } from '@angular/common';
import { SongService } from '../../../../core/services/song.service';

@Component({
  selector: 'app-song-list',
  standalone: true,
  imports: [
    NzCardModule,
    NzGridModule,
    NzListModule,
    NzPaginationModule,
    CommonModule,
  ],
  templateUrl: './song-list.component.html',
  styleUrl: './song-list.component.css',
})
export class SongListComponent implements OnInit {
  private songService = inject(SongService);
  private router = inject(Router);

  ngOnInit(): void {
    this.loadSongs();
  }
  genres: Genre[] = [];
  selectedGenre = 0;
  selectGenre(id: number) {
    this.selectedGenre = id;
    if (this.selectedGenre >= 1) {
      this.prm.genreList = [this.selectedGenre];
    } else {
      this.prm.genreList = [];
    }
    this.loadSongs();
  }

  // *********************************************************************
  // load song, sort, paging, search ...
  songs: Song[] = [];
  prm = new SongParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadSongs() {
    this.songService.getSongs(this.prm).subscribe({
      next: (response) => {
        this.songs = response.result as Song[];
        this.pagination = response.pagination as Pagination;
        const allGenres = this.songs.flatMap((song) => song.genres);
        const uniqueGenres = Array.from(
          new Map(allGenres.map((genre) => [genre.id, genre])).values()
        );

        this.genres = uniqueGenres;
        console.log(this.genres);
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  onPageIndexChange(newPageNumber: number) {
    this.prm.pageNumber = newPageNumber;
    this.loadSongs();
  }

  onPageSizeChange(newPageSize: number) {
    this.prm.pageSize = newPageSize;
    this.loadSongs();
  }

  openSongDetail(songId: number) {
    this.router.navigate(['/song', songId]);
  }
}
