import { Component, inject, ViewChild } from '@angular/core';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { AuthService } from '../../../../core/services/auth.service';
import { CommonModule } from '@angular/common';
import { LikedSongComponent } from '../liked-song/liked-song.component';
import { LikedPlaylistComponent } from '../liked-playlist/liked-playlist.component';
import { LikedSingerComponent } from '../liked-singer/liked-singer.component';
import { MyPlaylistComponent } from '../my-playlist/my-playlist.component';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { UpdateUserComponent } from '../../../../shared/component/users/update-user/update-user.component';
import { ListTransactionComponent } from "../list-transaction/list-transaction.component";
@Component({
  selector: 'app-my-profile',
  standalone: true,
  imports: [
    NzTabsModule,
    CommonModule,
    LikedSongComponent,
    LikedPlaylistComponent,
    LikedSingerComponent,
    MyPlaylistComponent,
    NzIconModule,
    UpdateUserComponent,
    ListTransactionComponent
],
  templateUrl: './my-profile.component.html',
  styleUrl: './my-profile.component.css',
})
export class MyProfileComponent {
  authService = inject(AuthService);
  // 1: likedSong
  // 2: likePlaylist
  // 3: likeSinger
  // 4: myPlaylist
  currentComponent = 1;

  showComponent(component: number) {
    this.currentComponent = component;
  }

  @ViewChild(UpdateUserComponent)
  updateUserComponent!: UpdateUserComponent;
  openUpdateModal(userName: string) {
    if (this.updateUserComponent) {
      this.updateUserComponent.userName = userName;
      this.updateUserComponent.showModal();
    } else {
      console.error('UpdateUserComponent is not initialized yet');
    }
  }
}
