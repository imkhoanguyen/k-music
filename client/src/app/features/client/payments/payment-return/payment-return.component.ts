import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { PaymentService } from '../../../../core/services/payment.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PaymentRequest } from '../../../../shared/models/payment';
import { NzSpinModule } from 'ng-zorro-antd/spin';

@Component({
  selector: 'app-payment-return',
  standalone: true,
  imports: [NzSpinModule],
  templateUrl: './payment-return.component.html',
  styleUrl: './payment-return.component.css',
})
export class PaymentReturnComponent implements OnInit, OnDestroy {
  private paymentService = inject(PaymentService);
  private activateRoute = inject(ActivatedRoute);
  private router = inject(Router);
  ngOnInit(): void {
    const queryParams = this.activateRoute.snapshot.queryParams;
    const paymentRequest: PaymentRequest = {
      responseCode: queryParams['vnp_ResponseCode'],
      orderInfo: +queryParams['vnp_OrderInfo'],
    };
    this.paymentService.getPaymentReturn(paymentRequest).subscribe({
      next: (res) => {
        this.paymentService.paymentSuccessed = true;
        this.router.navigate(['/payment-success'], {
          queryParams: {
            name: res.vipPackage.name,
            startDate: res.startDate,
            endDate: res.endDate,
            userName: res.appUser.userName,
            price: res.price,
            id: res.id,
            durationDay: res.durationDay,
            description: res.description,
          },
        });
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  ngOnDestroy(): void {
    localStorage.removeItem('paymentProcessing');
  }
}
