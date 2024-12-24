import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzTypographyModule } from 'ng-zorro-antd/typography';
import { SongService } from '../../../../core/services/song.service';
import { MessageService } from '../../../../core/services/message.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { Song } from '../../../../shared/models/song';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { MusicPlayerService } from '../../../../core/services/music-player.service';
import { AccountService } from '../../../../core/services/account.service';

@Component({
  selector: 'app-song-detail',
  standalone: true,
  imports: [
    CommonModule,
    NzTypographyModule,
    NzImageModule,
    NzIconModule,
    NzButtonModule,
  ],
  templateUrl: './song-detail.component.html',
  styleUrl: './song-detail.component.css',
})
export class SongDetailComponent {
  songId: number = 0;
  private route = inject(ActivatedRoute);
  private songServices = inject(SongService);
  private messageServies = inject(MessageService);
  private accountService = inject(AccountService);
  utilService = inject(UtilityService);
  private musicPlayerService = inject(MusicPlayerService);
  song: Song | undefined;
  isLiked = false;

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.songId = +params['id'];
      this.loadSong();
      this.checkLikeSong();
    });
  }

  loadSong() {
    this.songServices.getSong(this.songId).subscribe({
      next: (data) => {
        this.song = data;
      },
      error: (er) => this.messageServies.showError(er),
    });
  }

  checkLikeSong() {
    this.accountService.checkLikeSong(this.songId).subscribe({
      next: (res) => {
        this.isLiked = res;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  playSong() {
    if (this.song) {
      this.musicPlayerService.playSong(this.song);
    }
  }

  likeSong(songId: number) {
    this.accountService.likeSong(songId).subscribe({
      next: (_) => {
        this.messageServies.showSuccess('Bài hát đã được lưu vào mục thích');
        this.isLiked = true;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  unLikeSong(songId: number) {
    this.accountService.unLikeSong(songId).subscribe({
      next: (_) => {
        this.messageServies.showSuccess('Bỏ thích bài hát thành công');
        this.isLiked = false;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }
}
