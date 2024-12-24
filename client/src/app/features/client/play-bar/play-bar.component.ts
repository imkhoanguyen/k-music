import { CommonModule } from '@angular/common';
import {
  Component,
  computed,
  ElementRef,
  inject,
  OnInit,
  ViewChild,
} from '@angular/core';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { MusicPlayerService } from '../../../core/services/music-player.service';
import { UtilityService } from '../../../core/services/utility.service';
import { Router } from '@angular/router';
import { Singer } from '../../../shared/models/singer';
import { MessageService } from '../../../core/services/message.service';
@Component({
  selector: 'app-play-bar',
  standalone: true,
  imports: [NzIconModule, CommonModule],
  templateUrl: './play-bar.component.html',
  styleUrl: './play-bar.component.css',
})
export class PlayBarComponent implements OnInit {
  //default value
  songImageDefault =
    'https://y.qq.com/music/photo_new/T002R300x300M000003Ien5H1QRLYa.jpg?max_age=2592000';
  songNameDefault = 'Bài hát';
  songSingerDefault = 'Ca sĩ';
  songUrlDefault = '';

  private musicPlayerService = inject(MusicPlayerService);
  private router = inject(Router);
  private messageService = inject(MessageService);
  utilService = inject(UtilityService);

  currentSong = computed(() => this.musicPlayerService.currentSong());
  isPlaying = computed(() => this.musicPlayerService.isPlaying());
  repeatEnable = computed(() => this.musicPlayerService.repeatEnabled());
  shuffleEnable = computed(() => this.musicPlayerService.shuffleEnabled());
  totalTime = 0;
  isMute = false;

  get singers() {
    return this.currentSong()?.singers || [];
  }

  get songId() {
    return this.currentSong()?.id || 0;
  }

  @ViewChild('audioPlayer', { static: true })
  audioPlayer!: ElementRef<HTMLAudioElement>;
  @ViewChild('timeline', { static: true })
  timeline!: ElementRef<HTMLInputElement>;
  @ViewChild('volumeRange', { static: true })
  volumeRange!: ElementRef<HTMLInputElement>;

  // handle audio src change
  onMetadataLoaded(event: Event) {
    const audioElement = event.target as HTMLAudioElement;
    const volumeRange = this.volumeRange.nativeElement;
    //update totalTime
    this.totalTime = audioElement.duration ?? 0; // Thời lượng tính bằng giây
    this.updateUITotalTime(this.formatTime(this.totalTime));

    //update currentTime
    audioElement.currentTime = +this.musicPlayerService.getCurrentTime();
    this.updateUICurrentTime(this.formatTime(audioElement.currentTime));
    // update volume
    volumeRange.value = this.musicPlayerService.getVolume();
    audioElement.volume = +volumeRange.value;
  }

  ngOnInit() {
    this.musicPlayerService.loadCurrentSong();
    this.musicPlayerService.loadCurrentList();
    this.musicPlayerService.loadRepeat();
    this.musicPlayerService.loadShuffle();
    this.currentSong = computed(() => this.musicPlayerService.currentSong());
    this.isPlaying = computed(() => this.musicPlayerService.isPlaying());
    this.repeatEnable = computed(() => this.musicPlayerService.repeatEnabled());
    this.shuffleEnable = computed(() =>
      this.musicPlayerService.shuffleEnabled()
    );

    const audio = this.audioPlayer.nativeElement;
    const timeline = this.timeline.nativeElement;
    const volumeRange = this.volumeRange.nativeElement;

    // Update  progress bar & current, total time when timeupdate
    audio.addEventListener('timeupdate', () => {
      const currentTime = this.formatTime(audio.currentTime);
      const totalTime = this.formatTime(audio.duration || 0);
      const progress = (audio.currentTime / (audio.duration || 1)) * 100;

      // update ui
      this.updateUICurrentTime(currentTime);
      this.updateUITotalTime(totalTime);
      timeline.value = progress.toString();
    });

    // handle volume change
    audio.addEventListener('volumechange', () => {
      if (audio.volume === 0) {
        this.isMute = true;
      } else {
        this.isMute = false;
        localStorage.setItem('volume', audio.volume.toString());
      }
    });

    audio.addEventListener('ended', () => {
      const currentSong = this.currentSong();
      if (currentSong) {
        if (this.repeatEnable()) {
          this.musicPlayerService.playSong(currentSong);
        } else {
          this.nextSong();
        }
      } else {
        // current song null
        this.messageService.showWarning('Chưa có bài hát được chọn');
      }
    });

    // Sync audio time when user changes the progress bar
    timeline.addEventListener('input', () => {
      const newTime = (parseFloat(timeline.value) / 100) * audio.duration;
      audio.currentTime = newTime;
      localStorage.setItem('currentTime', audio.currentTime.toString());
    });

    // Update audio volume
    volumeRange.addEventListener('input', () => {
      audio.volume = parseFloat(volumeRange.value);
    });

    // save current timen & value volume to localStorage
    window.onbeforeunload = () => {
      localStorage.setItem('currentTime', audio.currentTime.toString());
      localStorage.setItem('volume', volumeRange.value);
    };
  }

  updateUICurrentTime(currentTime: string) {
    document.getElementById('current-time')!.textContent = currentTime;
  }

  updateUITotalTime(totalTime: string) {
    document.getElementById('total-time')!.textContent = totalTime;
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

  nextSong() {
    this.musicPlayerService.nextSong();
  }

  prevSong() {
    this.musicPlayerService.prevSong();
  }

  toggleSound() {
    const audio = this.audioPlayer.nativeElement;
    const volumeRange = this.volumeRange.nativeElement;
    const currentVolume = this.musicPlayerService.getVolume();
    if (this.isMute == false) {
      this.isMute = true;
      audio.volume = 0;
      volumeRange.value = '0';
    } else {
      this.isMute = false;
      audio.volume = +currentVolume;
      volumeRange.value = currentVolume;
      localStorage.setItem('volume', currentVolume);
    }
  }

  toggleShuffle() {
    this.musicPlayerService.toggleShuffle();
  }

  toggleRepeat() {
    this.musicPlayerService.toggleRepeat();
  }

  download() {
    const currentSong = this.currentSong();
    if (currentSong && currentSong.songUrl) {
      const anchor = document.createElement('a');
      anchor.href = currentSong.songUrl;
      anchor.download = `${currentSong.name || 'song'}.mp3`;
      document.body.appendChild(anchor);
      anchor.click();
      document.body.removeChild(anchor);
    } else {
      this.messageService.showWarning('Bài hát ko có sẵn để tải xuống');
    }
  }

  private formatTime(seconds: number): string {
    const minutes = Math.floor(seconds / 60);
    const remainingSeconds = Math.floor(seconds % 60);
    return `${minutes}:${
      remainingSeconds < 10 ? '0' + remainingSeconds : remainingSeconds
    }`;
  }

  goSingerDetail(singer: Singer) {
    console.log(singer);
    this.router.navigate(['/singer', singer.id]);
  }

  goSongDetail(songId: number) {
    this.router.navigate(['/song', songId]);
  }
}
