import { Component, inject, OnInit } from '@angular/core';
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
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzTableModule } from 'ng-zorro-antd/table';
import {
  NzUploadChangeParam,
  NzUploadFile,
  NzUploadModule,
} from 'ng-zorro-antd/upload';
import { SongService } from '../../../../core/services/song.service';
import { MessageService } from '../../../../core/services/message.service';
import { Song, SongParams } from '../../../../shared/models/song';
import { GenreService } from '../../../../core/services/genre.service';
import { Genre } from '../../../../shared/models/genre';
import { Pagination } from '../../../../shared/models/pagination';
import { SingerService } from '../../../../core/services/singer.service';
import { Singer } from '../../../../shared/models/singer';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { Router } from '@angular/router';
import { NzImageModule } from 'ng-zorro-antd/image';

@Component({
  selector: 'app-song',
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
    NzSelectModule,
    NzUploadModule,
    NzSwitchModule,
    NzImageModule,
  ],
  templateUrl: './song.component.html',
  styleUrl: './song.component.css',
})
export class SongComponent implements OnInit {
  // inject
  private songServices = inject(SongService);
  private messageServies = inject(MessageService);
  private genreServices = inject(GenreService);
  private singerServices = inject(SingerService);
  private fb = inject(FormBuilder);
  private router = inject(Router);
  constructor(private modal: NzModalService) {}
  ngOnInit(): void {
    this.loadSongs();
    this.loadGenres();
    this.loadSingers();
    this.initSongForm();
  }

