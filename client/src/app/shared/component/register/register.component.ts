import { Component, inject, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { GENDER_LIST } from '../../models/gender-list';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../core/services/auth.service';
import { Register } from '../../models/auth';
import { MessageService } from '../../../core/services/message.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    NzInputModule,
    FormsModule,
    NzIconModule,
    NzButtonModule,
    NzSelectModule,
    CommonModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent implements OnInit {
  ngOnInit(): void {
    this.initForm();
  }
  genderList = GENDER_LIST;
  passwordVisible = false;
  private authService = inject(AuthService);
  private messageService = inject(MessageService);

  // form edit user
  private fb = inject(FormBuilder);
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  validationErrors?: string[];
  initForm() {
    this.frm = this.fb.group({
      userName: ['', Validators.required],
      fullName: ['', Validators.required],
      gender: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', [Validators.required]],
      confirmPassword: [
        '',
        [Validators.required, this.matchValues('password')],
      ],
    });
    this.frm.controls['password'].valueChanges.subscribe({
      next: () => this.frm.controls['confirmPassword'].updateValueAndValidity(),
    });
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value
        ? null
        : { isMatching: true };
    };
  }

  onSubmit() {
    const register: Register = {
      userName: this.frm.value.userName,
      fullName: this.frm.value.fullName,
      gender: this.frm.value.gender,
      email: this.frm.value.email,
      password: this.frm.value.password,
    };

    this.authService.register(register).subscribe({
      next: _ => {
        this.messageService.showSuccess("Đăng ký tài khoản thành công");
      },
      error: (er) => {
        console.log(er);
        this.validationErrors = er;
      },
    });
  }
}
