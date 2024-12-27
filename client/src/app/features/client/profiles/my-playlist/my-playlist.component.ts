import { Component, inject, OnInit, ViewChild } from '@angular/core';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzTableModule } from 'ng-zorro-antd/table';
import { AccountService } from '../../../../core/services/account.service';
import { Router } from '@angular/router';
import { MessageService } from '../../../../core/services/message.service';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { MusicPlayerService } from '../../../../core/services/music-player.service';
import { Playlist, PlaylistParams } from '../../../../shared/models/playlist';
import { Pagination } from '../../../../shared/models/pagination';
import { UtilityService } from '../../../../core/services/utility.service';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { NzInputModule } from 'ng-zorro-antd/input';
import { MutiAddPlaylistComponent } from '../../../../shared/component/playlists/auto-add-playlist/auto-add-playlist.component';
import { AddPlaylistComponent } from '../../../../shared/component/playlists/add-playlist/add-playlist.component';
import { UpdatePlaylistComponent } from '../../../../shared/component/playlists/update-playlist/update-playlist.component';
import { NzModalService } from 'ng-zorro-antd/modal';

@Component({
  selector: 'app-my-playlist',
  standalone: true,
  imports: [
    NzTableModule,
    NzPaginationModule,
    NzButtonModule,
    NzIconModule,
    NzImageModule,
    NzTagModule,
    CommonModule,
    FormsModule,
    NzPopoverModule,
    NzInputModule,
    UpdatePlaylistComponent,
    AddPlaylistComponent,
    MutiAddPlaylistComponent,
  ],
  templateUrl: './my-playlist.component.html',
  styleUrl: './my-playlist.component.css',
})
export class MyPlaylistComponent implements OnInit {
  private accountService = inject(AccountService);
  private router = inject(Router);
  private messageService = inject(MessageService);
  private playlistService = inject(PlaylistService);
  private musicPlayerService = inject(MusicPlayerService);
  utilService = inject(UtilityService);
  private modal = inject(NzModalService);

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
    this.accountService.getMyPlaylist(this.prm).subscribe({
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

  onSearch() {
    this.loadPaylists();
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

  // *********************************************************************
  // update form
  @ViewChild(UpdatePlaylistComponent)
  updatePlaylistComponent!: UpdatePlaylistComponent;
  openUpdateModal(playlistId: number) {
    if (this.updatePlaylistComponent) {
      this.updatePlaylistComponent.playlistId = playlistId;
      this.updatePlaylistComponent.showModal();
    } else {
      console.error('UpdatePlaylistComponent is not initialized yet');
    }
  }

  updatePlaylist(playlist: any) {
    const index = this.playlists.findIndex((p) => p.id === playlist.id);
    if (index !== -1) {
      this.playlists[index] = playlist as Playlist;
    }
    console.log(index);
  }

  // *********************************************************************
  // normal add form
  @ViewChild(AddPlaylistComponent) addPlaylistComponent!: AddPlaylistComponent;
  openNomarlAddModal() {
    if (this.addPlaylistComponent) {
      this.addPlaylistComponent.showModal();
    } else {
      console.error('AddPlaylistComponent is not initialized yet');
    }
  }

  addNewPlaylist(playlist: any) {
    this.playlists.unshift(playlist);
  }

  // *********************************************************************
  // muti add form
  @ViewChild(MutiAddPlaylistComponent)
  mutiAddPlaylistComponent!: MutiAddPlaylistComponent;
  openMutiAddModal() {
    if (this.mutiAddPlaylistComponent) {
      this.mutiAddPlaylistComponent.showModal();
    } else {
      console.error('MutiAddPlaylistComponent is not initialized yet');
    }
  }

  handleEventAutoAddPlaylist(playlist: any) {
    this.playlists.unshift(playlist);
  }

  //delete popup
  showDeleteConfirm(id: number) {
    this.modal.confirm({
      nzTitle: 'Are you sure delete this task?',
      nzContent: `<b style="color: red;">Toàn bộ dữ liệu liên quan sẽ bị mất</b>`,
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => {
        if (id === 0) {
          this.messageService.showError('Có lỗi xảy ra vui lòng thử lại sau.');
          return;
        }

        this.playlistService.deletePlaylist(id).subscribe({
          next: (_) => {
            const index = this.playlists.findIndex((g) => g.id === id);
            this.playlists.splice(index, 1);
            this.messageService.showSuccess('Xóa danh sách phát thành công');
          },
          error: (er) => console.log(er),
        });
      },
      nzCancelText: 'No',
      nzOnCancel: () => this.messageService.showInfo('Hủy xóa'),
    });
  }
}
