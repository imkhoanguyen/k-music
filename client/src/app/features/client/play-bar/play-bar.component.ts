import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NzIconModule } from 'ng-zorro-antd/icon';
@Component({
  selector: 'app-play-bar',
  standalone: true,
  imports: [NzIconModule, CommonModule],
  templateUrl: './play-bar.component.html',
  styleUrl: './play-bar.component.css',
})
export class PlayBarComponent {
  songName = 'Tên bài hát';
  songSinger = 'Tên ca sĩ';
  songImage =
    'https://y.qq.com/music/photo_new/T002R300x300M000003Ien5H1QRLYa.jpg?max_age=2592000';
  songUrl = '';
  songDuration = 0;
  currentTime = 0;
  isPlaying = false;
  volume = 1;

  togglePlay() {
    this.isPlaying = !this.isPlaying;
    const audioPlayer = <HTMLAudioElement>(
      document.getElementById('audio_player')
    );
    if (this.isPlaying) {
      audioPlayer.play();
    } else {
      audioPlayer.pause();
    }
  }
}
