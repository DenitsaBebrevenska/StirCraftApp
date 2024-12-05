import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { CommentForm } from '../../shared/models/recipe/commentForm';
import { EditComment } from '../../shared/models/recipe/editComment';
import { ReplyForm } from '../../shared/models/recipe/replyForm';
import { ReplyEditForm } from '../../shared/models/recipe/replyEditForm';

@Injectable({
  providedIn: 'root'
})
export class ReplyService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  replyToComment(recipeId: number, commentId: number, replyForm: ReplyForm) {
    return this.http.post(this.baseUrl + 'recipes/' + recipeId + '/comments/' + commentId + '/replies', replyForm);
  }

  updateReply(recipeId: number, commentId: number, replyId: number, editReplyForm: ReplyEditForm) {
    return this.http.put(this.baseUrl + 'recipes/' + recipeId + '/comments/' + commentId + '/replies/' + replyId, editReplyForm);
  }

  deleteReply(recipeId: number, commentId: number, replyId: number) {
    return this.http.delete(this.baseUrl + 'recipes/' + recipeId + '/comments/' + commentId + '/replies/' + replyId);
  }
}
