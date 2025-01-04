import { BaseParams } from './base-params';

export interface Comment {
  id: number;
  content: string;
  created: string;
  updated: string;
  parentCommentId?: number;
  userComment: UserCommnet;
  replies: Comment[];
}

export interface UserCommnet {
  userName: string;
  fullName: string;
  imgUrl: string;
}

export class CommentParams extends BaseParams {
  relatedType: string = '';
  relatedId: number = 0;
  orderBy: string = 'id_desc';
}

export interface CommentAdd {
  content: string;
  relatedId: number;
  relatedType: string;
}

export interface ReplyAdd {
  content: string;
  relatedId: number;
  relatedType: string;
  parentCommentId: number;
}

export interface CommentUpdate {
  id: number;
  content: string;
}
