import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, OnInit, Output } from '@angular/core';
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
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzUploadFile, NzUploadModule } from 'ng-zorro-antd/upload';
import { Song, SongParams } from '../../models/song';
import { SongService } from '../../../core/services/song.service';
import { Pagination } from '../../models/pagination';
import { MessageService } from '../../../core/services/message.service';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { UtilityService } from '../../../core/services/utility.service';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { PlaylistService } from '../../../core/services/playlist.service';

@Component({
  selector: 'app-add-playlist',
  standalone: true,
  imports: [
    NzButtonModule,
    NzInputModule,
    NzIconModule,
    NzModalModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    NzUploadModule,
    NzTableModule,
    NzPaginationModule,
    NzImageModule,
    NzToolTipModule,
    NzRadioModule,
  ],
  templateUrl: './add-playlist.component.html',
  styleUrl: './add-playlist.component.css',
})
export class AddPlaylistComponent implements OnInit {
  // init
  @Output() playlistAdded = new EventEmitter<any>();
  private songService = inject(SongService);
  private messageService = inject(MessageService);
  private playlistService = inject(PlaylistService);
  ultilService = inject(UtilityService);
  radioValue = false;

  ngOnInit(): void {
    this.initForm();
  }

  // form add
  private fb = inject(FormBuilder);
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  validationErrors?: string[];

  initForm() {
    this.frm = this.fb.group({
      name: ['', Validators.required],
      imgFile: ['', Validators.required],
    });
  }

  closeModal() {
    this.isVisibleModal = false;
    this.validationErrors = [];
    this.frm.reset();
    this.previewImage = '';
    this.songList = [];
    this.currentSongList = [];
    this.prm.searchTerm = '';
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('name', this.frm.value.name);
    formData.append('isPublic', this.radioValue.toString());
    if (this.currentSongList && this.currentSongList.length > 0) {
      this.currentSongList.forEach((song: Song) => {
        formData.append('songList', song.id.toString());
      });
    }

    if (this.frm.value.imgFile) {
      formData.append('imgFile', this.frm.value.imgFile);
    }

    this.playlistService.addPlaylist(formData).subscribe({
      next: (response) => {
        this.playlistAdded.emit(response);
        this.messageService.showSuccess('Thêm danh sách phát thành công');
        this.closeModal();
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  showModal() {
    this.isVisibleModal = true;
  }

  // img preview
  previewImage: string | ArrayBuffer | null = null;
  beforeUploadImg = (file: NzUploadFile): boolean => {
    const reader = new FileReader();
    reader.onload = (e) => {
      if (e.target?.result) {
        this.previewImage = e.target.result;
      }
    };
    reader.readAsDataURL(file as any);

    // path value to input
    this.frm.patchValue({
      imgFile: file,
    });

    return false; // Ngăn không cho upload tự động
  };

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
}
