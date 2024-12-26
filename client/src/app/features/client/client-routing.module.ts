import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientLayoutComponent } from './client-layout/client-layout.component';
import { HomeComponent } from './home/home.component';
import { PlaylistDetailComponent } from './playlist/playlist-detail/playlist-detail.component';
import { SongListComponent } from './song/song-list/song-list.component';
import { SongDetailComponent } from './song/song-detail/song-detail.component';
import { SingerListComponent } from './singer/singer-list/singer-list.component';
import { SingerDetailComponent } from './singer/singer-detail/singer-detail.component';
import { VipPackageComponent } from './vip-package/vip-package.component';
import { PaymentReturnComponent } from './payments/payment-return/payment-return.component';
import { PaymentSuccessComponent } from './payments/payment-success/payment-success.component';
import { paymentSuccessGuard } from '../../core/guards/payment-success.guard';
import { paymentProcessingGuard } from '../../core/guards/payment-processing.guard';
import { PaymentFailComponent } from './payments/payment-fail/payment-fail.component';
import { paymentFailedGuard } from '../../core/guards/payment-failed.guard';
import { MyProfileComponent } from './profiles/my-profile/my-profile.component';

const routes: Routes = [
  {
    path: '',
    component: ClientLayoutComponent,
    children: [
      { path: '', component: HomeComponent },
      { path: 'profile', component: MyProfileComponent },
      {
        path: 'payment-fail',
        component: PaymentFailComponent,
        canActivate: [paymentFailedGuard],
      },
      {
        path: 'payment-success',
        component: PaymentSuccessComponent,
        canActivate: [paymentSuccessGuard],
      },
      {
        path: 'payment-return',
        component: PaymentReturnComponent,
        canActivate: [paymentProcessingGuard],
      },
      { path: 'vip-package', component: VipPackageComponent },
      { path: 'playlist/:id', component: PlaylistDetailComponent },
      { path: 'song', component: SongListComponent },
      { path: 'song/:id', component: SongDetailComponent },
      { path: 'singer', component: SingerListComponent },
      { path: 'singer/:id', component: SingerDetailComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientRoutingModule {}
