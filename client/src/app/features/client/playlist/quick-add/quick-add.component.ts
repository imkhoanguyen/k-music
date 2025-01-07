import { Component, inject, ViewChild } from '@angular/core';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzModalModule } from 'ng-zorro-antd/modal';
import {
  AddOrDeleteRequest,
  PlaylistParams,
  QuickViewResponse,
} from '../../../../shared/models/playlist';
import { Pagination } from '../../../../shared/models/pagination';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { FormsModule } from '@angular/forms';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { CommonModule } from '@angular/common';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { MessageService } from '../../../../core/services/message.service';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { AddPlaylistComponent } from '../../../../shared/component/playlists/add-playlist/add-playlist.component';
@Component({
  selector: 'app-quick-add',
  standalone: true,
  imports: [
    NzCheckboxModule,
    NzModalModule,
    NzTableModule,
    NzImageModule,
    NzToolTipModule,
    FormsModule,
    NzPaginationModule,
    CommonModule,
    NzIconModule,
    NzButtonModule,
    AddPlaylistComponent,
  ],
  templateUrl: './quick-add.component.html',
  styleUrl: './quick-add.component.css',
})
export class QuickAddComponent {
  private playlistService = inject(PlaylistService);
  private messageService = inject(MessageService);
  songId = 0;
  isVisibleModal = false;

  playlists: QuickViewResponse[] = [];
  prm = new PlaylistParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadQuickView() {
    this.playlistService.getQuickViewPlaylist(this.prm, this.songId).subscribe({
      next: (res) => {
        this.playlists = res.result as QuickViewResponse[];
        this.pagination = res.pagination as Pagination;
        this.isVisibleModal = true;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  closeModal() {
    this.isVisibleModal = false;
  }

  showModal() {
    this.loadQuickView();
  }

  onPageIndexChange(newPageNumber: number) {
    this.prm.pageNumber = newPageNumber;
    this.loadQuickView();
  }

  onPageSizeChange(newPageSize: number) {
    this.prm.pageSize = newPageSize;
    this.loadQuickView();
  }

  onChange(playlistId: number, songId: number) {
    const request: AddOrDeleteRequest = {
      playlistId: playlistId,
      songId: songId,
    };
    this.playlistService.AddOrDelete(request).subscribe({
      next: (res) => {
        if (res === true)
          this.messageService.showSuccess(
            'Thêm bài hát vào danh sách phát thành công'
          );

        if (res === false) {
          this.messageService.showSuccess(
            'Xóa bài hát khỏi danh sách phát thành công'
          );
        }
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  @ViewChild(AddPlaylistComponent) addPlaylistComponent!: AddPlaylistComponent;
  openNomarlAddModal() {
    if (this.addPlaylistComponent) {
      this.addPlaylistComponent.showModal();
    } else {
      console.error('AddPlaylistComponent is not initialized yet');
    }
  }

  addNewPlaylist(playlist: any) {
    this.playlists = [playlist, ...this.playlists];
  }
}
