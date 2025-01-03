import { inject, Injectable, signal } from '@angular/core';
import { Song } from '../../shared/models/song';
import { AuthService } from './auth.service';
import { SongService } from './song.service';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root',
})
export class MusicPlayerService {
  private authService = inject(AuthService);
  private songService = inject(SongService);
  private messageService = inject(MessageService);
  currentSong = signal<Song | null>(null);
  isPlaying = signal<boolean>(false);
  currentList = signal<Song[] | []>([]);
  shuffleEnabled = signal<boolean>(false);
  repeatEnabled = signal<boolean>(false);

  playSong(song: Song) {
    this.saveCurrentSong(song);
    if (song.isVip && !this.authService.hasSubcription()) {
      this.nextSong();
      this.messageService.showInfo('Chuyển bài');
    } else {
      // Nếu không phải bài hát VIP hoặc người dùng có subscription
      this.isPlaying.set(true);
      localStorage.setItem('currentTime', '0');
      this.saveSongUrlToAudioTag(song.songUrl);
      const audioPlayer = document.getElementById(
        'audio_player'
      ) as HTMLAudioElement;
      audioPlayer.play();
    }
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
    this.currentSong.set(song);
    localStorage.setItem('currentSong', JSON.stringify(song));
  }

  saveCurrentList(list: Song[]) {
    this.currentList.set(list);
    localStorage.setItem('currentList', JSON.stringify(list));
  }

  loadCurrentSong() {
    const savedSong = localStorage.getItem('currentSong');
    if (savedSong) {
      const song = JSON.parse(savedSong);
      this.currentSong.set(song);
      this.saveSongUrlToAudioTag(song.songUrl);
    }
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
    const currentSong = currentIndex >= 0 ? currentList[currentIndex] : null;

    let nextSong: Song | null = null;

    // Nếu bật Shuffle
    if (this.shuffleEnabled()) {
      let randomIndex;
      do {
        randomIndex = Math.floor(Math.random() * currentList.length);
      } while (randomIndex === currentIndex);
      nextSong = currentList[randomIndex];
    }
    // Phát bài tiếp theo trong danh sách
    else if (currentIndex >= 0 && currentIndex < currentList.length - 1) {
      nextSong = currentList[currentIndex + 1];
    }

    // call api get random songs nếu ko có nextsong
    if (nextSong) {
      this.playSong(nextSong);
    } else {
      this.songService
        .getRandomList(
          currentSong?.genres.map((genre) => genre.id ?? 0) ?? [],
          currentSong?.singers.map((singer) => singer.id ?? 0) ?? []
        )
        .subscribe({
          next: (res) => {
            // lấy các bài hát mới ko trùng với currentList
            const newSongs = res.filter(
              (song) => !currentList.some((current) => current.id === song.id)
            );

            // Thêm các bài mới vào currentList
            const updatedList = [...currentList, ...newSongs];

            this.saveCurrentList(updatedList);

            if (newSongs.length > 0) {
              this.playSong(newSongs[0]); // play bài đầu tiên trong danh sách mới
            }
          },
        });
    }
  }

  prevSong() {
    const currentList = this.currentList();
    const currentIndex = currentList.findIndex(
      (song) => song.id === this.currentSong()?.id
    );

    let prevSong: Song | null = null;

    // Nếu bật Shuffle
    if (this.shuffleEnabled()) {
      const randomIndex = Math.floor(Math.random() * currentList.length);
      prevSong = currentList[randomIndex];
    } else if (currentIndex > 0) {
      // Nếu không phải đầu danh sách, chọn bài hát trước đó
      prevSong = currentList[currentIndex - 1];
    } else {
      // Nếu đang ở đầu danh sách, trở về bài hát cuối cùng
      prevSong = currentList[currentList.length - 1];
    }

    // check bài hát vip
    while (prevSong && prevSong.isVip && !this.authService.hasSubcription()) {
      const newIndex =
        currentList.findIndex((song) => song.id === prevSong?.id) - 1;
      if (newIndex < 0) {
        // Nếu không còn bài hát trước đó, quay lại cuối danh sách
        prevSong = currentList[currentList.length - 1];
      } else {
        prevSong = currentList[newIndex];
      }
    }

    // Nếu tìm được bài không phải VIP hoặc bài hát còn lại
    if (prevSong) {
      this.playSong(prevSong);
    } else {
      this.messageService.showInfo('Không có bài hát hợp lệ.');
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
