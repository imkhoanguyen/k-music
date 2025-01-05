import { Playlist } from './playlist';
import { Singer } from './singer';
import { Song } from './song';

export interface DailyRevenue {
  date: string;
  totalRevenue: number;
}

export interface Overview {
  totalPrice: number;
  totalPlaylist: number;
  totalSong: number;
  totalUser: number;
}

export interface TopFavorite {
  songList: Song[];
  playlistList: Playlist[];
  singerList: Singer[];
}
