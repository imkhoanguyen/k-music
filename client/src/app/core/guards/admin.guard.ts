import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { MessageService } from '../services/message.service';

export const adminGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  const messageService = inject(MessageService);

  const currentUser = authService.currentUser();
  const haveAccessAdminPage = authService.hasClaim('Access_Admin');

  if (currentUser && haveAccessAdminPage) {
    return true;
  }

  if (!currentUser) {
    messageService.showInfo('Vui lòng đăng nhập');
    router.navigate(['/login']);
  } else {
    messageService.showInfo('Bạn không có quyền truy cập vào trang này');
    router.navigate(['/']);
  }

  return false;
};
