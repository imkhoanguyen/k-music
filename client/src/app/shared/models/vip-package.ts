export interface VipPackage {
  id: number;
  name: string;
  price: number;
  priceSell: number;
  durationDay: number;
  description: string;
}

export interface VipPackageCreate {
  name: string;
  price: number;
  priceSell: number;
  durationDay: number;
  description: string;
}
