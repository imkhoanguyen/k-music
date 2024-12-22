import { BaseParams } from './base-params';

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

export class TransactionParams extends BaseParams {
  orderBy = 'id_desc';
  startDate = '';
  endDate = '';
}
