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
  private router = inject(Router);

  passwordVisible = false;
  password?: string;
  checked = false;

  frm: FormGroup = new FormGroup({});
  private fb = inject(FormBuilder);
  validationErrors?: string[];

  ngOnInit(): void {
    this.initLoginForm();
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
}
