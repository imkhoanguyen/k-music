import { AppUser } from './user';
import { VipPackage } from './vip-package';

export interface PaymentRequest {
  orderInfo: number;
  responseCode: string;
}

export interface PaymentReturnResponse {
  id: number;
  vipPackage: VipPackage;
  appUser: AppUser;
  startDate: string;
  endDate: string;
  price: number;
  durationDay: number;
  description: string;
}
