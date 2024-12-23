import { Injectable, signal } from '@angular/core';
import { Song } from '../../shared/models/song';

@Injectable({
  providedIn: 'root',
})
export class MusicPlayerService {
  currentSong = signal<Song | null>(null);
  isPlaying = signal<boolean>(false);

  playSong(song: Song) {
    this.currentSong.set(song);
    this.isPlaying.set(true);

    const audioPlayer = document.getElementById(
      'audio_player'
    ) as HTMLAudioElement;
    if (audioPlayer) {
      audioPlayer.src = song.songUrl;
      audioPlayer.play();
    }
  }

  pauseSong() {
    this.isPlaying.set(false);
  }

  resumeSong() {
    this.isPlaying.set(true);
  }
}
