import { CommonModule } from '@angular/common';
import { Component, inject, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NzImageModule } from 'ng-zorro-antd/image';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { MessageService } from '../../../../core/services/message.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { PlaylistDetail } from '../../../../shared/models/playlist';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { AddSongComponent } from '../../../../shared/component/playlists/add-song/add-song.component';

@Component({
  selector: 'app-playlist-detail',
  standalone: true,
  imports: [
    CommonModule,
    NzImageModule,
    NzTableModule,
    NzIconModule,
    NzButtonModule,
    AddSongComponent,
  ],
  templateUrl: './playlist-detail.component.html',
  styleUrl: './playlist-detail.component.css',
})
export class PlaylistDetailComponent {
  playlistId: number = 0;
  private route = inject(ActivatedRoute);
  private playlistService = inject(PlaylistService);
  private messageServie = inject(MessageService);
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
    this.playlistId = +this.route.snapshot.paramMap.get('id')!;
    this.loadPlaylist();
  }

  loadPlaylist() {
    this.playlistService.getPlaylist(this.playlistId).subscribe({
      next: (res) => {
        this.playlist = res;
      },
      error: (er) => this.messageServie.showError(er),
    });
  }

  deleteSong(songId: number) {
    const listSongId = [songId];
    this.playlistService.deleteSongs(this.playlistId, listSongId).subscribe({
      next: (_) => {
        this.playlist!.songList = this.playlist!.songList.filter(
          (song) => song.id !== songId
        );
        this.messageServie.showSuccess(
          'Bài hát đã được xóa khỏi danh sách phát'
        );
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  // *********************************************************************
  // add song modal
  @ViewChild(AddSongComponent)
  addSongComponent!: AddSongComponent;
  openAddSongModal() {
    if (this.addSongComponent) {
      this.addSongComponent.playlistId = this.playlistId;
      this.addSongComponent.showModal();
    } else {
      console.error('AddSongComponent is not initialized yet');
    }
  }

  handleEventAddSongToPlaylist(playlist: any) {
    this.playlist = playlist;
  }
}
