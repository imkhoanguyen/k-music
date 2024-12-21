import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { VipPackage } from '../../shared/models/vip-package';
import { PaymentRequest } from '../../shared/models/payment';

@Injectable({
  providedIn: 'root',
})
export class PaymentService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getPaymentUrl(vipPackage: VipPackage) {
    return this.http.post<string>(this.baseUrl + 'payment', vipPackage);
  }

  getPaymentReturn(paymentRequest: PaymentRequest) {
    return this.http.post<any>(this.baseUrl + 'payment/return', paymentRequest);
  }
}
