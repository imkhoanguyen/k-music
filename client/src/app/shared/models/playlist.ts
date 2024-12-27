import { BaseParams } from './base-params';
import { Song } from './song';

export interface Playlist {
  id: number;
  name: string;
  created: string;
  updated: string;
  imgUrl: string;
  userName: string;
  isPublic: boolean;
}

export interface PlaylistDetail extends Playlist {
  songList: Song[];
}

export class PlaylistParams extends BaseParams {
  orderBy: string = 'id_desc';
}

export interface QuickViewResponse {
  id: number;
  name: string;
  imgUrl: string;
  haveSong: boolean;
  isPublic: boolean;
}

export interface AddOrDeleteRequest {
  songId: number;
  playlistId: number;
}