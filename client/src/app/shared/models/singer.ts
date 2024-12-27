import { BaseParams } from './base-params';
import { PaginatedResult } from './pagination';
import { Song, SongHaveLike } from './song';

export interface Singer {
  id?: number;
  name: string;
  gender: string;
  introduction: string;
  location: string;
  imgUrl: string;
}

export interface SingerDetail extends Singer {
  PaginatedResult: PaginatedResult<Song[]>;
  songList: Song[];
}

export interface SingerDetail1 extends Singer {
  PaginatedResult: PaginatedResult<SongHaveLike[]>;
  songList: SongHaveLike[];
}

export class SingerParams extends BaseParams {
  orderBy: string = 'id_desc';
  gender: string = '';
  location: string = '';
}
