import { BaseParams } from './base-params';

export interface Singer {
  id?: number;
  name: string;
  gender: string;
  introduction: string;
  location: string;
  imgUrl: string;
}

export class SingerParams extends BaseParams {
  orderBy: string = 'id_desc';
  gender: string = '';
  location: string = '';
}
