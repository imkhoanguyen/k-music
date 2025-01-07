import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { PaginatedResult } from '../../shared/models/pagination';
import { PermissionGroup, Role, RoleParams } from '../../shared/models/role';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  private http = inject(HttpClient);
  baseUrl = `${environment.apiUrl}admin/`;

  getRoles(prm: RoleParams) {
    let paginatedResult: PaginatedResult<Role[]> = new PaginatedResult<
      Role[]
    >();
    let params = new HttpParams();
    if (prm.pageNumber && prm.pageSize) {
      params = params.append('pageNumber', prm.pageNumber);
      params = params.append('pageSize', prm.pageSize);
    }

    if (prm.orderBy) params = params.append('orderBy', prm.orderBy);

    if (prm.searchTerm) params = params.append('search', prm.searchTerm);

    return this.http
      .get<Role[]>(this.baseUrl + 'role', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          if (response.body) {
            paginatedResult.result = response.body;
          }
          const pagination = response.headers.get('Pagination');
          if (pagination) {
            paginatedResult.pagination = JSON.parse(pagination);
          }
          return paginatedResult;
        })
      );
  }

  addRole(role: Role) {
    return this.http.post<Role>(this.baseUrl + 'role', role);
  }

  updateRole(roleId: string, role: Role) {
    return this.http.put<Role>(`${this.baseUrl}role/${roleId}`, role);
  }

  deleteRole(roleId: string) {
    return this.http.delete(`${this.baseUrl}role/${roleId}`);
  }

  getAllRoles() {
    return this.http.get<Role[]>(this.baseUrl + 'role/all');
  }

  getAllPermission() {
    return this.http.get<PermissionGroup[]>(this.baseUrl + 'role/permissions');
  }

  getRole(roleId: string) {
    return this.http.get<Role>(this.baseUrl + `role/${roleId}`);
  }

  getRoleClaims(roleId: string) {
    return this.http.get<string[]>(this.baseUrl + `role/claims/${roleId}`);
  }

  updateRoleClaim(roleId: string, listClaimValue: string[]) {
    return this.http.put(
      this.baseUrl + `role/update-claims/${roleId}`,
      listClaimValue
    );
  }
}
