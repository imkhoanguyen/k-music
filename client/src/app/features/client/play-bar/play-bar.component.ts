import { CommonModule } from '@angular/common';
import {
  Component,
  computed,
  ElementRef,
  inject,
  ViewChild,
} from '@angular/core';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { MusicPlayerService } from '../../../core/services/music-player.service';
import { UtilityService } from '../../../core/services/utility.service';
import { Router, RouterLink } from '@angular/router';
import { Singer } from '../../../shared/models/singer';
@Component({
  selector: 'app-play-bar',
  standalone: true,
  imports: [NzIconModule, CommonModule],
  templateUrl: './play-bar.component.html',
  styleUrl: './play-bar.component.css',
})
export class PlayBarComponent {
  //default value
  songImageDefault =
    'https://y.qq.com/music/photo_new/T002R300x300M000003Ien5H1QRLYa.jpg?max_age=2592000';
  songNameDefault = 'Bài hát';
  songSingerDefault = 'Ca sĩ';
  songUrlDefault = '';

  private musicPlayerService = inject(MusicPlayerService);
  private router = inject(Router);
  utilService = inject(UtilityService);

  currentSong = computed(() => this.musicPlayerService.currentSong());
  isPlaying = computed(() => this.musicPlayerService.isPlaying());
  volume = 1;

  get singers() {
    return this.currentSong()?.singers || [];
  }

  goSingerDetail(singer: Singer) {
    console.log(singer);
    this.router.navigate(['/singer', singer.id]);
  }

  @ViewChild('audioPlayer', { static: true })
  audioPlayer!: ElementRef<HTMLAudioElement>;
  @ViewChild('timeline', { static: true })
  timeline!: ElementRef<HTMLInputElement>;
  @ViewChild('volumeRange', { static: true })
  volumeRange!: ElementRef<HTMLInputElement>;

  ngOnInit() {
    const audio = this.audioPlayer.nativeElement;
    const timeline = this.timeline.nativeElement;
    const volumeRange = this.volumeRange.nativeElement;

    // Update  progress bar and current time during
    audio.addEventListener('timeupdate', () => {
      const currentTime = this.formatTime(audio.currentTime);
      const totalTime = this.formatTime(audio.duration || 0);
      const progress = (audio.currentTime / (audio.duration || 1)) * 100;

      // update ui
      document.getElementById('current-time')!.textContent = currentTime;
      document.getElementById('total-time')!.textContent = totalTime;
      timeline.value = progress.toString();
    });

    // Sync audio time when user changes the progress bar
    timeline.addEventListener('input', () => {
      const newTime = (parseFloat(timeline.value) / 100) * audio.duration;
      audio.currentTime = newTime;
    });

    // Update audio volume
    volumeRange.addEventListener('input', () => {
      audio.volume = parseFloat(volumeRange.value);
    });
  }

  togglePlay() {
    const audio = this.audioPlayer.nativeElement;
    if (this.isPlaying()) {
      this.musicPlayerService.pauseSong();
      audio.pause();
    } else {
      this.musicPlayerService.resumeSong();
      audio.play();
    }
  }

  private formatTime(seconds: number): string {
    const minutes = Math.floor(seconds / 60);
    const remainingSeconds = Math.floor(seconds % 60);
    return `${minutes}:${
      remainingSeconds < 10 ? '0' + remainingSeconds : remainingSeconds
    }`;
  }
}
