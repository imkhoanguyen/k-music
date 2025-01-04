import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { CommentService } from '../../../../core/services/comment.service';
import { Comment, ReplyAdd } from '../../../../shared/models/comment';
import { MessageService } from '../../../../core/services/message.service';
import { FormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';

@Component({
  selector: 'app-add-reply',
  standalone: true,
  imports: [NzModalModule, FormsModule, NzButtonModule],
  templateUrl: './add-reply.component.html',
  styleUrl: './add-reply.component.css',
})
export class AddReplyComponent {
  @Input() relatedType = '';
  @Input() relatedId = 0;
  @Output() replyAdded = new EventEmitter<{
    parentId: number;
    reply: Comment;
  }>();
  parentCommentId = 0;
  isVisible = false;
  content: string = '';

  private commentService = inject(CommentService);
  private messageService = inject(MessageService);

  showModal(): void {
    this.isVisible = true;
  }

  closeModal(): void {
    this.content = '';
    this.isVisible = false;
  }

  addReply() {
    const r: ReplyAdd = {
      content: this.content,
      relatedId: this.relatedId,
      relatedType: this.relatedType,
      parentCommentId: this.parentCommentId,
    };
    this.commentService.addReply(r).subscribe({
      next: (res) => {
        this.replyAdded.emit({ parentId: this.parentCommentId, reply: res });
        this.messageService.showSuccess('Thêm phản hồi thành công');
        this.closeModal();
      },
      error: (er) => {
        console.log(er);
      },
    });
  }
}
