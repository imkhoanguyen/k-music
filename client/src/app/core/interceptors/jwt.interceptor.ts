import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { MessageService } from '../services/message.service';
import { Router } from '@angular/router';
import { catchError, switchMap, throwError } from 'rxjs';
import { User } from '../../shared/models/user';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const messageService = inject(MessageService);
  const router = inject(Router);
  let currentUser = authService.currentUser();
  if (currentUser) {
    const accessToken = currentUser.accessToken;
    const refreshToken = currentUser.refreshToken;
    let authorization = `Bearer ${accessToken}`;

    return next(req.clone({ setHeaders: { authorization } })).pipe(
      catchError((error) => {
        console.log(error);
        if (error instanceof HttpErrorResponse && error.status === 401) {
          if (refreshToken) {
            return authService.callRefreshToken(refreshToken).pipe(
              switchMap((res: User) => {
                authService.setCurrentUser(res);

                authorization = `Bearer ${res.accessToken}`;
                return next(req.clone({ setHeaders: { authorization } }));
              }),
              catchError((er) => {
                authService.logout();
                messageService.showInfo(
                  'Phiên đăng nhập đã hết hạn, vui lòng đăng nhập lại'
                );
                router.navigate(['/login']);
                return throwError(
                  () => new Error('Phiên đăng nhập đã hết hạn 1 ')
                );
              })
            );
          } else {
            authService.logout();
            messageService.showInfo(
              'Phiên đăng nhập đã hết hạn, vui lòng đăng nhập lại'
            );
            router.navigate(['/login']);
            return throwError(() => new Error('Phiên đăng nhập đã hết hạn 2'));
          }
        } else {
          // Xử lý lỗi khác nếu có
          return throwError(() => error);
        }
      })
    );
  } else {
    return next(req);
  }
};
