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
import { UserService } from '../../../core/services/user.service';
import { MessageService } from '../../../core/services/message.service';
import { AppUser, UserParams } from '../../../shared/models/user';
import { Pagination } from '../../../shared/models/pagination';
import { RoleService } from '../../../core/services/role.service';
import { Role } from '../../../shared/models/role';
import { UtilityService } from '../../../core/services/utility.service';
import { NzUploadFile, NzUploadModule } from 'ng-zorro-antd/upload';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { GENDER_LIST } from '../../../shared/models/gender-list';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { UpdateUserComponent } from '../../../shared/component/users/update-user/update-user.component';

@Component({
  selector: 'app-user',
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
    NzUploadModule,
    NzImageModule,
    NzSelectModule,
    NzTagModule,
    UpdateUserComponent,
  ],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
})
export class UserComponent {
  // init
  private userService = inject(UserService);
  private messageService = inject(MessageService);
  private modal = inject(NzModalService);
  private roleService = inject(RoleService);
  utilService = inject(UtilityService);

  ngOnInit(): void {
    this.loadUsers();
    this.initForm();
  }

  users: AppUser[] = [];
  roles: Role[] = [];
  prm = new UserParams();
  genderList = GENDER_LIST;
  passwordVisible = false;
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadUsers() {
    this.userService.getUsers(this.prm).subscribe({
      next: (response) => {
        this.users = response.result as AppUser[];
        this.pagination = response.pagination as Pagination;
        console.log(response);
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  // search, paging, sorting
  onPageIndexChange(newPageNumber: number) {
    this.prm.pageNumber = newPageNumber;
    this.loadUsers();
  }

  onPageSizeChange(newPageSize: number) {
    this.prm.pageSize = newPageSize;
    this.loadUsers();
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
    this.loadUsers();
  }

  onSearch() {
    this.loadUsers();
  }

  // form add edit genre
  private fb = inject(FormBuilder);
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  validationErrors?: string[];

  initForm() {
    this.frm = this.fb.group({
      userName: ['', Validators.required],
      fullName: ['', Validators.required],
      gender: ['', Validators.required],
      password: ['', Validators.required],
      imgFile: [''],
      role: ['', Validators.required],
      email: ['', Validators.required],
    });
  }

  showModal() {
    this.roleService.getAllRoles().subscribe({
      next: (res) => {
        this.roles = res;
        this.isVisibleModal = true;
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
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('userName', this.frm.value.userName);
    formData.append('gender', this.frm.value.gender);
    formData.append('fullName', this.frm.value.fullName);
    formData.append('role', this.frm.value.role);
    formData.append('email', this.frm.value.email);
    formData.append('password', this.frm.value.password);

    if (this.frm.value.imgFile) {
      formData.append('imgFile', this.frm.value.imgFile);
    }

    this.userService.add(formData).subscribe({
      next: (response) => {
        this.users.unshift(response);
        this.messageService.showSuccess('Thêm người dùng thành công');
        this.closeModal();
      },
      error: (er) => {
        console.log(er);
        this.validationErrors = er;
      },
    });
  }

  //delete popup
  showDeleteConfirm(userName: string) {
    this.modal.confirm({
      nzTitle: 'Are you sure delete this task?',
      nzContent: `<b style="color: red;">Toàn bộ dữ liệu liên quan sẽ bị mất</b>`,
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => {
        if (userName) {
          this.messageService.showError('Có lỗi xảy ra vui lòng thử lại sau.');
          return;
        }

        // this.userService.deleteGenre(id).subscribe({
        //   next: (_) => {
        //     const index = this.genres.findIndex((g) => g.id === id);
        //     this.genres.splice(index, 1);
        //     this.messageServies.showSuccess('Xóa thể loại thành công');
        //   },
        //   error: (er) => (this.validationErrors = er),
        // });
      },
      nzCancelText: 'No',
      nzOnCancel: () => this.messageService.showInfo('Hủy xóa'),
    });
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

  @ViewChild(UpdateUserComponent)
  updateUserComponent!: UpdateUserComponent;
  openUpdateModal(userName: string) {
    if (this.updateUserComponent) {
      this.updateUserComponent.userName = userName;
      this.updateUserComponent.showModal();
    } else {
      console.error('UpdateUserComponent is not initialized yet');
    }
  }

  updateUser(res: any) {
    console.log(res);
    const index = this.users.findIndex((u) => u.userName == res.userName);
    if (index !== -1) {
      this.users[index] = res.appUser;
    }
  }
  updateRole(res: any) {
    const index = this.users.findIndex((u) => u.userName == res.userName);
    if (index !== -1) {
      this.users[index].role = res.role;
    }
  }
}
