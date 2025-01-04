import { Component, inject, Input, OnInit, ViewChild } from '@angular/core';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzCommentModule } from 'ng-zorro-antd/comment';
import { CommentService } from '../../../../core/services/comment.service';
import { UtilityService } from '../../../../core/services/utility.service';
import {
  Comment,
  CommentAdd,
  CommentParams,
} from '../../../../shared/models/comment';
import { Pagination } from '../../../../shared/models/pagination';
import { CommonModule, NgTemplateOutlet } from '@angular/common';
import { AuthService } from '../../../../core/services/auth.service';
import { FormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { MessageService } from '../../../../core/services/message.service';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { AddReplyComponent } from '../add-reply/add-reply.component';
@Component({
  selector: 'app-comment',
  standalone: true,
  imports: [
    NzCommentModule,
    NzAvatarModule,
    CommonModule,
    FormsModule,
    NzButtonModule,
    NzInputModule,
    NzFormModule,
    NzDividerModule,
    NzIconModule,
    NzPaginationModule,
    AddReplyComponent,
  ],
  templateUrl: './comment.component.html',
  styleUrl: './comment.component.css',
})
export class CommentComponent implements OnInit {
  @Input() relatedType = '';
  @Input() relatedId = 0;
  private commentService = inject(CommentService);
  utilService = inject(UtilityService);
  authService = inject(AuthService);
  messageService = inject(MessageService);

  content = '';

  data: Comment[] = [];
  prm = new CommentParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  ngOnInit(): void {
    this.loadComment();
  }

  loadComment() {
    this.prm.relatedType = this.relatedType;
    this.prm.relatedId = this.relatedId;
    this.commentService.getAll(this.prm).subscribe({
      next: (res) => {
        this.data = res.result as Comment[];
        this.pagination = res.pagination as Pagination;
        console.log(this.data);
      },
    });
  }

  onPageIndexChange(newPageNumber: number) {
    this.prm.pageNumber = newPageNumber;
    this.loadComment();
  }

  onPageSizeChange(newPageSize: number) {
    this.prm.pageSize = newPageSize;
    this.loadComment();
  }

  // Lưu trạng thái hiển thị của các replies
  showReplies: { [key: number]: boolean } = {};

  // Toggle trạng thái hiển thị replies
  toggleReplies(commentId: number): void {
    console.log(commentId);
    this.showReplies[commentId] = !this.showReplies[commentId];
  }

  addComment() {
    const c: CommentAdd = {
      content: this.content,
      relatedId: this.relatedId,
      relatedType: this.relatedType,
    };

    this.commentService.add(c).subscribe({
      next: (res) => {
        this.data.unshift(res);
        this.content = '';
        this.messageService.showSuccess('Thêm bình luận thành công');
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  @ViewChild(AddReplyComponent)
  addReplyComponent!: AddReplyComponent;
  openAddReplyModal(parentId: number) {
    console.log(parentId);
    if (this.addReplyComponent) {
      this.addReplyComponent.parentCommentId = parentId;
      this.addReplyComponent.showModal();
    } else {
      console.error('AddReplyComponent is not initialized yet');
    }
  }

  findComment = (comments: Comment[], parentId: number): Comment | null => {
    for (const comment of comments) {
      if (comment.id === parentId) {
        return comment;
      }

      // Nếu không tìm thấy ở cấp độ này, tiếp tục tìm trong các replies
      const foundInReplies = this.findComment(comment.replies, parentId);
      if (foundInReplies) {
        return foundInReplies;
      }
    }

    return null;
  };

  handelAddReply(res: any) {
    const comment = this.findComment(this.data, res.parentId);

    if (comment) {
      comment.replies.unshift(res.reply);
    }
  }

  update() {

  }

  delete() {
    
  }
}
