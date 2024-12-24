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
    this.saveCurrentSong(song);
    this.isPlaying.set(true);

    this.saveSongUrlToAudioTag(song.songUrl);
    const audioPlayer = document.getElementById(
      'audio_player'
    ) as HTMLAudioElement;
    audioPlayer.play();
  }

  saveSongUrlToAudioTag(url: string) {
    const audioPlayer = document.getElementById(
      'audio_player'
    ) as HTMLAudioElement;
    if (audioPlayer) {
      audioPlayer.src = url;
    }
  }

  saveCurrentSong(song: Song) {
    localStorage.setItem('currentSong', JSON.stringify(song));
  }

  loadCurrentSong() {
    const savedSong = localStorage.getItem('currentSong');
    if (savedSong) {
      const song = JSON.parse(savedSong);
      this.currentSong.set(song);
      this.saveSongUrlToAudioTag(song.songUrl);
    }
    console.log('vao load currentSong');
  }

  pauseSong() {
    this.isPlaying.set(false);
  }

  resumeSong() {
    this.isPlaying.set(true);
  }
}
