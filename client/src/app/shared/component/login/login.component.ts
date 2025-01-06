declare var google: any;
import { Component, inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { AuthService } from '../../../core/services/auth.service';
import { MessageService } from '../../../core/services/message.service';
import { CommonModule } from '@angular/common';
import { Login } from '../../models/auth';
import { Router } from '@angular/router';
import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    NzInputModule,
    FormsModule,
    NzIconModule,
    NzButtonModule,
    NzCheckboxModule,
    NzDividerModule,
    ReactiveFormsModule,
    CommonModule,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  private authService = inject(AuthService);
  private messageServies = inject(MessageService);
  private oauthService = inject(OAuthService);
  private router = inject(Router);

  passwordVisible = false;
  password?: string;
  checked = false;

  frm: FormGroup = new FormGroup({});
  private fb = inject(FormBuilder);
  validationErrors?: string[];

  /**
   *
   */
  constructor() {
    this.configureOAuth();
  }

  ngOnInit(): void {
    this.initLoginForm();
    this.initializeGoogleLogin();
  }

  initLoginForm() {
    this.frm = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  onSubmit() {
    const login: Login = {
      userName: this.frm.value.userName,
      password: this.frm.value.password,
    };

    this.authService.login(login).subscribe({
      next: (_) => {
        if (this.authService.role() === 'Admin') {
          this.router.navigateByUrl('/admin');
          this.messageServies.showInfo('login success');
          return;
        }
        this.router.navigateByUrl('/');
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  private configureOAuth() {
    const authConfig: AuthConfig = {
      issuer: 'https://accounts.google.com',
      redirectUri: window.location.origin,
      clientId: environment.ggClientId,
      responseType: 'code',
      scope: 'openid profile email',
      showDebugInformation: true,
      strictDiscoveryDocumentValidation: false,
    };

    this.oauthService.configure(authConfig);
    this.oauthService.setupAutomaticSilentRefresh();
    this.oauthService.loadDiscoveryDocumentAndTryLogin();

    this.oauthService.events.subscribe((e) => {
      if (e.type === 'token_received') {
        this.handleLogin(e);
      }
    });
  }

  initializeGoogleLogin() {
    google.accounts.id.initialize({
      client_id: environment.ggClientId,
      callback: (response: any) => this.handleGoogleLogin(response),
    });
    google.accounts.id.renderButton(document.getElementById('google-btn'), {
      type: 'standard',
      theme: 'filled_blue',
      size: 'large',
      text: 'login_with',
    });
  }

  handleLogin(response: any) {
    if (response) {
      const token = response.credential;
      this.authenticateWithServer(token);
    } else {
      this.messageServies.showError('Đăng nhập băng Google không thành công.');
    }
  }

  authenticateWithServer(token: string) {
    this.authService.externalLogin(token).subscribe({
      next: (_) => {
        if (this.authService.role() === 'Admin') {
          this.router.navigateByUrl('/admin');
          this.messageServies.showInfo('login success');
          return;
        }
        this.router.navigateByUrl('/');
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  handleGoogleLogin(response: any) {
    if (response.credential) {
      this.handleLogin(response);
    } else {
      this.messageServies.showError('Đăng nhập bằng Google không thành công.');
    }
  }
}
