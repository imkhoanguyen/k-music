import { Component, inject, Input } from '@angular/core';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzDescriptionsModule } from 'ng-zorro-antd/descriptions';
import { UserVipSubcription } from '../../models/transaction';
import { TransactionService } from '../../../core/services/transaction.service';
import { UtilityService } from '../../../core/services/utility.service';
@Component({
  selector: 'app-transaction-detail',
  standalone: true,
  imports: [NzModalModule, NzDescriptionsModule],
  templateUrl: './transaction-detail.component.html',
  styleUrl: './transaction-detail.component.css',
})
export class TransactionDetailComponent {
  @Input() userVipSubcriptionId: number = 0;
  private transactionService = inject(TransactionService);
  userVipSubcription: UserVipSubcription | any;
  utilService = inject(UtilityService);
  isVisible = false;
  title = '';

  showModal(): void {
    this.transactionService.get(this.userVipSubcriptionId).subscribe({
      next: (res) => {
        if (res) {
          this.isVisible = true;
          this.userVipSubcription = res;
          this.title = 'Thông tin đơn hàng #' + res.id;
        }
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  handleCancel(): void {
    this.userVipSubcriptionId = 0;
    this.isVisible = false;
  }
}
