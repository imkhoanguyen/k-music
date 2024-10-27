import { BaseParams } from './base-params';

export interface Genre {
  id?: number;
  name: string;
  description: string;
}

export class GenreParams extends BaseParams {
  orderBy: string = 'id_desc';
}
