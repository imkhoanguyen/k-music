import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { PaymentService } from '../services/payment.service';

export const paymentSuccessGuard: CanActivateFn = (route, state) => {
  const paymentService = inject(PaymentService);
  const router = inject(Router);

  if (paymentService.paymentSuccessed) {
    return true;
  } else {
    router.navigateByUrl('/');
    return false;
  }
};
