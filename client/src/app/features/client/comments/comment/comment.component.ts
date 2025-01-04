import { Component, inject, Input, OnInit, ViewChild } from '@angular/core';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzCommentModule } from 'ng-zorro-antd/comment';
import { CommentService } from '../../../../core/services/comment.service';
import { UtilityService } from '../../../../core/services/utility.service';
import {
  Comment,
  CommentAdd,
  CommentParams,
  CommentUpdate,
} from '../../../../shared/models/comment';
import { Pagination } from '../../../../shared/models/pagination';
import { CommonModule } from '@angular/common';
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
import { NzModalModule, NzModalService } from 'ng-zorro-antd/modal';
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
    NzModalModule,
  ],
  templateUrl: './comment.component.html',
  styleUrl: './comment.component.css',
})
export class CommentComponent implements OnInit {
  @Input() relatedType = '';
  @Input() relatedId = 0;
  private commentService = inject(CommentService);
  private modal = inject(NzModalService);
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

    this.commentService.startConnection();

    // event add comment
    this.commentService.eventListener(
      'ReceiveAddComment',
      (newComment: any) => {
        this.data.unshift(newComment);
      }
    );

    // event add reply
    this.commentService.eventListener('ReceiveAddReply', (newComment: any) => {
      const comment = this.findComment(this.data, newComment.parentCommentId);

      if (comment) {
        comment.replies.unshift(newComment);
      }
    });

    // event update comment
    this.commentService.eventListener(
      'ReceiveDeleteComment',
      (commentId: any) => {
        this.deleteComment(this.data, commentId);
      }
    );

    this.commentService.eventListener(
      'ReceiveUpdateComment',
      (comment: any) => {
        this.updateComment(this.data, comment);
      }
    );
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

  //delete popup
  showDeleteConfirm(id: number) {
    this.modal.confirm({
      nzTitle: 'Are you sure delete this task?',
      nzContent: `<b style="color: red;">Toàn bộ dữ liệu liên quan sẽ bị mất</b>`,
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => {
        if (id === 0) {
          this.messageService.showError('Có lỗi xảy ra vui lòng thử lại sau.');
          return;
        }

        this.commentService.delete(id).subscribe({
          next: (_) => {
            this.messageService.showSuccess(
              'Xóa bình luận/phản hồi thành công'
            );
          },
          error: (er) => console.log(er),
        });
      },
      nzCancelText: 'No',
      nzOnCancel: () => this.messageService.showInfo('Hủy xóa'),
    });
  }

  deleteComment(comments: Comment[], id: number): boolean {
    for (let i = 0; i < comments.length; i++) {
      if (comments[i].id === id) {
        comments.splice(i, 1);
        return true;
      }

      // Nếu không tìm thấy, tiếp tục tìm trong replies
      if (comments[i].replies?.length > 0) {
        const isDeleted = this.deleteComment(comments[i].replies, id);
        if (isDeleted) {
          return true;
        }
      }
    }

    return false;
  }

  // update
  isVisible = false;
  contentUpdate = '';
  idUpdate = 0;

  closeModal() {
    this.isVisible = false;
    this.contentUpdate = '';
    this.idUpdate = 0;
  }

  openModal(id: number) {
    this.commentService.get(id).subscribe({
      next: (res) => {
        this.contentUpdate = res.content;
        this.idUpdate = res.id;
        this.isVisible = true;
      },
      error: (er) => {
        console.log(er);
        this.messageService.showError('Vui lòng thử lại sau');
      },
    });
  }

  update() {
    const c: CommentUpdate = {
      id: this.idUpdate,
      content: this.contentUpdate,
    };
    this.commentService.update(c).subscribe({
      next: (res) => {
        this.messageService.showSuccess(
          'Cập nhật bình luận/phản hồi thành công'
        );
        this.isVisible = false;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  updateComment(comments: Comment[], update: Comment): boolean {
    for (let comment of comments) {
      if (comment.id === update.id) {
        comment.content = update.content;
        comment.updated = update.updated;
        return true;
      }

      // Nếu không tìm thấy, tiếp tục tìm trong replies
      if (comment.replies?.length > 0) {
        const updated = this.updateComment(comment.replies, update);
        if (updated) {
          return true;
        }
      }
    }

    return false;
  }
}
