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
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { NzUploadFile, NzUploadModule } from 'ng-zorro-antd/upload';
import { SongService } from '../../../../core/services/song.service';
import { MessageService } from '../../../../core/services/message.service';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { GenreService } from '../../../../core/services/genre.service';
import { Genre } from '../../../models/genre';
import { SingerService } from '../../../../core/services/singer.service';
import { Singer } from '../../../models/singer';

@Component({
  selector: 'app-muti-add-playlist',
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
    NzImageModule,
    NzRadioModule,
    NzSelectModule,
  ],
  templateUrl: './muti-add-playlist.component.html',
  styleUrl: './muti-add-playlist.component.css',
})
export class MutiAddPlaylistComponent implements OnInit {
  // init
  @Output() playlistAdded = new EventEmitter<any>();
  private songService = inject(SongService);
  private messageService = inject(MessageService);
  private playlistService = inject(PlaylistService);
  private genreService = inject(GenreService);
  private singerService = inject(SingerService);

  ultilService = inject(UtilityService);

  ngOnInit(): void {
    this.initForm();
    this.getGenreList();
    this.getSingerList();
  }

  //init value
  genreList: Genre[] = [];
  singerList: Singer[] = [];

  // form add
  private fb = inject(FormBuilder);
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  validationErrors?: string[];

  initForm() {
    this.frm = this.fb.group({
      name: ['', Validators.required],
      imgFile: ['', Validators.required],
      isPublic: [false],
      selectedGenre: [[]],
      selectedSinger: [[]],
      count: [0],
    });
  }

  getGenreList() {
    this.genreService.getAllGenre().subscribe({
      next: (res) => {
        this.genreList = res;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  getSingerList() {
    this.singerService.getAllSinger().subscribe({
      next: (res) => {
        this.singerList = res;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  closeModal() {
    this.isVisibleModal = false;
    this.validationErrors = [];
    this.frm.reset();
    this.previewImage = '';
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('name', this.frm.value.name);
    formData.append('isPublic', this.frm.value.isPublic.toString());

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
        this.validationErrors = er;
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
}
