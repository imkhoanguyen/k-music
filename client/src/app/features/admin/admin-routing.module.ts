import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GenreComponent } from './genre/genre.component';
import { SingerComponent } from './singer/singer.component';
import { SongComponent } from './songs/song/song.component';
import { PlaylistComponent } from './playlists/playlist/playlist.component';
import { SongDetailComponent } from './songs/song-detail/song-detail.component';
import { PlaylistDetailComponent } from './playlists/playlist-detail/playlist-detail.component';
import { RoleComponent } from './role/role.component';
import { RolePermissionComponent } from './role-permission/role-permission.component';
import { VipPackageComponent } from './vip-package/vip-package.component';
import { TransactionComponent } from './transaction/transaction.component';
import { UserComponent } from './user/user.component';

// chú ý thứ tự để routing
const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      { path: 'user', component: UserComponent },
      { path: 'transaction', component: TransactionComponent },
      { path: 'vip-package', component: VipPackageComponent },
      { path: 'role/permission/:id', component: RolePermissionComponent },
      { path: 'role', component: RoleComponent },
      { path: 'playlist', component: PlaylistComponent },
      { path: 'playlist/:id', component: PlaylistDetailComponent },
      { path: 'song', component: SongComponent },
      { path: 'song/:id', component: SongDetailComponent },
      { path: 'singer', component: SingerComponent },
      { path: 'genre', component: GenreComponent },
      { path: '', component: DashboardComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
