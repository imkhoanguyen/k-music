import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SongService } from '../../../../core/services/song.service';
import { MessageService } from '../../../../core/services/message.service';
import { Song } from '../../../../shared/models/song';
import { NzTypographyModule } from 'ng-zorro-antd/typography';
import { CommonModule } from '@angular/common';
import { UtilityService } from '../../../../core/services/utility.service';
import { NzImageModule } from 'ng-zorro-antd/image';

@Component({
  selector: 'app-song-detail',
  standalone: true,
  imports: [CommonModule, NzTypographyModule, NzImageModule],
  templateUrl: './song-detail.component.html',
  styleUrl: './song-detail.component.css',
})
export class SongDetailComponent {
  songId: number = 0;
  private route = inject(ActivatedRoute);
  private songServices = inject(SongService);
  private messageService = inject(MessageService);
  utilService = inject(UtilityService);
  song: Song | undefined;

  ngOnInit(): void {
    this.songId = +this.route.snapshot.paramMap.get('id')!;
    this.loadSong();
  }

  loadSong() {
    this.songServices.getSong(this.songId).subscribe({
      next: (data) => {
        this.song = data;
      },
      error: (er) => this.messageService.showError(er),
    });
  }
}
