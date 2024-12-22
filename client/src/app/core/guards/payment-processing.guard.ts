import { CanActivateFn, Router } from '@angular/router';
import { PaymentService } from '../services/payment.service';
import { inject } from '@angular/core';

export const paymentProcessingGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const canActive = localStorage.getItem('paymentProcessing');
  console.log(canActive);

  if (canActive === 'true') {
    return true;
  } else {
    router.navigateByUrl('/');
    return false;
  }
};