  // load song, singer, genre
  songs: Song[] = [];
  genres: Genre[] = [];
  singers: Singer[] = [];
  songParams = new SongParams();

  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadSongs() {
    this.songServices.getSongs(this.songParams).subscribe({
      next: (paginationResult) => {
        this.songs = paginationResult.result as Song[];
        this.pagination = paginationResult.pagination as Pagination;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  loadSingers() {
    this.singerServices.getAllSinger().subscribe({
      next: (data) => {
        this.singers = data;
      },
      error: (er) => console.log(er),
    });
  }

  loadGenres() {
    this.genreServices.getAllGenre().subscribe({
      next: (data) => {
        this.genres = data;
      },
      error: (er) => console.log(er),
    });
  }

  //paging sorting
  onPageIndexChange(newPageNumber: number) {
    this.songParams.pageNumber = newPageNumber;
    this.loadSongs();
  }

  onPageSizeChange(newPageSize: number) {
    this.songParams.pageSize = newPageSize;
    this.loadSongs();
  }

  onSortChange(sortBy: string) {
    const currentSort = this.songParams.orderBy;
    if (currentSort === sortBy) {
      this.songParams.orderBy = `${sortBy}_desc`;
    } else if (currentSort === `${sortBy}_desc`) {
      this.songParams.orderBy = sortBy;
    } else {
      this.songParams.orderBy = sortBy;
    }
    this.loadSongs();
  }

  onSearch() {
    this.loadSongs();
  }

  // form create, update song
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  isUpdate = false;
  private songId: number = 0;

  initSongForm() {
    this.frm = this.fb.group({
      name: ['', Validators.required],
      lyric: ['', Validators.required],
      introduction: ['', Validators.required],
      imgFile: [''],
      songFile: [''],
      genreList: [[], Validators.required],
      singerList: [[], Validators.required],
    });
  }

  showModal(id?: number) {
    if (id != null) {
      this.isUpdate = true;
      this.songId = id;
      const song = this.songs.find((s) => s.id === this.songId);
      this.frm.patchValue({
        name: song?.name,
        lyric: song?.lyric,
        introduction: song?.introduction,
        genreList: song?.genres.map((g: Genre) => g.id),
        singerList: song?.singers.map((s: Singer) => s.id),
      });
      this.previewImage = song?.imgUrl as string;
    }
    this.isVisibleModal = true;
  }

  closeModal() {
    this.isVisibleModal = false;
    this.isUpdate = false;
    this.songId = 0;
    this.previewImage = '';
    this.songFile = null;
    this.frm.reset();
  }

  onSubmit() {
    if (this.isUpdate === true) {
      const formData = new FormData();
      formData.append('id', this.songId.toString());
      formData.append('name', this.frm.value.name);
      formData.append('lyric', this.frm.value.lyric);
      formData.append('introduction', this.frm.value.introduction);

      if (this.frm.value.genreList && this.frm.value.genreList.length > 0) {
        this.frm.value.genreList.forEach((genreId: number) => {
          formData.append('genreList', genreId.toString());
        });
      }

      if (this.frm.value.singerList && this.frm.value.singerList.length > 0) {
        this.frm.value.singerList.forEach((singerId: number) => {
          formData.append('singerList', singerId.toString());
        });
      }

      if (this.frm.value.imgFile) {
        formData.append('imgFile', this.frm.value.imgFile);
      }
      if (this.songFile != null) {
        formData.append('songFile', this.songFile);
      }
      this.songServices.updateSong(this.songId, formData).subscribe({
        next: (response) => {
          const index = this.songs.findIndex((s) => s.id === this.songId);
          this.songs[index] = response;
          this.messageServies.showSuccess('Cập nhật bài hát thành công');
          this.closeModal();
        },
        error: (er) => {
          console.log(er);
        },
      });
    } else {
      const formData = new FormData();
      formData.append('name', this.frm.value.name);
      formData.append('lyric', this.frm.value.lyric);
      formData.append('introduction', this.frm.value.introduction);

      if (this.frm.value.genreList && this.frm.value.genreList.length > 0) {
        this.frm.value.genreList.forEach((genreId: number) => {
          formData.append('genreList', genreId.toString());
        });
      }

      if (this.frm.value.singerList && this.frm.value.singerList.length > 0) {
        this.frm.value.singerList.forEach((singerId: number) => {
          formData.append('singerList', singerId.toString());
        });
      }

      if (this.frm.value.imgFile) {
        formData.append('imgFile', this.frm.value.imgFile);
      }
      if (this.songFile != null) {
        formData.append('songFile', this.songFile);
      }
      this.songServices.addSong(formData).subscribe({
        next: (response) => {
          this.songs.unshift(response);
          this.messageServies.showSuccess('Thêm bài hát thành công');
          this.loadGenres();
          this.loadSingers();
          this.closeModal();
        },
        error: (er) => {
          console.log(er);
        },
      });
    }
  }

  // img preview
  previewImage: string | ArrayBuffer | null = null;
  // song file
  songFile: File | null = null;

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

  handleChangeSongFile(info: NzUploadChangeParam): void {
    const file = info.file;
    this.songFile = file.originFileObj as File;
  }

  getGenresString(song: Song) {
    return song.genres.map((g: Genre) => g.name).join(', ');
  }

  getSingersString(song: Song) {
    return song.singers.map((s: Singer) => s.name).join(', ');
  }

  updateIsVip(songId: number, isVip: boolean) {
    this.songServices.updateSongVip(songId, isVip).subscribe({
      next: (_) => {
        if (isVip === true)
          this.messageServies.showSuccess(
            'Chuyyển bài hát thành vip thành công'
          );
        else this.messageServies.showSuccess('Hủy vip của bài hát thành công');
      },
      error: (er) => console.log(er),
    });
  }

  // delete popup
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
        this.songServices.deleteSong(id).subscribe({
          next: (_) => {
            const index = this.songs.findIndex((s) => s.id === id);
            this.songs.splice(index, 1);
            this.messageServies.showSuccess('Xóa bài hát thành công');
          },
          error: (er) => console.log(er),
        });
      },
      nzCancelText: 'No',
      nzOnCancel: () => this.messageServies.showInfo('Hủy xóa'),
    });
  }

  onGoDetail(songId: number) {
    this.router.navigate(['/admin/song', songId]);
  }
}
