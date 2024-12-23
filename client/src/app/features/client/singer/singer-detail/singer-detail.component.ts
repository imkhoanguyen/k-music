import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SingerService } from '../../../../core/services/singer.service';
import { MessageService } from '../../../../core/services/message.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { SingerDetail } from '../../../../shared/models/singer';
import { Song, SongParams } from '../../../../shared/models/song';
import { Pagination } from '../../../../shared/models/pagination';
import { CommonModule } from '@angular/common';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzTypographyModule } from 'ng-zorro-antd/typography';

@Component({
  selector: 'app-singer-detail',
  standalone: true,
  imports: [
    CommonModule,
    NzImageModule,
    NzTableModule,
    NzIconModule,
    NzButtonModule,
    NzTypographyModule,
  ],
  templateUrl: './singer-detail.component.html',
  styleUrl: './singer-detail.component.css',
})
export class SingerDetailComponent implements OnInit {
  singerId: number = 0;
  private route = inject(ActivatedRoute);
  private singerService = inject(SingerService);
  private messageServie = inject(MessageService);
  utilService = inject(UtilityService);
  singer: SingerDetail | undefined;

  // song
  prm = new SongParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  expandSet = new Set<number>();
  onExpandChange(id: number, checked: boolean): void {
    if (checked) {
      this.expandSet.add(id);
    } else {
      this.expandSet.delete(id);
    }
  }

  audioDurations: { [id: string]: string } = {};

  onMetadataLoaded(event: Event, songId: number): void {
    const audioElement = event.target as HTMLAudioElement;
    this.audioDurations[songId] = this.utilService.formatDuration(
      audioElement.duration
    );
  }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.singerId = +params['id']; // Lấy lại singerId từ route
      this.loadSinger(); // Gọi lại hàm loadSinger khi tham số route thay đổi
    });
  }

  loadSinger() {
    this.singerService.getSingerDetail(this.singerId, this.prm).subscribe({
      next: (res) => {
        this.singer = res;
        this.pagination = res.PaginatedResult.pagination as Pagination;
      },
      error: (er) => this.messageServie.showError(er),
    });
  }
}
