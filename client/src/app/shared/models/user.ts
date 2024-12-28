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
  id: string;
  userName: string;
  fullName: string;
  email: string;
  gender: string;
  imgUrl: string;
}
