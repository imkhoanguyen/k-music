import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { MessageService } from '../services/message.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  const messageService = inject(MessageService);

  const currentUser = authService.currentUser();
  const accessToken = currentUser?.accessToken;
  const expiredAccessToken = currentUser?.expiredDateAccessToken;

  if (!accessToken || !expiredAccessToken) {
    messageService.showInfo('Vui lòng đăng nhập');
    router.navigate(['/login']);
    return false;
  }

  const now = new Date();
  const expirationDate = new Date(expiredAccessToken);

  if (expirationDate <= now) {
    const refreshToken = currentUser.refreshToken;
    if (!refreshToken) {
      authService.logout();
      messageService.showInfo(
        'Phiên đăng nhập đã hết hạn, vui lòng đăng nhập lại'
      );
      router.navigate(['/login']);
      return false;
    }

    authService.callRefreshToken(refreshToken).subscribe({
      next: (res) => {
        authService.setCurrentUser(res);
        return true;
      },
      error: (er) => {
        authService.logout();
        messageService.showInfo(
          'Phiên đăng nhập đã hết hạn, vui lòng đăng nhập lại'
        );
        router.navigate(['/login']);
        return false;
      },
    });
  }

  return true;
};
