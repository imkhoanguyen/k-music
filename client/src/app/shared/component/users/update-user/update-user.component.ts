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
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzUploadFile, NzUploadModule } from 'ng-zorro-antd/upload';
import { UserService } from '../../../../core/services/user.service';
import { MessageService } from '../../../../core/services/message.service';
import { RoleService } from '../../../../core/services/role.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { AppUser } from '../../../models/user';
import { Role } from '../../../models/role';
import { GENDER_LIST } from '../../../models/gender-list';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'app-update-user',
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
    NzSelectModule,
    NzTagModule,
    NzTabsModule,
  ],
  templateUrl: './update-user.component.html',
  styleUrl: './update-user.component.css',
})
export class UpdateUserComponent implements OnInit {
  // init
  private userService = inject(UserService);
  private messageService = inject(MessageService);
  private roleService = inject(RoleService);
  private authService = inject(AuthService);
  utilService = inject(UtilityService);
  @Output() userUpdated = new EventEmitter<{
    appUser: AppUser;
    userName: string;
  }>();
  userName = '';
  user: AppUser | any;

  ngOnInit(): void {
    this.initForm();
    this.loadRoles();
  }

  users: AppUser[] = [];
  roles: Role[] = [];
  genderList = GENDER_LIST;
  passwordVisible = false;

  // form edit user
  private fb = inject(FormBuilder);
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  validationErrors?: string[];

  initForm() {
    this.frm = this.fb.group({
      userName: ['', Validators.required],
      fullName: ['', Validators.required],
      gender: ['', Validators.required],
      imgFile: [''],
      email: ['', Validators.required],
    });
  }

  loadRoles() {
    this.roleService.getAllRoles().subscribe({
      next: (res) => {
        this.roles = res;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  showModal() {
    this.userService.getUser(this.userName).subscribe({
      next: (res) => {
        this.user = res.body;
        console.log(res);
        this.frm.patchValue({
          userName: this.userName,
          gender: this.user.gender,
          fullName: this.user.fullName,
          email: this.user.email,
        });
        this.previewImage = this.user.imgUrl as string;
        console.log(this.frm);
        this.roleName = this.user.role;
        console.log(this.roleName);
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
    this.currentPassword = '';
    this.passwordNew = '';
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('userName', this.frm.value.userName);
    formData.append('gender', this.frm.value.gender);
    formData.append('fullName', this.frm.value.fullName);
    formData.append('email', this.frm.value.email);

    if (this.frm.value.imgFile) {
      formData.append('imgFile', this.frm.value.imgFile);
    }

    this.userService.updateInformation(this.userName, formData).subscribe({
      next: (response: AppUser) => {
        if (this.userName === this.authService.currentUser()?.userName) {
          this.authService
            .callRefreshToken(
              this.authService.currentUser()?.refreshToken ?? ''
            )
            .subscribe({
              next: (res) => {
                this.authService.setCurrentUser(res);
              },
              error: (er) => {
                console.log(er);
              },
            });
        }
        this.userUpdated.emit({ appUser: response, userName: this.userName });
        this.messageService.showSuccess('Cập nhật người dùng thành công');
        this.closeModal();
      },
      error: (er) => {
        console.log(er);
        this.validationErrors = er;
      },
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

  currentPassword = '';
  passwordNew = '';

  changePassword() {
    this.userService
      .changePassword(this.userName, this.currentPassword, this.passwordNew)
      .subscribe({
        next: (_) => {
          this.messageService.showSuccess('Đổi mật khẩu thành công');
          this.closeModal();
        },
        error: (er) => {
          console.log(er);
        },
      });
  }

  roleName = '';
}
