import { Component, inject, OnInit } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import { ActivatedRoute } from '@angular/router';
import { RecipeDetailed } from '../../../shared/models/recipe/recipeDetailed';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatCard } from '@angular/material/card';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { TextAreaComponent } from '../../../shared/components/text-area/text-area.component';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { CommentForm } from '../../../shared/models/recipe/commentForm';
import { EditComment } from '../../../shared/models/recipe/editComment';
import { RecipeDeleteCommentDialogComponent } from '../recipe-delete-comment-dialog/recipe-delete-comment-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { CommentService } from '../../../core/services/comment.service';
import { ReplyService } from '../../../core/services/reply.service';
import { RecipeCommentReply } from '../../../shared/models/recipe/recipeCommentReply';
import { RecipeDeleteReplyDialogComponent } from '../recipe-delete-reply-dialog/recipe-delete-reply-dialog.component';
import { UserInfo } from '../../../shared/models/user/userInfo';
import { AccountService } from '../../../core/services/account.service';
import { EMPTY, switchMap } from 'rxjs';

@Component({
  selector: 'app-recipe-details',
  standalone: true,
  imports: [
    MatButton,
    MatIcon,
    MatCard,
    TextInputComponent,
    TextAreaComponent,
    ReactiveFormsModule
  ],
  templateUrl: './recipe-details.component.html',
  styleUrl: './recipe-details.component.scss'
})
export class RecipeDetailsComponent implements OnInit {
  private accountService = inject(AccountService);
  private recipeService = inject(RecipesService);
  private commentService = inject(CommentService);
  private replyService = inject(ReplyService);
  private activatedRoute = inject(ActivatedRoute);
  private formBuilder = inject(FormBuilder);
  private snackBar = inject(SnackbarService);
  private dialogService = inject(MatDialog);
  replyingToCommentId: number | null = null;
  editingReplyId: number | null = null;
  commentValidationErrors?: string[];
  commentEditValidationErrors?: string[];
  replyValidationErrors?: string[];
  replyEditValidtionErrors?: string[];
  ratingOptions = [1, 2, 3, 4, 5];
  isInEditMode = false;
  currentRating: number = 0;
  isLiked?: boolean;
  recipe?: RecipeDetailed;
  editingCommentId?: number;
  user: UserInfo | undefined;
  isLoading?: boolean;

  commentForm = this.formBuilder.group({
    title: ['', Validators.required],
    body: ['', Validators.required]
  });

  commentEditForm = this.formBuilder.group({
    title: ['', Validators.required],
    body: ['', Validators.required]
  });


  replyForm = this.formBuilder.group({
    body: ['', [Validators.required]]
  });

  replyEditForm = this.formBuilder.group({
    body: ['', [Validators.required]]
  });

  commentDto: CommentForm = {
    title: '',
    body: ''
  }

  ngOnInit(): void {
    this.isLoading = true;
    this.accountService.getCurrentUserInfo().pipe(
      switchMap(user => {
        this.user = user;
        const id = this.activatedRoute.snapshot.paramMap.get('id');
        return id ? this.recipeService.getRecipe(+id) : EMPTY;
      })
    ).subscribe({
      next: recipe => {
        this.recipe = recipe;
        this.isLiked = recipe.isLikedByCurrentUser;
        this.currentRating = recipe.currentUserRating || 0;
        this.isLoading = false;
      },
      error: err => {
        console.error(err);
        this.isLoading = false;
      }
    });
  }

  loadUser() {
    this.accountService.getCurrentUserInfo().subscribe({
      next: response => this.user = response,
      error: err => console.log(err)
    });
  }

