import { CommonModule } from '@angular/common';
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
import { NzTableModule } from 'ng-zorro-antd/table';
import { RoleService } from '../../../core/services/role.service';
import { MessageService } from '../../../core/services/message.service';
import { Role, RoleParams } from '../../../shared/models/role';
import { Pagination } from '../../../shared/models/pagination';
import { Router } from '@angular/router';

@Component({
  selector: 'app-role',
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
  templateUrl: './role.component.html',
  styleUrl: './role.component.css',
})
export class RoleComponent implements OnInit {
  // init
  private roleService = inject(RoleService);
  private messageServies = inject(MessageService);
  private modal = inject(NzModalService);
  private router = inject(Router);

  ngOnInit(): void {
    this.loadRoles();
    this.initForm();
  }

  //load role
  roles: Role[] = [];
  prm = new RoleParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadRoles() {
    this.roleService.getRoles(this.prm).subscribe({
      next: (res) => {
        this.roles = res.result as Role[];
        this.pagination = res.pagination as Pagination;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  // search, paging, sorting
  onPageIndexChange(newPageNumber: number) {
    this.prm.pageNumber = newPageNumber;
    this.loadRoles();
  }

  onPageSizeChange(newPageSize: number) {
    this.prm.pageSize = newPageSize;
    this.loadRoles();
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
    this.loadRoles();
  }

  onSearch() {
    this.loadRoles();
  }

  // form add edit role
  private fb = inject(FormBuilder);
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  isUpdate = false;
  validationErrors?: string[];
  private roleId: string = '';

  initForm() {
    this.frm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  showModal(id?: string) {
    if (id != null) {
      this.isUpdate = true;
      this.roleId = id;
      const role = this.roles.find((r) => r.id == id);
      this.frm.patchValue({
        name: role?.name,
        description: role?.description,
      });
    }
    this.isVisibleModal = true;
  }

  closeModal() {
    this.isVisibleModal = false;
    this.isUpdate = false;
    this.roleId = '';
    this.validationErrors = [];
    this.frm.reset();
  }

  onSubmit() {
    // update
    if (this.isUpdate === true && this.roleId !== '') {
      const roleEdit: Role = {
        id: this.roleId,
        name: this.frm.value.name,
        description: this.frm.value.description,
      };

      this.roleService.updateRole(this.roleId, roleEdit).subscribe({
        next: (role) => {
          const index = this.roles.findIndex((g) => g.id === roleEdit.id);
          this.roles[index] = role;
          this.messageServies.showSuccess('Cập nhật quyền thành công');
          this.closeModal();
        },
        error: (er) => {
          this.validationErrors = er;
        },
      });
    } else {
      // add
      const roleAdd: Role = {
        name: this.frm.value.name,
        description: this.frm.value.description,
      };

      this.roleService.addRole(roleAdd).subscribe({
        next: (res) => {
          this.roles.unshift(res);
          this.messageServies.showSuccess('Thêm quyền thành công');
          this.closeModal();
        },
        error: (er) => {
          console.log(er);
        },
      });
    }
  }

  //delete popup
  showDeleteConfirm(id: string) {
    this.modal.confirm({
      nzTitle: 'Are you sure delete this task?',
      nzContent: `<b style="color: red;">Toàn bộ dữ liệu liên quan sẽ bị mất</b>`,
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => {
        if (id === '') {
          this.messageServies.showError('Có lỗi xảy ra vui lòng thử lại sau.');
          return;
        }

        this.roleService.deleteRole(id).subscribe({
          next: (_) => {
            const index = this.roles.findIndex((r) => r.id === id);
            this.roles.splice(index, 1);
            this.messageServies.showSuccess('Xóa quyền thành công');
          },
          error: (er) => (this.validationErrors = er),
        });
      },
      nzCancelText: 'No',
      nzOnCancel: () => this.messageServies.showInfo('Hủy xóa'),
    });
  }

  onGoRolePermission(roleId?: string) {
    if (roleId) this.router.navigate(['/admin/role/permission', roleId]);
    else this.messageServies.showError('Có lỗi xảy ra vui lòng thử lại sau');
  }
}
