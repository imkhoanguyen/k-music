import { Injectable, signal } from '@angular/core';
import { Song } from '../../shared/models/song';

@Injectable({
  providedIn: 'root',
})
export class MusicPlayerService {
  currentSong = signal<Song | null>(null);
  isPlaying = signal<boolean>(false);
  currentList = signal<Song[] | []>([]);
  shuffleEnabled = signal<boolean>(false);
  repeatEnabled = signal<boolean>(false);

  playSong(song: Song) {
    this.currentSong.set(song);
    this.saveCurrentSong(song);
    this.isPlaying.set(true);
    localStorage.setItem('currentTime', '0');
    this.saveSongUrlToAudioTag(song.songUrl);
    const audioPlayer = document.getElementById(
      'audio_player'
    ) as HTMLAudioElement;
    audioPlayer.play();
  }

  playList(list: Song[]) {
    this.currentList.set(list);
    this.saveCurrentList(list);
    this.playSong(list[0]);
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

  saveCurrentList(list: Song[]) {
    localStorage.setItem('currentList', JSON.stringify(list));
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

  loadCurrentList() {
    const saveList = localStorage.getItem('currentList');
    if (saveList) {
      const list = JSON.parse(saveList);
      this.currentList.set(list);
    }
  }

  loadShuffle() {
    const saved = localStorage.getItem('shuffle');
    if (saved) {
      const shuffle = JSON.parse(saved);
      this.shuffleEnabled.set(Boolean(shuffle));
    }
  }

  loadRepeat() {
    const saved = localStorage.getItem('repeat');
    if (saved) {
      const repeat = JSON.parse(saved);
      this.repeatEnabled.set(Boolean(repeat));
    }
  }

  pauseSong() {
    this.isPlaying.set(false);
  }

  resumeSong() {
    this.isPlaying.set(true);
  }

  nextSong() {
    const currentList = this.currentList();
    const currentIndex = currentList.findIndex(
      (song) => song.id === this.currentSong()?.id
    );

    let nextSong: Song | null = null;

    // Nếu bật Shuffle
    if (this.shuffleEnabled()) {
      const randomIndex = Math.floor(Math.random() * currentList.length);
      nextSong = currentList[randomIndex];
    } else if (currentIndex >= 0 && currentIndex < currentList.length - 1) {
      nextSong = currentList[currentIndex + 1];
    }

    if (nextSong) {
      this.playSong(nextSong);
    }
  }

  prevSong() {
    const currentList = this.currentList();
    const currentIndex = currentList.findIndex(
      (song) => song.id === this.currentSong()?.id
    );

    let nextSong: Song | null = null;

    // Nếu bật Shuffle
    if (this.shuffleEnabled()) {
      const randomIndex = Math.floor(Math.random() * currentList.length);
      nextSong = currentList[randomIndex];
    } else if (currentIndex >= 0 && currentIndex < currentList.length - 1) {
      nextSong = currentList[currentIndex - 1];
    }

    if (nextSong) {
      this.playSong(nextSong);
    }
  }

  toggleShuffle() {
    const text = !this.shuffleEnabled();
    this.shuffleEnabled.set(!this.shuffleEnabled());
    localStorage.setItem('shuffle', text.toString());
  }

  toggleRepeat() {
    const text = !this.repeatEnabled();
    this.repeatEnabled.set(text);
    localStorage.setItem('repeat', text.toString());
  }

  getCurrentTime(): string {
    return localStorage.getItem('currentTime') ?? '0';
  }

  getVolume(): string {
    return localStorage.getItem('volume') ?? '1';
  }
}
