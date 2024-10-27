import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () =>
      import('./features/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: '',
    loadChildren: () =>
      import('./features/client/client.module').then((m) => m.ClientModule),
  }, // Default route
  { path: '**', redirectTo: 'home' }, // Wildcard route for invalid URLs
];