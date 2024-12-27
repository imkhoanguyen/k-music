import { BaseParams } from './base-params';
import { Genre } from './genre';
import { Singer } from './singer';

export interface Song {
  id: number;
  name: string;
  imgUrl: string;
  songUrl: string;
  introduction: string;
  lyric: string;
  created: string;
  updated: string;
  isVip: boolean;
  singers: Singer[];
  genres: Genre[];
}

export interface SongHaveLike extends Song {
  liked: boolean;
}

export class SongParams extends BaseParams {
  orderBy: string = 'id_desc';
  genreList: number[] = [];
}
