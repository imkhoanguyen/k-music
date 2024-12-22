import { BaseParams } from './base-params';
import { AppUser } from './user';
import { VipPackage } from './vip-package';

export interface Transaction {
  id: number;
  name: string;
  price: number;
  durationDay: number;
  description: string;
  userName: string;
  startDate: string;
  endDate: string;
}

export interface UserVipSubcription {
  id: number;
  vipPackage: VipPackage;
  price: number;
  startDate: string;
  endDate: string;
  appUser: AppUser;
  userId: string;
  vipPackageId: number;
}

export class TransactionParams extends BaseParams {
  orderBy = 'id_desc';
  startDate = '';
  endDate = '';
}
