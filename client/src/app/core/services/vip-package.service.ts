import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { VipPackage, VipPackageCreate } from '../../shared/models/vip-package';

@Injectable({
  providedIn: 'root',
})
export class VipPackageService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;

  getAll() {
    return this.http.get<VipPackage[]>(this.baseUrl + 'vippackage');
  }

  get(id: number) {
    return this.http.get<VipPackage>(this.baseUrl + `vippackage/${id}`);
  }

  add(vippackage: VipPackageCreate) {
    return this.http.post<VipPackage>(this.baseUrl + 'vippackage', vippackage);
  }

  update(id: number, vippackage: VipPackage) {
    return this.http.put<VipPackage>(
      this.baseUrl + `vippackage/${id}`,
      vippackage
    );
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + `vippackage/${id}`);
  }
}
