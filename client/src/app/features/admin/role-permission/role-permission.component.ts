import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { RoleService } from '../../../core/services/role.service';
import { PermissionGroup, Role } from '../../../shared/models/role';
import { MessageService } from '../../../core/services/message.service';
import { NzButtonModule } from 'ng-zorro-antd/button';

@Component({
  selector: 'app-role-permission',
  standalone: true,
  imports: [NzButtonModule],
  templateUrl: './role-permission.component.html',
  styleUrl: './role-permission.component.css',
})
export class RolePermissionComponent {
  roleId: string = '';
  private route = inject(ActivatedRoute);
  private roleServices = inject(RoleService);
  private messageService = inject(MessageService);
  private router = inject(Router);
  permissionGroups: PermissionGroup[] = [];
  roleClaims: string[] = [];
  role: Role | undefined;

  ngOnInit(): void {
    this.roleId = this.route.snapshot.paramMap.get('id')!;
    this.loadRole();
    this.loadPermissions();
    this.loadRoleClaims();
  }

  loadPermissions() {
    this.roleServices.getAllPermission().subscribe({
      next: (data) => {
        this.permissionGroups = data;
      },
      error: (er) => console.log(er),
    });
  }

  loadRole() {
    this.roleServices.getRole(this.roleId).subscribe({
      next: (data) => {
        this.role = data;
      },
    });
  }

  loadRoleClaims() {
    this.roleServices.getRoleClaims(this.roleId).subscribe({
      next: (data) => {
        this.roleClaims = data;
      },
      error: (er) => console.log(er),
    });
  }

  onClaimToggle(claimValue: string, event: Event) {
    const isChecked = (event.target as HTMLInputElement).checked;

    if (isChecked) {
      if (!this.roleClaims.includes(claimValue)) {
        this.roleClaims.push(claimValue);
      }
    } else {
      this.roleClaims = this.roleClaims.filter((c) => c !== claimValue);
    }
  }

  saveRoleClaims() {
    this.roleServices.updateRoleClaim(this.roleId, this.roleClaims).subscribe({
      next: () => {
        this.messageService.showSuccess('Quyền đã được cập nhật thành công.');
      },
      error: (er) => {
        this.messageService.showError(
          'Có lỗi xảy ra khi cập nhật quyền: ' + er
        );
      },
    });
  }

  backToRole() {
    this.router.navigate(['/admin/role']);
  }
}
