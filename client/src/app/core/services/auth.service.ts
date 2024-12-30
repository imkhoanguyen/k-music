import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Login } from '../../shared/models/auth';
import { User } from '../../shared/models/user';
import { map, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;
  currentUser = signal<User | null>(null);
  role = computed(() => {
    const user = this.currentUser();
    if (user && user.accessToken) {
      const role = JSON.parse(atob(user.accessToken.split('.')[1])).role;
      return role;
    }
    return null;
  });

  login(login: Login) {
    return this.http.post<any>(this.baseUrl + 'auth/login', login).pipe(
      map((user) => {
        if (user) {
          this.setCurrentUser(user);
        }
      })
    );
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUser.set(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }

  callRefreshToken(refreshToken: string) {
    return this.http.post<any>(this.baseUrl + 'auth/refresh-token', {
      refreshToken,
    });
  }

  private decodeToken(token: string): any {
    const payload = token.split('.')[1];
    return JSON.parse(atob(payload));
  }

  hasClaim(claim: string): boolean {
    const userString = localStorage.getItem('user');
    let token = null;

    if (userString) {
      const user = JSON.parse(userString);
      token = user.accessToken;
    }
    if (!token) return false;
    const decodedToken = this.decodeToken(token);
    // console.log(decodedToken);
    // console.log(decodedToken.Permission);
    return (
      decodedToken &&
      decodedToken.Permission &&
      decodedToken.Permission.includes(claim)
    );
  }
}
