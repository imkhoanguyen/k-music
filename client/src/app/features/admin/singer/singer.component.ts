import { Component, inject, OnInit } from '@angular/core';
import { SingerService } from '../../../core/services/singer.service';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MessageService } from '../../../core/services/message.service';
import { NzModalModule, NzModalService } from 'ng-zorro-antd/modal';
import { Singer, SingerParams } from '../../../shared/models/singer';
import { Pagination } from '../../../shared/models/pagination';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzUploadFile, NzUploadModule } from 'ng-zorro-antd/upload';
import { NzImageModule } from 'ng-zorro-antd/image';

@Component({
  selector: 'app-singer',
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
    NzImageModule,
  ],
  templateUrl: './singer.component.html',
  styleUrl: './singer.component.css',
})
export class SingerComponent implements OnInit {
  // inject
  private singerService = inject(SingerService);
  private messageService = inject(MessageService);
  private fb = inject(FormBuilder);
  constructor(private modal: NzModalService) {}
  ngOnInit(): void {
    this.loadSingers();
    this.loadLocations();
    this.initSingerForm();
  }

  // load singer and combobox
  singers: Singer[] = [];
  locations: string[] = [];
  singerParams = new SingerParams();

  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadSingers() {
    this.singerService.getSingers(this.singerParams).subscribe({
      next: (paginationResult) => {
        this.singers = paginationResult.result as Singer[];
        this.pagination = paginationResult.pagination as Pagination;
      },
      error: (er) => {
        this.messageService.showError(er.message);
        console.log(er);
      },
    });
  }

  loadLocations() {
    this.singerService.getLocations().subscribe({
      next: (data) => {
        this.locations = data;
        console.log(data);
      },
      error: (er) => this.messageService.showError(er.message),
    });
  }

  // search, paging, sort
  onPageIndexChange(newPageNumber: number) {
    this.singerParams.pageNumber = newPageNumber;
    this.loadSingers();
  }

  onPageSizeChange(newPageSize: number) {
    this.singerParams.pageSize = newPageSize;
    this.loadSingers();
  }

  onSearch() {
    this.loadSingers();
  }

  onSortChange(sortBy: string) {
    const currentSort = this.singerParams.orderBy;

    if (currentSort === sortBy) {
      this.singerParams.orderBy = `${sortBy}_desc`;
    } else if (currentSort === `${sortBy}_desc`) {
      this.singerParams.orderBy = sortBy;
    } else {
      this.singerParams.orderBy = sortBy;
    }

    this.loadSingers();
  }

  //form create and edit singer
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  isUpdate = false;
  private singerId: number = 0;

  initSingerForm() {
    this.frm = this.fb.group({
      name: ['', Validators.required],
      gender: ['', Validators.required],
      location: ['', Validators.required],
      imgFile: [''],
      introduction: ['', Validators.required],
    });
  }

  showModal(id?: number) {
    if (id != null) {
      this.isUpdate = true;
      this.singerId = id;
      const singer = this.singers.find((s) => s.id === this.singerId);
      this.frm.patchValue({
        name: singer?.name,
        gender: singer?.gender,
        location: singer?.location,
        introduction: singer?.introduction,
      });
      this.previewImage = singer?.imgUrl as string;
    }
    this.isVisibleModal = true;
  }

  closeModal() {
    this.isVisibleModal = false;
    this.isUpdate = false;
    this.singerId = 0;
    this.previewImage = 'img/300x200.jpg';
    this.frm.reset();
  }

  onSubmit() {
    if (this.isUpdate === true) {
      const formData = new FormData();
      formData.append('id', this.singerId.toString());
      formData.append('name', this.frm.value.name);
      formData.append('gender', this.frm.value.gender);
      formData.append('location', this.frm.value.location);
      formData.append('introduction', this.frm.value.introduction);

      if (this.frm.value.imgFile) {
        formData.append('imgFile', this.frm.value.imgFile);
      }

      this.singerService.updateSinger(this.singerId, formData).subscribe({
        next: (response) => {
          const index = this.singers.findIndex((s) => s.id === this.singerId);
          this.singers[index] = response;
          this.messageService.showSuccess('Cập nhật ca sĩ thành công');
          this.closeModal();
          this.loadLocations();
        },
        error: (er) => {
          console.log(er);
        },
      });
    } else {
      const formData = new FormData();
      formData.append('name', this.frm.value.name);
      formData.append('gender', this.frm.value.gender);
      formData.append('location', this.frm.value.location);
      formData.append('introduction', this.frm.value.introduction);

      if (this.frm.value.imgFile) {
        formData.append('imgFile', this.frm.value.imgFile);
      }

      this.singerService.addSinger(formData).subscribe({
        next: (response) => {
          this.singers.unshift(response);
          this.messageService.showSuccess('Thêm ca sĩ thành công');
          this.closeModal();
          this.loadLocations();
        },
        error: (er) => {
          console.log(er.message);
        },
      });
    }
  }

  // img preview
  previewImage: string | ArrayBuffer | null = null;

  beforeUpload = (file: NzUploadFile): boolean => {
    const reader = new FileReader();
    reader.onload = (e) => {
      if (e.target?.result) {
        this.previewImage = e.target.result; // Chỉ gán nếu result không phải undefined
      }
    };
    reader.readAsDataURL(file as any); // Đọc file để hiển thị preview

    // path value to input
    this.frm.patchValue({
      imgFile: file,
    });

    return false; // Ngăn không cho upload tự động
  };

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
          this.messageService.showError('Có lỗi xảy ra vui lòng thử lại sau.');
          return;
        }

        this.singerService.deleteSinger(id).subscribe({
          next: (_) => {
            const index = this.singers.findIndex((s) => s.id === id);
            this.singers.splice(index, 1);
            this.messageService.showSuccess('Xóa ca sĩ thành công');
          },
          error: (er) => this.messageService.showError(er),
        });
      },
      nzCancelText: 'No',
      nzOnCancel: () => this.messageService.showInfo('Hủy xóa'),
    });
  }
}
