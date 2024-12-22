import { Component, inject, OnDestroy } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzResultModule } from 'ng-zorro-antd/result';
import { PaymentService } from '../../../../core/services/payment.service';

@Component({
  selector: 'app-payment-fail',
  standalone: true,
  imports: [NzButtonModule, NzResultModule, RouterLink],
  templateUrl: './payment-fail.component.html',
  styleUrl: './payment-fail.component.css',
})
export class PaymentFailComponent implements OnDestroy {
  private paymentService = inject(PaymentService);
  ngOnDestroy(): void {
    this.paymentService.paymentFailed = false;
  }
}
