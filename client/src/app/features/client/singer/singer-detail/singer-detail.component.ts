import { Component, inject, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SingerService } from '../../../../core/services/singer.service';
import { MessageService } from '../../../../core/services/message.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { Singer, SingerDetail1 } from '../../../../shared/models/singer';
import { Song, SongParams } from '../../../../shared/models/song';
import { Pagination } from '../../../../shared/models/pagination';
import { CommonModule } from '@angular/common';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzTypographyModule } from 'ng-zorro-antd/typography';
import { MusicPlayerService } from '../../../../core/services/music-player.service';
import { AccountService } from '../../../../core/services/account.service';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { QuickAddComponent } from '../../playlist/quick-add/quick-add.component';
import { CommentComponent } from "../../comments/comment/comment.component";

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
    NzPaginationModule,
    QuickAddComponent,
    CommentComponent
],
  templateUrl: './singer-detail.component.html',
  styleUrl: './singer-detail.component.css',
})
export class SingerDetailComponent implements OnInit {
  singerId: number = 0;
  private route = inject(ActivatedRoute);
  private singerService = inject(SingerService);
  private messageServie = inject(MessageService);
  private musicPlayerService = inject(MusicPlayerService);
  private accountService = inject(AccountService);
  private messageService = inject(MessageService);
  private router = inject(Router);
  utilService = inject(UtilityService);
  singer: SingerDetail1 | undefined;
  isLiked = false;

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
      this.prm.pageSize = 10;
      this.loadSinger(); // Gọi lại hàm loadSinger khi tham số route thay đổi
      this.checkLikeSinger();
    });
  }

  loadSinger() {
    this.singerService.getSingerDetail1(this.singerId, this.prm).subscribe({
      next: (res) => {
        console.log(res);
        this.singer = res;
        this.pagination = res.PaginatedResult.pagination as Pagination;
      },
      error: (er) => this.messageServie.showError(er),
    });
  }

  playSong(song: Song) {
    if (song) {
      this.musicPlayerService.playSong(song);
    }
  }

  playList(list: Song[]) {
    if (list) {
      this.musicPlayerService.playList(list);
    }
  }

  checkLikeSinger() {
    this.accountService.checkLikeSinger(this.singerId).subscribe({
      next: (res) => {
        this.isLiked = res;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  likeSinger(singerId: number) {
    this.accountService.likeSinger(singerId).subscribe({
      next: (_) => {
        this.messageService.showSuccess('Ca sĩ đã được lưu vào mục thích');
        this.isLiked = true;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  unLikeSinger(songId: number) {
    this.accountService.unLikeSinger(songId).subscribe({
      next: (_) => {
        this.messageService.showSuccess('Bỏ thích ca sĩ thành công');
        this.isLiked = false;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  likeSong(songId: number) {
    this.accountService.likeSong(songId).subscribe({
      next: (_) => {
        const index = this.singer?.songList.findIndex((s) => s.id == songId);
        if (
          index !== undefined &&
          index !== -1 &&
          this.singer?.songList[index]
        ) {
          this.messageService.showSuccess('Bài hát đã được lưu vào mục thích');
          this.singer.songList[index].liked = true;
        }
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  unLikeSong(songId: number) {
    this.accountService.unLikeSong(songId).subscribe({
      next: (_) => {
        const index = this.singer?.songList.findIndex((s) => s.id == songId);
        if (
          index !== undefined &&
          index !== -1 &&
          this.singer?.songList[index]
        ) {
          this.messageService.showSuccess('Bỏ thích bài hát thành công');
          this.singer.songList[index].liked = false;
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

  goSongDetail(songId: number) {
    this.router.navigate(['/song', songId]);
  }

  //paging sorting
  onPageIndexChange(newPageNumber: number) {
    this.prm.pageNumber = newPageNumber;
    this.loadSinger();
  }

  onPageSizeChange(newPageSize: number) {
    this.prm.pageSize = newPageSize;
    this.loadSinger();
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
    this.loadSinger();
  }

  @ViewChild(QuickAddComponent)
  quickAddComponent!: QuickAddComponent;
  openQuickAdd(songId: number) {
    if (this.quickAddComponent) {
      this.quickAddComponent.songId = songId;
      this.quickAddComponent.showModal();
    } else {
      console.error('QuickAddComponent is not initialized yet');
    }
  }
}
