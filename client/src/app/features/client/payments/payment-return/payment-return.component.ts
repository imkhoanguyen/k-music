import { Component, inject, OnInit } from '@angular/core';
import { PaymentService } from '../../../../core/services/payment.service';
import { ActivatedRoute } from '@angular/router';
import { PaymentRequest } from '../../../../shared/models/payment';

@Component({
  selector: 'app-payment-return',
  standalone: true,
  imports: [],
  templateUrl: './payment-return.component.html',
  styleUrl: './payment-return.component.css',
})
export class PaymentReturnComponent implements OnInit {
  private paymentService = inject(PaymentService);
  private activateRoute = inject(ActivatedRoute);
  ngOnInit(): void {
    const queryParams = this.activateRoute.snapshot.queryParams;
    const paymentRequest: PaymentRequest = {
      responseCode: queryParams['vnp_ResponseCode'],
      orderInfo: +queryParams['vnp_OrderInfo'],
    };
    this.paymentService.getPaymentReturn(paymentRequest).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (er) => {
        console.log(er);
      },
    });
  }
}
