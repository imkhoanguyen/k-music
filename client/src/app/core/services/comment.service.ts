import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import {
  Comment,
  CommentAdd,
  CommentParams,
  CommentUpdate,
  ReplyAdd,
} from '../../shared/models/comment';
import { PaginatedResult } from '../../shared/models/pagination';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CommentService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;

  getAll(prm: CommentParams) {
    let paginationResult: PaginatedResult<Comment[]> = new PaginatedResult<
      Comment[]
    >();
    let params = new HttpParams();
    params = params.append('pageNumber', prm.pageNumber);
    params = params.append('pageSize', prm.pageSize);
    params = params.append('orderBy', prm.orderBy);
    params = params.append('relatedId', prm.relatedId);

    if (prm.relatedType) {
      params = params.append('relatedType', prm.relatedType);
    }

    return this.http
      .get<Comment[]>(this.baseUrl + 'comment', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          paginationResult.result = response.body as Comment[];

          const pagination = response.headers.get('Pagination');
          if (pagination !== null) {
            paginationResult.pagination = JSON.parse(pagination);
          }
          return paginationResult;
        })
      );
  }

  add(c: CommentAdd) {
    return this.http.post<Comment>(this.baseUrl + 'comment', c);
  }

  addReply(r: ReplyAdd) {
    return this.http.post<Comment>(this.baseUrl + 'comment/reply', r);
  }

  update(c: CommentUpdate) {
    return this.http.put<Comment>(this.baseUrl + `comment/${c.id}`, c);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + `comment/${id}`);
  }

  get(id: number) {
    return this.http.get<Comment>(this.baseUrl + `comment/${id}`);
  }
}
