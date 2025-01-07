import {
  ApplicationConfig,
  provideZoneChangeDetection,
  importProvidersFrom,
} from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { en_US, provideNzI18n } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { FormsModule } from '@angular/forms';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { errorInterceptor } from './core/interceptors/error.interceptor';
import { loadingInterceptor } from './core/interceptors/loading.interceptor';
import { provideNzIcons } from 'ng-zorro-antd/icon';

// Import specific icons
import {
  EyeOutline,
  EyeInvisibleOutline,
  PlusCircleOutline,
  MinusCircleOutline,
  PlaySquareOutline,
  HeartOutline,
  CommentOutline,
  KeyOutline,
  RetweetOutline,
  DownloadOutline,
  HeartFill,
  LockOutline,
  SendOutline,
} from '@ant-design/icons-angular/icons';
import { jwtInterceptor } from './core/interceptors/jwt.interceptor';
import { OAuthModule } from 'angular-oauth2-oidc';

// Define icons array
const icons = [
  EyeOutline,
  EyeInvisibleOutline,
  PlusCircleOutline,
  MinusCircleOutline,
  PlaySquareOutline,
  HeartOutline,
  CommentOutline,
  KeyOutline,
  RetweetOutline,
  DownloadOutline,
  HeartFill,
  LockOutline,
  SendOutline,
];
registerLocaleData(en);

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideNzI18n(en_US),
    importProvidersFrom(FormsModule),
    provideAnimationsAsync(),
    provideHttpClient(
      withInterceptors([errorInterceptor, jwtInterceptor, loadingInterceptor])
    ),
    provideNzIcons(icons),
    importProvidersFrom(OAuthModule.forRoot()),
  ],
};
