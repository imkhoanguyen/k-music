import { CommonModule } from '@angular/common';
import { Component, inject, ViewChild } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzModalModule, NzModalService } from 'ng-zorro-antd/modal';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzTableModule } from 'ng-zorro-antd/table';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { MessageService } from '../../../../core/services/message.service';
import { Playlist, PlaylistParams } from '../../../../shared/models/playlist';
import { Pagination } from '../../../../shared/models/pagination';
import { UtilityService } from '../../../../core/services/utility.service';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { AddPlaylistComponent } from '../../../../shared/component/playlists/add-playlist/add-playlist.component';
import { NzImageModule } from 'ng-zorro-antd/image';
import { UpdatePlaylistComponent } from '../../../../shared/component/playlists/update-playlist/update-playlist.component';
import { MutiAddPlaylistComponent } from '../../../../shared/component/playlists/auto-add-playlist/auto-add-playlist.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-playlist',
  standalone: true,
  imports: [
    NzTableModule,
    NzPaginationModule,
    NzButtonModule,
    NzInputModule,
    NzIconModule,
    NzModalModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    NzTagModule,
    NzPopoverModule,
    AddPlaylistComponent,
    NzImageModule,
    UpdatePlaylistComponent,
    MutiAddPlaylistComponent,
  ],
  templateUrl: './playlist.component.html',
  styleUrl: './playlist.component.css',
})
export class PlaylistComponent {
  // inject service
  private playlistService = inject(PlaylistService);
  private messageServies = inject(MessageService);
  ultilSerivce = inject(UtilityService);
  private modal = inject(NzModalService);
  private router = inject(Router);

  ngOnInit(): void {
    this.loadPaylists();
  }

  // *********************************************************************
  // load playlist, sort, paging, search ...
  playlists: Playlist[] = [];
  prm = new PlaylistParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadPaylists() {
    this.playlistService.getPlaylists(this.prm).subscribe({
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

  onGoDetail(playlistId: number) {
    this.router.navigate(['/admin/playlist', playlistId]);
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
          this.messageServies.showError('Có lỗi xảy ra vui lòng thử lại sau.');
          return;
        }

        this.playlistService.deletePlaylist(id).subscribe({
          next: (_) => {
            const index = this.playlists.findIndex((g) => g.id === id);
            this.playlists.splice(index, 1);
            this.messageServies.showSuccess('Xóa danh sách phát thành công');
          },
          error: (er) => console.log(er),
        });
      },
      nzCancelText: 'No',
      nzOnCancel: () => this.messageServies.showInfo('Hủy xóa'),
    });
  }
}
