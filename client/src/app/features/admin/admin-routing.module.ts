import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GenreComponent } from './genre/genre.component';
import { SingerComponent } from './singer/singer.component';
import { SongComponent } from './song/song.component';
import { PlaylistComponent } from './playlist/playlist.component';

// chú ý thứ tự để routing
const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      { path: 'playlist', component: PlaylistComponent },
      { path: 'song', component: SongComponent },
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
