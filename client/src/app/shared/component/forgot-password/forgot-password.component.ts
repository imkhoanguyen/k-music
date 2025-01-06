import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';
import { MessageService } from '../../../core/services/message.service';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCardModule } from 'ng-zorro-antd/card';

@Component({
  selector: 'app-forgot-password',
  standalone: true,
  imports: [FormsModule, NzInputModule, NzButtonModule, NzCardModule],
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.css',
})
export class ForgotPasswordComponent {
  private authService = inject(AuthService);
  private messageService = inject(MessageService);

  email: string = '';
  errorMessage: string = '';
  onSubmit() {
    this.errorMessage = '';

    if (!this.email) {
      this.errorMessage = 'Email không được để trống';
      return;
    }

    const gmailRegex = /^[a-zA-Z0-9._%+-]+@gmail\.com$/;
    if (!gmailRegex.test(this.email)) {
      this.errorMessage = 'Vui lòng nhập email hợp lệ có đuôi @gmail.com';
      return;
    }

    this.authService.forgotPassword(this.email).subscribe({
      next: (response) => {
        console.log((response as any).message);
        this.messageService.showSuccess((response as any).message);
      },
      error: (er) => {
        console.log(er);
        this.messageService.showError(er.error);
      },
    });
  }
}
