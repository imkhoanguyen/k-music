import { Component, inject, OnInit } from '@angular/core';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzTableModule } from 'ng-zorro-antd/table';
import { AccountService } from '../../../../core/services/account.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { Router } from '@angular/router';
import { MessageService } from '../../../../core/services/message.service';
import { Playlist, PlaylistParams } from '../../../../shared/models/playlist';
import { Pagination } from '../../../../shared/models/pagination';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { Song } from '../../../../shared/models/song';
import { MusicPlayerService } from '../../../../core/services/music-player.service';
import { PlaylistService } from '../../../../core/services/playlist.service';

@Component({
  selector: 'app-liked-playlist',
  standalone: true,
  imports: [
    NzTableModule,
    NzPaginationModule,
    NzButtonModule,
    NzIconModule,
    NzImageModule,
  ],
  templateUrl: './liked-playlist.component.html',
  styleUrl: './liked-playlist.component.css',
})
export class LikedPlaylistComponent implements OnInit {
  private accountService = inject(AccountService);
  private router = inject(Router);
  private messageService = inject(MessageService);
  private playlistService = inject(PlaylistService);
  private musicPlayerService = inject(MusicPlayerService);

  ngOnInit(): void {
    this.loadPaylists();
  }

  playlists: Playlist[] = [];
  prm = new PlaylistParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadPaylists() {
    this.accountService.getPlaylistLiked(this.prm).subscribe({
      next: (response) => {
        this.playlists = response.result as Playlist[];
        this.pagination = response.pagination as Pagination;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  onPageIndexChange(newPageNumber: number) {
    this.prm.pageNumber = newPageNumber;
    this.loadPaylists();
  }

  onPageSizeChange(newPageSize: number) {
    this.prm.pageSize = newPageSize;
    this.loadPaylists();
  }

  onSortChange(sortBy: string) {
    const currentSort = this.prm.orderBy;

    if (currentSort === sortBy) {
      this.prm.orderBy = `${sortBy}_desc`;
    } else if (currentSort === `${sortBy}_desc`) {
      this.prm.orderBy = sortBy;
    } else {
      this.prm.orderBy = sortBy;
    }
    this.loadPaylists();
  }

  unLikePlaylist(playlistId: number) {
    this.accountService.unLikePlaylist(playlistId).subscribe({
      next: (_) => {
        const index = this.playlists.findIndex((p) => p.id == playlistId);
        if (index !== -1) {
          this.playlists.splice(index, 1);
          this.messageService.showSuccess('Bỏ thích danh sách phát thành công');
        }
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  goDetail(playlistId: number) {
    this.router.navigate(['playlist', playlistId]);
  }

  playList(playlistId: number) {
    this.playlistService.getPlaylist(playlistId).subscribe({
      next: (res) => {
        if (res.songList) {
          this.musicPlayerService.playList(res.songList);
        }
      },
      error: (er) => {
        this.messageService.showError(
          'Không thể phát lúc này vui lòng thử lại sau'
        );
      },
    });
  }
}
