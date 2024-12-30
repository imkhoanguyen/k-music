import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { AppUser, UserParams } from '../../shared/models/user';
import { PaginatedResult } from '../../shared/models/pagination';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl + 'admin/';

  getUsers(prm: UserParams) {
    let paginationResult: PaginatedResult<AppUser[]> = new PaginatedResult<
      AppUser[]
    >();
    let params = new HttpParams();
    params = params.append('pageNumber', prm.pageNumber);
    params = params.append('pageSize', prm.pageSize);
    params = params.append('orderBy', prm.orderBy);

    if (prm.searchTerm) {
      params = params.append('search', prm.searchTerm);
    }

    return this.http
      .get<AppUser[]>(this.baseUrl + 'user', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          paginationResult.result = response.body as AppUser[];

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            paginationResult.pagination = JSON.parse(pagination);
          }
          return paginationResult;
        })
      );
  }

  add(formData: FormData) {
    return this.http.post<AppUser>(this.baseUrl + 'user', formData);
  }

  getUser(userName: string) {
    let params = new HttpParams();
    params = params.append('userName', userName);
    return this.http.get<AppUser>(this.baseUrl + 'user/get-user', {
      observe: 'response',
      params,
    });
  }

  updateInformation(userName: string, formData: FormData) {
    let params = new HttpParams();
    params = params.append('userName', userName);
    return this.http.put<AppUser>(
      this.baseUrl + 'user/update-information',
      formData,
      { params }
    );
  }

  changePassword(
    userName: string,
    currentPassword: string,
    newPassword: string
  ) {
    return this.http.put(
      this.baseUrl + `user/change-password?userName=${userName}`,
      { currentPassword: currentPassword, password: newPassword }
    );
  }
}
