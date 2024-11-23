import { BaseParams } from './base-params';

export interface Playlist {
  id: number;
  name: string;
  created: string;
  updated: string;
  imgUrl: string;
  playCount: number;
  userId: string;
  isPublic: boolean;
}

export class PlaylistParams extends BaseParams {
  orderBy: string = 'id_desc';
}
