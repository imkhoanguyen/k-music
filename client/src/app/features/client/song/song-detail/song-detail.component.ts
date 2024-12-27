import { CommonModule } from '@angular/common';
import { Component, inject, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
import { Singer } from '../../../../shared/models/singer';
import { QuickAddComponent } from '../../playlist/quick-add/quick-add.component';

@Component({
  selector: 'app-song-detail',
  standalone: true,
  imports: [
    CommonModule,
    NzTypographyModule,
    NzImageModule,
    NzIconModule,
    NzButtonModule,
    QuickAddComponent
],
  templateUrl: './song-detail.component.html',
  styleUrl: './song-detail.component.css',
})
export class SongDetailComponent {
  songId: number = 0;
  private route = inject(ActivatedRoute);
  private songServices = inject(SongService);
  private messageService = inject(MessageService);
  private accountService = inject(AccountService);
  private router = inject(Router);
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
      error: (er) => this.messageService.showError(er),
    });
  }

  playSong() {
    if (this.song) {
      this.musicPlayerService.playSong(this.song);
    }
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

  likeSong(songId: number) {
    this.accountService.likeSong(songId).subscribe({
      next: (_) => {
        this.messageService.showSuccess('Bài hát đã được lưu vào mục thích');
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
        this.messageService.showSuccess('Bỏ thích bài hát thành công');
        this.isLiked = false;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  goSingerDetail(singer: Singer) {
    this.router.navigate(['/singer', singer.id]);
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
