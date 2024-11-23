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
import { PlaylistService } from '../../../core/services/playlist.service';
import { MessageService } from '../../../core/services/message.service';
import { Playlist, PlaylistParams } from '../../../shared/models/playlist';
import { Pagination } from '../../../shared/models/pagination';
import { UtilityService } from '../../../core/services/utility.service';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { AddPlaylistComponent } from '../../../shared/component/add-playlist/add-playlist.component';
import { NzImageModule } from 'ng-zorro-antd/image';

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

  ngOnInit(): void {
    this.loadPaylists();
    this.initUpdateForm();
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
    this.playlistService.getPlaylist(this.prm).subscribe({
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
  private fb = inject(FormBuilder);
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  validationErrors?: string[];

  initUpdateForm() {
    this.frm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  showModal(id?: number) {
    this.isVisibleModal = true;
  }

  closeModal() {
    this.isVisibleModal = false;
    this.validationErrors = [];
    this.frm.reset();
  }

  onSubmit() {
    // add
    const playlist = {
      name: this.frm.value.name,
    };

    // this.genreServices.addGenre(genreAdd).subscribe({
    //   next: (response) => {
    //     this.genres.unshift(response);
    //     this.messageServies.showSuccess('Thêm thể loại thành công');
    //     this.closeModal();
    //   },
    //   error: (er) => {
    //     console.log(er);
    //   },
    // });
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
}
