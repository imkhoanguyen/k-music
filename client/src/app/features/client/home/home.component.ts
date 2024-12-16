import { Component } from '@angular/core';
import { CarouselComponent } from '../carousel/carousel.component';
import { PlaylistListComponent } from '../playlist/playlist-list/playlist-list.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CarouselComponent, PlaylistListComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {}
