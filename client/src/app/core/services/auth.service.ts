import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Login, Register, ResetPassword } from '../../shared/models/auth';
import { User } from '../../shared/models/user';
import { map, Observable } from 'rxjs';
import { CommentService } from './comment.service';
import { UtilityService } from './utility.service';

declare var gapi: any;

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;
  private commentService = inject(CommentService);
  private clientId = environment.ggClientId;
  private utilService = inject(UtilityService);
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

  register(register: Register) {
    return this.http.post(this.baseUrl + 'auth/register', register);
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUser.set(user);
  }

  logout() {
    localStorage.clear();
    this.currentUser.set(null);
    this.commentService.stopHubConnection();
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

  hasSubcription() {
    const userString = localStorage.getItem('user');
    let token = null;

    if (userString) {
      const user = JSON.parse(userString);
      token = user.accessToken;
    }
    if (!token) return false;
    const decodedToken = this.decodeToken(token);

    const vipExpiredDateString = decodedToken?.VipExpiredDate;
    if (!vipExpiredDateString) return false;

    const vipExpiredDate = new Date(vipExpiredDateString);
    const now = new Date();

    const hasValidSubscription = vipExpiredDate > now;
    return hasValidSubscription;
  }

  getTimeSubcription(): string {
    const userString = localStorage.getItem('user');
    let token = null;

    if (userString) {
      const user = JSON.parse(userString);
      token = user.accessToken;
    }
    if (!token) return 'Chưa đăng ký vip';
    const decodedToken = this.decodeToken(token);

    const vipExpiredDateString = decodedToken?.VipExpiredDate;
    if (!vipExpiredDateString) return 'Chưa đăng ký vip';

    return this.utilService.getFormattedDate(vipExpiredDateString);
  }

  public initGoogleAuth() {
    gapi.load('auth2', () => {
      gapi.auth2.init({
        client_id: this.clientId,
      });
    });
  }

  // Sign in with Google
  public signInWithGoogle(): Observable<any> {
    const googleAuth = gapi.auth2.getAuthInstance();
    return new Observable((observer) => {
      googleAuth.signIn().then((googleUser: any) => {
        const token = googleUser.getAuthResponse().id_token;
        observer.next(token);
        observer.complete();
      });
    });
  }

  externalLogin(idToken: string) {
    const dto = {
      provider: 'google',
      idToken: idToken,
    };

    return this.http
      .post<any>(`${environment.apiUrl}auth/ExternalLogin`, dto)
      .pipe(
        map((user) => {
          if (user) {
            this.setCurrentUser(user);
          }
        })
      );
  }

  forgotPassword(email: string) {
    return this.http.get(this.baseUrl + `auth/forget-password?email=${email}`);
  }
  resetPassword(resetPassword: ResetPassword) {
    return this.http.post(this.baseUrl + 'auth/reset-password', resetPassword);
  }
}
