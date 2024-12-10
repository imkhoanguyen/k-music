import { CommonModule } from '@angular/common';
import {
  Component,
  EventEmitter,
  inject,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { SongService } from '../../../../core/services/song.service';
import { MessageService } from '../../../../core/services/message.service';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { Song, SongParams } from '../../../models/song';
import { Pagination } from '../../../models/pagination';
import { NzImageModule } from 'ng-zorro-antd/image';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-song',
  standalone: true,
  imports: [
    NzButtonModule,
    NzInputModule,
    NzIconModule,
    NzModalModule,
    CommonModule,
    NzTableModule,
    NzPaginationModule,
    NzToolTipModule,
    NzImageModule,
    FormsModule,
  ],
  templateUrl: './add-song.component.html',
  styleUrl: './add-song.component.css',
})
export class AddSongComponent {
  // init
  @Output() playlistAdded = new EventEmitter<any>();
  @Input() playlistId = 0;
  private songService = inject(SongService);
  private messageService = inject(MessageService);
  private playlistService = inject(PlaylistService);
  utilService = inject(UtilityService);

  isVisibleModal = false;

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

  closeModal() {
    this.songList = [];
    this.currentSongList = [];
    this.prm.searchTerm = '';
    this.isVisibleModal = false;
  }

  showModal() {
    this.isVisibleModal = true;
  }

  // song list search
  // load song, list song preview
  songList: Song[] = [];
  prm = new SongParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadSongs() {
    this.songService.getSongs(this.prm).subscribe({
      next: (paginationResult) => {
        this.songList = paginationResult.result as Song[];
        this.pagination = paginationResult.pagination as Pagination;
        console.log(paginationResult);
      },
      error: (er) => {
        this.messageService.showError(er.message);
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

  // current song list in playlist
  currentSongList: Song[] = [];

  addToCurrentSongList(song: Song): void {
    if (!this.currentSongList.includes(song)) {
      this.currentSongList.push(song);
    }
  }

  deleteSong(id: number) {
    const index = this.currentSongList.findIndex((s) => s.id === id);
    this.currentSongList.splice(index, 1);
  }

  addSongToPlaylist() {
    const songIds = this.currentSongList.map((song) => song.id);
    this.playlistService.addSongs(this.playlistId, songIds).subscribe({
      next: (res) => {
        this.playlistAdded.emit(res);
        this.messageService.showSuccess(
          'Các bài hát đã được thêm vào danh sách phát thành công'
        );
        this.closeModal();
      },
      error: (er) => {
        console.log(er);
      },
    });
  }
}
