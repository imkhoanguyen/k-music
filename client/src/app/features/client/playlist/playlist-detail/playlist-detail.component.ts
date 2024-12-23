import { Component, inject, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { MessageService } from '../../../../core/services/message.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { PlaylistDetail } from '../../../../shared/models/playlist';
import { CommonModule } from '@angular/common';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { MusicPlayerService } from '../../../../core/services/music-player.service';
import { Song } from '../../../../shared/models/song';

@Component({
  selector: 'app-playlist-detail',
  standalone: true,
  imports: [
    CommonModule,
    NzImageModule,
    NzTableModule,
    NzIconModule,
    NzButtonModule,
  ],
  templateUrl: './playlist-detail.component.html',
  styleUrl: './playlist-detail.component.css',
})
export class PlaylistDetailComponent implements OnInit {
  playlistId: number = 0;
  private route = inject(ActivatedRoute);
  private playlistService = inject(PlaylistService);
  private messageServie = inject(MessageService);
  private musicPlayerService = inject(MusicPlayerService);
  utilService = inject(UtilityService);
  playlist: PlaylistDetail | undefined;

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
    });
  }

  loadPlaylist() {
    this.playlistService.getPlaylist(this.playlistId).subscribe({
      next: (res) => {
        console.log(res);
        this.playlist = res;
      },
      error: (er) => this.messageServie.showError(er),
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
}
