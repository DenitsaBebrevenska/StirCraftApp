import { Component, inject } from '@angular/core';
import { ReplyService } from '../../../core/services/reply.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recipe-delete-reply-dialog',
  standalone: true,
  imports: [],
  templateUrl: './recipe-delete-reply-dialog.component.html',
  styleUrl: './recipe-delete-reply-dialog.component.scss'
})
export class RecipeDeleteReplyDialogComponent {
  replyService = inject(ReplyService);
  private dialogReference = inject(MatDialogRef<RecipeDeleteReplyDialogComponent>);
  private snack = inject(SnackbarService);
  data = inject(MAT_DIALOG_DATA);

  approveDeletion(commentId: number) {
    this.dialogReference.close(true);
    this.replyService.deleteReply(this.data.recipeId, this.data.commentId, this.data.replyId).subscribe({
      next: () => {
        this.snack.success('Reply deleted successfully');
        window.location.reload();
      },
      error: err => {
        this.snack.error('An error occurred while deleting the reply');
        console.error(err);
      }
    });
  }

  cancelDeletion() {
    this.dialogReference.close(true);
  }
}
