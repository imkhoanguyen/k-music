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
import { NzTableModule } from 'ng-zorro-antd/table';
import { VipPackageService } from '../../../core/services/vip-package.service';
import { MessageService } from '../../../core/services/message.service';
import {
  VipPackage,
  VipPackageCreate,
} from '../../../shared/models/vip-package';

@Component({
  selector: 'app-vip-package',
  standalone: true,
  imports: [
    NzTableModule,
    NzButtonModule,
    NzInputModule,
    NzIconModule,
    NzModalModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
  ],
  templateUrl: './vip-package.component.html',
  styleUrl: './vip-package.component.css',
})
export class VipPackageComponent implements OnInit {
  // init
  private vipPackageService = inject(VipPackageService);
  private messageServies = inject(MessageService);
  private modal = inject(NzModalService);
  originalVipPackages: VipPackage[] = [];

  ngOnInit(): void {
    this.loadVipPackage();
    this.initForm();
  }

  //load genre
  vipPackages: VipPackage[] = [];

  loadVipPackage() {
    this.vipPackageService.getAll().subscribe({
      next: (res) => {
        this.vipPackages = res;
        this.originalVipPackages = this.vipPackages;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }
  onSearch() {
    if (this.search) {
      const searchTerm = this.search.toLowerCase();
      this.vipPackages = this.originalVipPackages.filter((vp) =>
        vp.name.toLowerCase().includes(searchTerm)
      );
    } else {
      this.vipPackages = this.originalVipPackages;
    }
  }

  // form add edit vip package
  private fb = inject(FormBuilder);
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  isUpdate = false;
  validationErrors?: string[];
  private vipPackageId: number = 0;
  search: string = '';

  initForm() {
    this.frm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      durationDay: [1],
      price: [1],
      priceSell: [1],
    });
  }

  showModal(id?: number) {
    if (id != null) {
      this.isUpdate = true;
      this.vipPackageId = id;
      const vipPackage = this.vipPackages.find((vp) => vp.id == id);
      this.frm.patchValue({
        name: vipPackage?.name,
        description: vipPackage?.description,
        price: vipPackage?.price,
        priceSell: vipPackage?.priceSell,
        durationDay: vipPackage?.durationDay,
      });
    }
    this.isVisibleModal = true;
  }

  closeModal() {
    this.isVisibleModal = false;
    this.isUpdate = false;
    this.vipPackageId = 0;
    this.validationErrors = [];
    this.frm.reset();
  }

  onSubmit() {
    // update
    if (this.isUpdate === true && this.vipPackageId != 0) {
      const vipPackage: VipPackage = {
        id: this.vipPackageId,
        name: this.frm.value.name,
        description: this.frm.value.description,
        price: this.frm.value.price,
        priceSell: this.frm.value.priceSell,
        durationDay: this.frm.value.durationDay,
      };

      this.vipPackageService.update(vipPackage.id, vipPackage).subscribe({
        next: (res) => {
          const index = this.vipPackages.findIndex(
            (vp) => vp.id === vipPackage.id
          );
          this.vipPackages[index] = res;
          this.messageServies.showSuccess('Cập nhật gói đăng ký thành công');
          this.closeModal();
        },
        error: (er) => {
          this.validationErrors = er;
        },
      });
    } else {
      // add
      const vipPackageAdd: VipPackageCreate = {
        name: this.frm.value.name,
        description: this.frm.value.description,
        price: this.frm.value.price,
        priceSell: this.frm.value.priceSell,
        durationDay: this.frm.value.durationDay,
      };

      this.vipPackageService.add(vipPackageAdd).subscribe({
        next: (res) => {
          this.vipPackages.unshift(res);
          this.messageServies.showSuccess('Thêm gói đăng ký thành công');
          this.closeModal();
        },
        error: (er) => {
          this.validationErrors = er;
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

        this.vipPackageService.delete(id).subscribe({
          next: (_) => {
            const index = this.vipPackages.findIndex((vp) => vp.id === id);
            this.vipPackages.splice(index, 1);
            this.messageServies.showSuccess('Xóa gói đăng ký thành công');
          },
          error: (er) => (this.validationErrors = er),
        });
      },
      nzCancelText: 'No',
      nzOnCancel: () => this.messageServies.showInfo('Hủy xóa'),
    });
  }
}
