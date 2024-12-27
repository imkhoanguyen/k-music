import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzInputModule } from 'ng-zorro-antd/input';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { AuthService } from '../../../core/services/auth.service';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    RouterLink,
    NzMenuModule,
    NzInputModule,
    CommonModule,
    FormsModule,
    NzIconModule,
    NzDropDownModule,
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {
  authService = inject(AuthService);
  private router = inject(Router);

  search = '';

  emitSearch() {
    this.router.navigate(['/search'], { queryParams: { q: this.search } });
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/');
  }
}
