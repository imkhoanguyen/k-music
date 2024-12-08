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

  // format date vietnam
  private readonly defaultDate = '0001-01-01T00:00:00';
  getFormattedDate(date: string | null): string {
    if (!date || date === this.defaultDate) {
      return 'Chưa cập nhật';
    }

    const options: Intl.DateTimeFormatOptions = {
      day: '2-digit',
      month: '2-digit',
      year: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
      second: '2-digit',
      hour12: false,
    };

    return new Date(date).toLocaleString('vi-VN', options);
  }

  // get genre and song string
  getGenresString(song: Song) {
    return song.genres.map((g: Genre) => g.name).join(', ');
  }

  getSingersString(song: Song) {
    return song.singers.map((s: Singer) => s.name).join(', ');
  }
}
