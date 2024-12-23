import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { HeaderComponent } from "../header/header.component";
import { PlayBarComponent } from "../play-bar/play-bar.component";
@Component({
  selector: 'app-client-layout',
  standalone: true,
  imports: [NzIconModule, NzLayoutModule, RouterOutlet, HeaderComponent, PlayBarComponent],
  templateUrl: './client-layout.component.html',
  styleUrl: './client-layout.component.css',
})
export class ClientLayoutComponent {}
