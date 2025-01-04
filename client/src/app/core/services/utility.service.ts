import { Injectable } from '@angular/core';
import { Song } from '../../shared/models/song';
import { Genre } from '../../shared/models/genre';
import { Singer } from '../../shared/models/singer';

@Injectable({
  providedIn: 'root',
})
export class UtilityService {
  // Constants
  public readonly PUBLIC_STATUS_COLOR = '#38d9a9';
  public readonly PRIVATE_STATUS_COLOR = '#ffa94d';
  public readonly PUBLIC_STATUS_STRING = 'Public';
  public readonly PRIVATE_STATUS_STRING = 'Private';
  public readonly RELATED_TYPE_PLAYLIST = 'Playlist';
  public readonly RELATED_TYPE_SONG = 'Song';
  public readonly RELATED_TYPE_SINGER = 'Singer';

  // format date vietnam
  private readonly defaultDate = '0001-01-01T00:00:00';

  getFormattedDate(date: string | null | undefined): string {
    // Kiểm tra và xử lý khi giá trị không hợp lệ
    if (!date || date === this.defaultDate || isNaN(Date.parse(date))) {
      return 'Chưa cập nhật';
    }

    const dateObj = new Date(date);

    // Format ngày
    const formattedDate = dateObj.toLocaleDateString('vi-VN', {
      day: '2-digit',
      month: '2-digit',
      year: 'numeric',
    });

    // Format giờ
    const formattedTime = dateObj.toLocaleTimeString('vi-VN', {
      hour: '2-digit',
      minute: '2-digit',
      second: '2-digit',
      hour12: false,
    });

    // Trả về chuỗi ngày trước giờ
    return `${formattedDate} ${formattedTime}`;
  }

  // get genre and song string
  getGenresString(song: Song) {
    return song.genres.map((g: Genre) => g.name).join(', ');
  }

  getSingersString(song: Song) {
    return song.singers.map((s: Singer) => s.name).join(', ');
  }

  // format duration
  formatDuration(duration: number): string {
    const minutes = Math.floor(duration / 60);
    const seconds = Math.floor(duration % 60);
    return `${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;
  }

  formatDateToStringWithTime(date: Date): string {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Tháng bắt đầu từ 0
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    const seconds = String(date.getSeconds()).padStart(2, '0');
    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
  }

  formatCurrency(num: number): string {
    return num.toLocaleString('vi-VN') + 'đ';
  }
}
