import { Routes } from '@angular/router';
import { ServerErrorComponent } from './shared/component/server-error/server-error.component';
import { NotFoundComponent } from './shared/component/not-found/not-found.component';
import { LoginComponent } from './shared/component/login/login.component';
import { RegisterComponent } from './shared/component/register/register.component';
import { adminGuard } from './core/guards/admin.guard';
import { authGuard } from './core/guards/auth.guard';
import { ForgotPasswordComponent } from './shared/component/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './shared/component/reset-password/reset-password.component';

export const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () =>
      import('./features/admin/admin.module').then((m) => m.AdminModule),
    canActivate: [authGuard, adminGuard],
  },
  {
    path: '', // default
    loadChildren: () =>
      import('./features/client/client.module').then((m) => m.ClientModule),
  },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' },
];
