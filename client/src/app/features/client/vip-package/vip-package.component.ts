import { Component, inject, OnInit } from '@angular/core';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzListModule } from 'ng-zorro-antd/list';
import { VipPackageService } from '../../../core/services/vip-package.service';
import { VipPackage } from '../../../shared/models/vip-package';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { PaymentService } from '../../../core/services/payment.service';
@Component({
  selector: 'app-vip-package',
  standalone: true,
  imports: [
    NzCardModule,
    NzGridModule,
    NzListModule,
    NzDividerModule,
    NzButtonModule,
    NzBadgeModule,
  ],
  templateUrl: './vip-package.component.html',
  styleUrl: './vip-package.component.css',
})
export class VipPackageComponent implements OnInit {
  private vipPackageService = inject(VipPackageService);
  private paymentService = inject(PaymentService);
  vipPackages: VipPackage[] = [];
  ngOnInit(): void {
    this.loadVipPackages();
  }
  loadVipPackages() {
    this.vipPackageService.getAll().subscribe({
      next: (res) => {
        this.vipPackages = res;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  getDiscountPercent(price: number, priceSell: number): string {
    const discount = ((price - priceSell) / price) * 100;
    return `${Math.round(discount)}%`;
  }

  goPayment(vipPackage: VipPackage) {
    this.paymentService.getPaymentUrl(vipPackage).subscribe({
      next: (res) => {
        if (res) {
          window.location.href = res;
        }
      },
      error: (er) => {
        console.log(er);
      },
    });
  }
}
