import { CommonModule } from '@angular/common';
import {
  Component,
  EventEmitter,
  inject,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { MessageService } from '../../../../core/services/message.service';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { UtilityService } from '../../../../core/services/utility.service';
import { NzUploadFile, NzUploadModule } from 'ng-zorro-antd/upload';
import { NzRadioModule } from 'ng-zorro-antd/radio';

@Component({
  selector: 'app-update-playlist',
  standalone: true,
  imports: [
    NzButtonModule,
    NzInputModule,
    NzIconModule,
    NzModalModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    NzUploadModule,
    NzRadioModule,
  ],
  templateUrl: './update-playlist.component.html',
  styleUrl: './update-playlist.component.css',
})
export class UpdatePlaylistComponent implements OnInit {
  @Input() playlistId!: number;
  @Output() playlistUpdated = new EventEmitter<any>();

  private messageService = inject(MessageService);
  private playlistService = inject(PlaylistService);
  ultilService = inject(UtilityService);

  ngOnInit(): void {
    this.initForm();
  }

  private fb = inject(FormBuilder);
  frm: FormGroup = new FormGroup({});
  isVisibleModal = false;
  validationErrors?: string[];

  initForm() {
    this.frm = this.fb.group({
      name: ['', Validators.required],
      imgFile: [''],
      isPublic: [false],
    });
  }

  closeModal() {
    this.isVisibleModal = false;
    this.validationErrors = [];
    this.frm.reset();
    this.previewImage = '';
    this.playlistId = 0;
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('id', this.playlistId.toString());
    formData.append('name', this.frm.value.name);
    formData.append('isPublic', this.frm.value.isPublic.toString());

    if (this.frm.value.imgFile) {
      formData.append('imgFile', this.frm.value.imgFile);
    }

    this.playlistService.updatePlaylist(this.playlistId, formData).subscribe({
      next: (response) => {
        this.messageService.showSuccess('Cập nhật danh sách phát thành công');
        this.playlistUpdated.emit(response);
        this.closeModal();
      },
      error: (er) => {
        this.validationErrors = er;
        console.log(er);
      },
    });
  }

  showModal() {
    if (!this.playlistId) {
      this.messageService.showError(
        'Không tìm thấy danh sách phát. Vui lòng thử lại sau'
      );
      return;
    }

    this.playlistService.getPlaylist(this.playlistId).subscribe({
      next: (playlist) => {
        this.frm.patchValue({
          name: playlist.name,
          isPublic: playlist.isPublic,
        });

        this.previewImage = playlist.imgUrl;

        this.isVisibleModal = true;
      },
      error: (er) => {
        console.error(er);
        this.messageService.showError('Không thể tải danh sách phát');
      },
    });
  }

  // img preview
  previewImage: string | ArrayBuffer | null = null;
  beforeUploadImg = (file: NzUploadFile): boolean => {
    const reader = new FileReader();
    reader.onload = (e) => {
      if (e.target?.result) {
        this.previewImage = e.target.result;
      }
    };
    reader.readAsDataURL(file as any);

    // path value to input
    this.frm.patchValue({
      imgFile: file,
    });

    return false; // Ngăn không cho upload tự động
  };
}
