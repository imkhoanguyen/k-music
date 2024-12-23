import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import {
  Transaction,
  TransactionParams,
  UserVipSubcription,
} from '../../shared/models/transaction';
import { PaginatedResult } from '../../shared/models/pagination';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TransactionService {
  private http = inject(HttpClient);
  private baseUrl = `${environment.apiUrl}admin/`;

  getAll(prm: TransactionParams) {
    let paginationResult: PaginatedResult<Transaction[]> = new PaginatedResult<
      Transaction[]
    >();
    let params = new HttpParams();
    params = params.append('pageNumber', prm.pageNumber);
    params = params.append('pageSize', prm.pageSize);
    params = params.append('orderBy', prm.orderBy);

    if (prm.searchTerm) {
      params = params.append('search', prm.searchTerm);
    }

    if (prm.startDate && prm.endDate) {
      params = params.append('startDate', prm.startDate);
      params = params.append('endDate', prm.endDate);
    }

    return this.http
      .get<Transaction[]>(this.baseUrl + 'transaction', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          paginationResult.result = response.body as Transaction[];

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            paginationResult.pagination = JSON.parse(pagination);
          }
          return paginationResult;
        })
      );
  }

  get(id: number) {
    return this.http.get<UserVipSubcription>(
      this.baseUrl + `transaction/${id}`
    );
  }
}
