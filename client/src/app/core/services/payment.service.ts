import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { VipPackage } from '../../shared/models/vip-package';
import {
  PaymentRequest,
  PaymentReturnResponse,
} from '../../shared/models/payment';

@Injectable({
  providedIn: 'root',
})
export class PaymentService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  paymentSuccessed = false;
  paymentFailed = false;

  getPaymentUrl(vipPackage: VipPackage) {
    return this.http.post<string>(this.baseUrl + 'payment', vipPackage);
  }

  getPaymentReturn(paymentRequest: PaymentRequest) {
    return this.http.post<PaymentReturnResponse>(
      this.baseUrl + 'payment/return',
      paymentRequest
    );
  }
}
