import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NzCarouselComponent, NzCarouselModule } from 'ng-zorro-antd/carousel';
@Component({
  selector: 'app-carousel',
  standalone: true,
  imports: [NzCarouselModule, CommonModule],
  templateUrl: './carousel.component.html',
  styleUrl: './carousel.component.css',
})
export class CarouselComponent {
  array = ['img/b1.jpg', 'img/b2.jpg', 'img/b3.jpg', 'img/b4.jpg'];
  currentBackground = this.array[0];

  updateBackground(index: number): void {
    this.currentBackground = this.array[index];
  }
  
  goToPrevSlide(carousel: NzCarouselComponent): void {
    carousel.pre();
  }

  goToNextSlide(carousel: NzCarouselComponent): void {
    carousel.next();
  }
}
