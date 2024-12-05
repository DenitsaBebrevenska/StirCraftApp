import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { CommentForm } from '../../shared/models/recipe/commentForm';
import { EditComment } from '../../shared/models/recipe/editComment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  addComment(recipeId: number, commentFormDto: CommentForm) {
    return this.http.post(this.baseUrl + 'recipes/' + recipeId + '/comments', commentFormDto);
  }

  updateComment(recipeId: number, commentId: number, editFormDto: EditComment) {
    return this.http.put(this.baseUrl + 'recipes/' + recipeId + '/comments/' + commentId, editFormDto);
  }

  deleteComment(recipeId: number, commentId: number) {
    return this.http.delete(this.baseUrl + 'recipes/' + recipeId + '/comments/' + commentId);
  }

}
