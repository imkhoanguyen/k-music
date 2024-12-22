import { CanActivateFn, Router } from '@angular/router';
import { PaymentService } from '../services/payment.service';
import { inject } from '@angular/core';

export const paymentFailedGuard: CanActivateFn = (route, state) => {
  const paymentService = inject(PaymentService);
  const router = inject(Router);

  if (paymentService.paymentFailed) {
    return true;
  } else {
    router.navigateByUrl('/');
    return false;
  }
};
