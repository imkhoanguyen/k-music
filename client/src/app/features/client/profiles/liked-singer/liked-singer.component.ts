import { Component, inject, OnInit } from '@angular/core';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzTableModule } from 'ng-zorro-antd/table';
import { Singer, SingerParams } from '../../../../shared/models/singer';
import { Pagination } from '../../../../shared/models/pagination';
import { AccountService } from '../../../../core/services/account.service';
import { Router } from '@angular/router';
import { MessageService } from '../../../../core/services/message.service';
import { SingerService } from '../../../../core/services/singer.service';
import { MusicPlayerService } from '../../../../core/services/music-player.service';

@Component({
  selector: 'app-liked-singer',
  standalone: true,
  imports: [
    NzTableModule,
    NzPaginationModule,
    NzButtonModule,
    NzIconModule,
    NzImageModule,
  ],
  templateUrl: './liked-singer.component.html',
  styleUrl: './liked-singer.component.css',
})
export class LikedSingerComponent implements OnInit {
  private accountService = inject(AccountService);
  private router = inject(Router);
  private messageService = inject(MessageService);
  singers: Singer[] = [];
  singerParams = new SingerParams();

  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  ngOnInit(): void {
    this.loadSingers();
  }

  loadSingers() {
    this.accountService.getSingerLiked(this.singerParams).subscribe({
      next: (paginationResult) => {
        this.singers = paginationResult.result as Singer[];
        this.pagination = paginationResult.pagination as Pagination;
      },
      error: (er) => {
        this.messageService.showError(er.message);
        console.log(er);
      },
    });
  }

  onPageIndexChange(newPageNumber: number) {
    this.singerParams.pageNumber = newPageNumber;
    this.loadSingers();
  }

  onPageSizeChange(newPageSize: number) {
    this.singerParams.pageSize = newPageSize;
    this.loadSingers();
  }

  onSortChange(sortBy: string) {
    const currentSort = this.singerParams.orderBy;

    if (currentSort === sortBy) {
      this.singerParams.orderBy = `${sortBy}_desc`;
    } else if (currentSort === `${sortBy}_desc`) {
      this.singerParams.orderBy = sortBy;
    } else {
      this.singerParams.orderBy = sortBy;
    }

    this.loadSingers();
  }

  unLikeSinger(singerId: number) {
    if (singerId == 0) {
      this.messageService.showError(
        'Không tìm thấy ca sĩ vui lòng thử lại sau'
      );
      return;
    }
    this.accountService.unLikeSinger(singerId).subscribe({
      next: (_) => {
        const index = this.singers.findIndex((s) => s.id == singerId);
        if (index !== -1) {
          this.singers.splice(index, 1);
          this.messageService.showSuccess('Bỏ thích ca sĩ thành công');
        }
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  goSingerDetail(singer: Singer) {
    this.router.navigate(['/singer', singer.id]);
  }
}
