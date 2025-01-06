export interface Login {
  userName: string;
  password: string;
}

export interface Register {
  userName: string;
  email: string;
  password: string;
  gender: string;
  fullName: string;
}

export interface ResetPassword {
  email: string;
  token: string;
  password: string;
}
