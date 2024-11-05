import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';
import { finalize } from 'rxjs';
export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const message = inject(NzMessageService);

  const loadingMessageId = message.loading('Loading...', {
    nzDuration: 0,
  }).messageId;

  return next(req).pipe(
    finalize(() => {
      message.remove(loadingMessageId);
    })
  );
};
