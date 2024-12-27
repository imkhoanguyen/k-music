import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { SingerService } from '../../../../core/services/singer.service';
import { Router } from '@angular/router';
import { Singer, SingerParams } from '../../../../shared/models/singer';
import { Pagination } from '../../../../shared/models/pagination';

@Component({
  selector: 'app-singer-list',
  standalone: true,
  imports: [
    NzCardModule,
    NzGridModule,
    NzListModule,
    NzPaginationModule,
    CommonModule,
  ],
  templateUrl: './singer-list.component.html',
  styleUrl: './singer-list.component.css',
})
export class SingerListComponent {
  private singerService = inject(SingerService);
  private router = inject(Router);

  ngOnInit(): void {
    this.prm.pageSize = 8;
    this.loadSingers();
  }
  locations: string[] = [];
  selectedLocation = '';
  selectLocation(location: string) {
    this.selectedLocation = location;
    if (this.selectedLocation) {
      this.prm.location = this.selectedLocation;
    } else {
      this.prm.location = '';
    }
    this.loadSingers();
  }

  // *********************************************************************
  // load song, sort, paging, search ...
  singers: Singer[] = [];
  prm = new SingerParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadSingers() {
    console.log(this.prm);
    this.singerService.getSingers(this.prm).subscribe({
      next: (response) => {
        this.singers = response.result as Singer[];
        this.pagination = response.pagination as Pagination;
        const allLocations = this.singers.flatMap((singer) => singer.location);
        const uniqueLocations = Array.from(
          new Map(allLocations.map((location) => [location, location])).values()
        );

        this.locations = uniqueLocations;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  onPageIndexChange(newPageNumber: number) {
    this.prm.pageNumber = newPageNumber;
    this.loadSingers();
  }

  onPageSizeChange(newPageSize: number) {
    this.prm.pageSize = newPageSize;
    this.loadSingers();
  }

  openSingerDetail(singerId: number) {
    this.router.navigate(['/singer', singerId]);
  }
}
