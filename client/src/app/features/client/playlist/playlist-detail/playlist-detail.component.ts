import { Component, inject, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { MessageService } from '../../../../core/services/message.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { PlaylistDetail1 } from '../../../../shared/models/playlist';
import { CommonModule } from '@angular/common';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { MusicPlayerService } from '../../../../core/services/music-player.service';
import { Song } from '../../../../shared/models/song';
import { AccountService } from '../../../../core/services/account.service';
import { Singer } from '../../../../shared/models/singer';
import { QuickAddComponent } from '../quick-add/quick-add.component';
import { CommentComponent } from '../../comments/comment/comment.component';

@Component({
  selector: 'app-playlist-detail',
  standalone: true,
  imports: [
    CommonModule,
    NzImageModule,
    NzTableModule,
    NzIconModule,
    NzButtonModule,
    QuickAddComponent,
    CommentComponent,
  ],
  templateUrl: './playlist-detail.component.html',
  styleUrl: './playlist-detail.component.css',
})
export class PlaylistDetailComponent implements OnInit {
  playlistId: number = 0;
  private route = inject(ActivatedRoute);
  private playlistService = inject(PlaylistService);
  private messageService = inject(MessageService);
  private musicPlayerService = inject(MusicPlayerService);
  private accountService = inject(AccountService);
  private router = inject(Router);
  utilService = inject(UtilityService);
  playlist: PlaylistDetail1 | undefined;
  isLiked = false;

  expandSet = new Set<number>();
  onExpandChange(id: number, checked: boolean): void {
    if (checked) {
      this.expandSet.add(id);
    } else {
      this.expandSet.delete(id);
    }
  }

  audioDurations: { [id: string]: string } = {};

  onMetadataLoaded(event: Event, songId: number): void {
    const audioElement = event.target as HTMLAudioElement;
    this.audioDurations[songId] = this.utilService.formatDuration(
      audioElement.duration
    );
  }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.playlistId = +params['id']; // Lấy lại singerId từ route
      this.loadPlaylist(); // Gọi lại hàm khi tham số route thay đổi
      this.checkLikePlaylist();
    });
  }

  loadPlaylist() {
    this.playlistService.getPlaylistHaveLike(this.playlistId).subscribe({
      next: (res) => {
        console.log(res);
        this.playlist = res;
      },
      error: (er) => this.messageService.showError(er),
    });
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

  checkLikePlaylist() {
    this.accountService.checkLikePlaylist(this.playlistId).subscribe({
      next: (res) => {
        this.isLiked = res;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  likePlaylist(playlistId: number) {
    this.accountService.likePlaylist(playlistId).subscribe({
      next: (_) => {
        this.messageService.showSuccess(
          'Danh sách phát đã được lưu vào mục thích'
        );
        this.isLiked = true;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  unLikePlaylist(playlistId: number) {
    this.accountService.unLikePlaylist(playlistId).subscribe({
      next: (_) => {
        this.messageService.showSuccess('Bỏ thích danh sách phát thành công');
        this.isLiked = false;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  likeSong(songId: number) {
    this.accountService.likeSong(songId).subscribe({
      next: (_) => {
        const index = this.playlist?.songList.findIndex((s) => s.id == songId);
        if (
          index !== undefined &&
          index !== -1 &&
          this.playlist?.songList[index]
        ) {
          this.messageService.showSuccess('Bài hát đã được lưu vào mục thích');
          this.playlist.songList[index].liked = true;
        }
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  unLikeSong(songId: number) {
    this.accountService.unLikeSong(songId).subscribe({
      next: (_) => {
        const index = this.playlist?.songList.findIndex((s) => s.id == songId);
        if (
          index !== undefined &&
          index !== -1 &&
          this.playlist?.songList[index]
        ) {
          this.messageService.showSuccess('Bỏ thích bài hát thành công');
          this.playlist.songList[index].liked = false;
        }
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  goSingerDetail(singer: Singer) {
    this.router.navigate(['/singer', singer.id]);
  }

  goSongDetail(songId: number) {
    this.router.navigate(['/song', songId]);
  }

  @ViewChild(QuickAddComponent)
  quickAddComponent!: QuickAddComponent;
  openQuickAdd(songId: number) {
    if (this.quickAddComponent) {
      this.quickAddComponent.songId = songId;
      this.quickAddComponent.showModal();
    } else {
      console.error('QuickAddComponent is not initialized yet');
    }
  }
}
