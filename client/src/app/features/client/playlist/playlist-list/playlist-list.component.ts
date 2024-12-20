import { Component, inject, Input } from '@angular/core';
import { ClientService } from '../../../../core/services/client.service';
import { Playlist, PlaylistParams } from '../../../../shared/models/playlist';
import { Pagination } from '../../../../shared/models/pagination';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { Router } from '@angular/router';

@Component({
  selector: 'app-playlist-list',
  standalone: true,
  imports: [NzCardModule, NzGridModule, NzListModule, NzPaginationModule],
  templateUrl: './playlist-list.component.html',
  styleUrl: './playlist-list.component.css',
})
export class PlaylistListComponent {
  @Input() orderBy = 'id_desc';
  private clientService = inject(ClientService);
  private router = inject(Router);

  ngOnInit(): void {
    this.loadPaylists();
  }

  // *********************************************************************
  // load playlist, sort, paging, search ...
  playlists: Playlist[] = [];
  prm = new PlaylistParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadPaylists() {
    this.prm.orderBy = this.orderBy;
    this.prm.pageSize = 4;
    this.clientService.getPlaylists(this.prm).subscribe({
      next: (response) => {
        this.playlists = response.result as Playlist[];
        this.pagination = response.pagination as Pagination;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  onPageIndexChange(newPageNumber: number) {
    this.prm.pageNumber = newPageNumber;
    this.loadPaylists();
  }

  onPageSizeChange(newPageSize: number) {
    this.prm.pageSize = newPageSize;
    this.loadPaylists();
  }

  onSortChange(sortBy: string) {
    const currentSort = this.prm.orderBy;

    if (currentSort === sortBy) {
      this.prm.orderBy = `${sortBy}_desc`;
    } else if (currentSort === `${sortBy}_desc`) {
      this.prm.orderBy = sortBy;
    } else {
      this.prm.orderBy = sortBy;
    }
    this.loadPaylists();
  }

  openPlaylistDetail(playlistId: number) {
    this.router.navigate(['/playlist', playlistId]);
  }
}