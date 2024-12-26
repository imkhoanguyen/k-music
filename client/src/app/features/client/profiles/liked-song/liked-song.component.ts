import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzTableModule } from 'ng-zorro-antd/table';
import { Song, SongParams } from '../../../../shared/models/song';
import { Pagination } from '../../../../shared/models/pagination';
import { AccountService } from '../../../../core/services/account.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { Router } from '@angular/router';
import { Singer } from '../../../../shared/models/singer';
import { MusicPlayerService } from '../../../../core/services/music-player.service';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { MessageService } from '../../../../core/services/message.service';

@Component({
  selector: 'app-liked-song',
  standalone: true,
  imports: [
    CommonModule,
    NzImageModule,
    NzTableModule,
    NzIconModule,
    NzButtonModule,
    NzPaginationModule,
  ],
  templateUrl: './liked-song.component.html',
  styleUrl: './liked-song.component.css',
})
export class LikedSongComponent implements OnInit {
  songs: Song[] = [];
  songParams = new SongParams();
  private accountService = inject(AccountService);
  private utilService = inject(UtilityService);
  private router = inject(Router);
  private musicPlayerService = inject(MusicPlayerService);
  private messageService = inject(MessageService);
  ngOnInit(): void {
    this.loadSongs();
  }

  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadSongs() {
    this.accountService.getSongLiked(this.songParams).subscribe({
      next: (paginationResult) => {
        this.songs = paginationResult.result as Song[];
        this.pagination = paginationResult.pagination as Pagination;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  onPageIndexChange(newPageNumber: number) {
    this.songParams.pageNumber = newPageNumber;
    this.loadSongs();
  }

  onPageSizeChange(newPageSize: number) {
    this.songParams.pageSize = newPageSize;
    this.loadSongs();
  }

  playSong(song: Song) {
    if (song) {
      this.musicPlayerService.playSong(song);
    }
  }

  playList(list: Song[]) {
    if (list) {
      this.musicPlayerService.playList(list);
    }
  }

  goSingerDetail(singer: Singer) {
    this.router.navigate(['/singer', singer.id]);
  }

  goSongDetail(songId: number) {
    this.router.navigate(['/song', songId]);
  }

  unLikeSong(songId: number) {
    this.accountService.unLikeSong(songId).subscribe({
      next: (_) => {
        const index = this.songs.findIndex((s) => s.id == songId);
        if (index !== -1) {
          this.songs.splice(index, 1);
          this.messageService.showSuccess('Bỏ thích bài hát thành công');
        }
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  audioDurations: { [id: string]: string } = {};
  onMetadataLoaded(event: Event, songId: number): void {
    const audioElement = event.target as HTMLAudioElement;
    this.audioDurations[songId] = this.utilService.formatDuration(
      audioElement.duration
    );
  }
}
