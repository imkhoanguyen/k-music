import { Routes } from '@angular/router';
import { ServerErrorComponent } from './shared/component/server-error/server-error.component';
import { NotFoundComponent } from './shared/component/not-found/not-found.component';
import { LoginComponent } from './shared/component/login/login.component';

export const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () =>
      import('./features/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: '', // default
    loadChildren: () =>
      import('./features/client/client.module').then((m) => m.ClientModule),
  },
  { path: 'login', component: LoginComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' },
];
