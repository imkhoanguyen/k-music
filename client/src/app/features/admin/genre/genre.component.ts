import { Genre, GenreParams } from '../../../shared/models/genre';
import { Component, inject, OnInit } from '@angular/core';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzModalModule, NzModalService } from 'ng-zorro-antd/modal';
import { MessageService } from '../../../core/services/message.service';
import { FormsModule } from '@angular/forms';

import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { GenreService } from '../../../core/services/genre.service';
import { Pagination } from '../../../shared/models/pagination';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-genre',
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
  ],

  templateUrl: './genre.component.html',
  styleUrl: './genre.component.css',
})
export class GenreComponent implements OnInit {
  // init
  private genreServices = inject(GenreService);
  private messageServies = inject(MessageService);
  private modal = inject(NzModalService);

  ngOnInit(): void {
    this.loadGenres();
    this.initGenreForm();
  }

  //load genre
  genres: Genre[] = [];
  genreParams = new GenreParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadGenres() {
    this.genreServices.getGenres(this.genreParams).subscribe({
      next: (response) => {
        this.genres = response.result as Genre[];
        this.pagination = response.pagination as Pagination;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  // search, paging, sorting
  onPageIndexChange(newPageNumber: number) {
    this.genreParams.pageNumber = newPageNumber;
    this.loadGenres();
  }

  onPageSizeChange(newPageSize: number) {
    this.genreParams.pageSize = newPageSize;
    this.loadGenres();
  }

  onSortChange(sortBy: string) {
    const currentSort = this.genreParams.orderBy;

    if (currentSort === sortBy) {
      this.genreParams.orderBy = `${sortBy}_desc`;
    } else if (currentSort === `${sortBy}_desc`) {
      this.genreParams.orderBy = sortBy;
    } else {
      this.genreParams.orderBy = sortBy;
    }
    this.loadGenres();
  }

  onSearch() {
    this.loadGenres();
  }

  // form add edit genre
  private fb = inject(FormBuilder);
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  isUpdate = false;
  validationErrors?: string[];
  private genreId: number = 0;

  initGenreForm() {
    this.frm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  showModal(id?: number) {
    if (id != null) {
      this.isUpdate = true;
      this.genreId = id;
      const genre = this.genres.find((g) => g.id == id);
      this.frm.patchValue({
        name: genre?.name,
        description: genre?.description,
      });
    }
    this.isVisibleModal = true;
  }

  closeModal() {
    this.isVisibleModal = false;
    this.isUpdate = false;
    this.genreId = 0;
    this.validationErrors = [];
    this.frm.reset();
  }

  onSubmit() {
    // update
    if (this.isUpdate === true && this.genreId != 0) {
      const genreEdit: Genre = {
        id: this.genreId,
        name: this.frm.value.name,
        description: this.frm.value.description,
      };

      this.genreServices.updateGenre(genreEdit.id || 0, genreEdit).subscribe({
        next: (genre) => {
          const index = this.genres.findIndex((g) => g.id === genreEdit.id);
          this.genres[index] = genre;
          this.messageServies.showSuccess('Cập nhật thể loại thành công');
          this.closeModal();
        },
        error: (er) => {
          this.validationErrors = er;
        },
      });
    } else {
      // add
      const genreAdd: Genre = {
        name: this.frm.value.name,
        description: this.frm.value.description,
      };

      this.genreServices.addGenre(genreAdd).subscribe({
        next: (response) => {
          this.genres.unshift(response);
          this.messageServies.showSuccess('Thêm thể loại thành công');
          this.closeModal();
        },
        error: (er) => {
          console.log(er);
        },
      });
    }
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

        this.genreServices.deleteGenre(id).subscribe({
          next: (_) => {
            const index = this.genres.findIndex((g) => g.id === id);
            this.genres.splice(index, 1);
            this.messageServies.showSuccess('Xóa thể loại thành công');
          },
          error: (er) => (this.validationErrors = er),
        });
      },
      nzCancelText: 'No',
      nzOnCancel: () => this.messageServies.showInfo('Hủy xóa'),
    });
  }
}
