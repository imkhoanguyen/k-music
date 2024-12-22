import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { NzResultModule } from 'ng-zorro-antd/result';
import { Transaction } from '../../../../shared/models/transaction';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { UtilityService } from '../../../../core/services/utility.service';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { PaymentService } from '../../../../core/services/payment.service';

@Component({
  selector: 'app-payment-success',
  standalone: true,
  imports: [NzResultModule, RouterLink, NzButtonModule],
  templateUrl: './payment-success.component.html',
  styleUrl: './payment-success.component.css',
})
export class PaymentSuccessComponent implements OnInit, OnDestroy {
  private paymentService = inject(PaymentService);
  transaction: Transaction = {
    id: 0,
    name: '',
    price: 0,
    durationDay: 0,
    description: '',
    userName: '',
    startDate: '',
    endDate: '',
  };
  title = '';
  subTitle = '';
  private activatedRoute = inject(ActivatedRoute);
  private utilService = inject(UtilityService);

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe((params) => {
      this.transaction.id = +params['id'] || 0;
      this.transaction.name = params['name'] || '';
      this.transaction.price = +params['price'] || 0;
      this.transaction.durationDay = +params['durationDay'] || 0;
      this.transaction.description = params['description'] || '';
      this.transaction.startDate = params['startDate'] || '';
      this.transaction.endDate = params['endDate'] || '';
      this.transaction.userName = params['userName'] || '';

      this.title = `Thanh toán thành công gói ${
        this.transaction.name
      } với giá ${this.transaction.price.toLocaleString()}đ!`;
      this.subTitle = `Cảm ơn bạn đã đăng ký gói. Thời hạn sử dụng gói đến hết ${this.utilService.getFormattedDate(
        this.transaction.endDate
      )}.`;
    });
  }

  ngOnDestroy(): void {
    this.paymentService.paymentSuccessed = false;
  }
}
