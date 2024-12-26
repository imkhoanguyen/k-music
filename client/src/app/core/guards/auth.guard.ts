import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { MessageService } from '../services/message.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  const messageService = inject(MessageService);

  const currentUser = authService.currentUser();

  if (currentUser) {
    return true;
  }

  if (!currentUser) {
    messageService.showInfo('Vui lòng đăng nhập');
    router.navigate(['/login']);
  }

  return false;
};