  loadRecipe() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.recipeService.getRecipe(+id).subscribe(
      {
        next: response => {
          this.recipe = response,
            this.isLiked = response.isLikedByCurrentUser,
            this.currentRating = response.currentUserRating || 0
        },
        error: err => console.error(err)
      }
    );
  }

  toggleFavorite() {
    if (!this.recipe) return;

    this.recipeService.toggleFavorite(this.recipe.id).subscribe({
      next: response => {
        this.isLiked = response.isFavorite;

        if (this.recipe) {
          this.recipe.likes = response.totalLikes;
        }

        this.snackBar.success(`Recipe successfully ${response.isFavorite == true ? 'added to' : 'removed from'} favorites`);
      },
      error: () => {
        this.snackBar.error('Failed to update favorite status');
      }
    });
  }

  rateRecipe(value: number) {
    if (!this.recipe || value < 0 || value > 5) return;
    this.currentRating = value;

    this.recipeService.rateRecipe(this.recipe.id, +value).subscribe({
      next: response => {

        if (this.recipe) {
          this.recipe.currentUserRating = value;
          this.recipe.rating = +response;
        }

        this.snackBar.success(`You rated this recipe ${value} stars`);
      },
      error: () => {
        this.currentRating = this.recipe?.currentUserRating || 0;
        this.snackBar.error('Failed to submit rating');
      }
    });
  }

  onCommentSubmit() {
    if (this.commentForm.invalid) {
      return;
    }

    const formValue = this.commentForm.value;
    this.commentDto = {
      title: formValue.title!,
      body: formValue.body!
    };

    if (this.recipe) {
      this.commentService.addComment(this.recipe.id, this.commentDto).subscribe({
        next: () => {
          this.snackBar.success('Successfully added comment.');
          this.commentForm.reset();
          this.loadRecipe();
        },
        error: errors => this.commentValidationErrors = errors
      });
    }

  }

  startCommentEditing(comment: any) {
    this.commentEditForm.patchValue({
      title: comment.title,
      body: comment.body
    });

    this.editingCommentId = comment.id;
    this.isInEditMode = true;
  }


  saveComment() {
    if (this.commentEditForm.invalid) {
      return;
    }

    const updatedComment: EditComment = {
      id: this.editingCommentId!,
      title: this.commentEditForm.get('title')?.value || '',
      body: this.commentEditForm.get('body')?.value || ''
    };

    this.commentService.updateComment(this.recipe!.id, this.editingCommentId!, updatedComment).subscribe({
      next: () => {
        this.isInEditMode = false;
        this.editingCommentId = undefined;
        this.snackBar.success('Comment updated successfully');
        this.loadRecipe();
      },
      error: (errors) => {
        this.commentEditValidationErrors = errors;
        this.snackBar.error('Failed to update comment');
      }
    });
  }


  cancelCommentEditing() {
    this.isInEditMode = false;
    this.editingCommentId = undefined;
  }

  openCommentDeletionDialog(commentId: number) {
    {
      this.dialogService.open(RecipeDeleteCommentDialogComponent, {
        minWidth: '400px',
        data: {
          title: 'Delete comment',
          message: `Are you sure you want to delete this comment?`,
          commentId: commentId,
          recipeId: this.recipe?.id
        }
      });
    }
  }

  startReplyToComment(commentId: number) {
    this.replyingToCommentId = commentId;
    this.replyForm.reset();
  }

  cancelReply() {
    this.replyingToCommentId = null;
  }

  submitReply() {
    if (this.replyForm.invalid) {
      return;
    }

    if (!this.recipe || this.replyingToCommentId === null) {
      return;
    }

    const replyForm = {
      body: this.replyForm.get('body')!.value || '',
      commentId: this.replyingToCommentId
    };

    // Call your service method to submit the reply
    this.replyService.replyToComment(this.recipe.id, this.replyingToCommentId, replyForm).subscribe({
      next: () => {
        this.replyingToCommentId = null;
        this.replyForm.reset();
        this.snackBar.success('Reply posted successfully');
        this.loadRecipe();
      },
      error: (errors) => {
        this.replyValidationErrors = errors;
        this.snackBar.error('Failed to post reply');
      }
    });
  }

  startReplyEditing(reply: RecipeCommentReply, commentId: number) {
    this.editingReplyId = reply.id;
    this.replyingToCommentId = commentId;
    this.replyEditForm.patchValue({
      body: reply.body
    });
  }

  cancelReplyEditing() {
    this.editingReplyId = null;
  }

  saveReply() {
    if (this.replyEditForm.invalid) {
      return;
    }

    const replyEditForm = {
      id: this.editingReplyId!,
      body: this.replyEditForm.get('body')!.value || ''
    }
    // Call your service method to update the reply

    this.replyService.updateReply(this.recipe!.id, this.replyingToCommentId!, this.editingReplyId!, replyEditForm).subscribe({
      next: () => {
        this.editingReplyId = null;
        this.loadRecipe();
      },
      error: (errors) => {
        this.replyEditValidtionErrors = errors;
        this.snackBar.error('Failed to update reply');
      }
    });
  }

  openReplyDeletionDialog(replyId: number, commentId: number) {
    {

      this.dialogService.open(RecipeDeleteReplyDialogComponent, {
        minWidth: '400px',
        data: {
          title: 'Delete reply',
          message: `Are you sure you want to delete this reply?`,
          recipeId: this.recipe?.id,
          commentId: +commentId,
          replyId: +replyId
        }
      });
    }
  }
}

