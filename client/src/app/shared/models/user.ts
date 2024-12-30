import { BaseParams } from './base-params';

// user login
export interface User {
  userName: string;
  fullName: string;
  gender: string;
  imgUrl: string;
  accessToken: string;
  refreshToken: string;
  expiredDateAccessToken: string;
}

export interface AppUser {
  userName: string;
  fullName: string;
  email: string;
  gender: string;
  imgUrl: string;
  role: string;
  isLoocked: boolean;
  created: string;
}

export class UserParams extends BaseParams {
  orderBy: string = 'created_desc';
}
