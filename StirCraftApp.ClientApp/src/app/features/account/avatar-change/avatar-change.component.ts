import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../../core/services/account.service';
import { Router } from '@angular/router';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Avatar } from '../../../shared/models/user/avatar';
import { TextInputComponent } from "../../../shared/components/text-input/text-input.component";

@Component({
  selector: 'app-avatar-change',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    TextInputComponent
  ],
  templateUrl: './avatar-change.component.html',
  styleUrl: './avatar-change.component.scss'
})
export class AvatarChangeComponent implements OnInit {
  private formBuilder = inject(FormBuilder);
  private accountService = inject(AccountService);
  private router = inject(Router);
  private snack = inject(SnackbarService);
  validationErrors?: string[];
  avatarForm: any;

  ngOnInit() {
    this.avatarForm = this.formBuilder.group({
      avatarUrl: ['', [
        Validators.required
      ]]
    });
  }

  onSubmit() {
    if (this.avatarForm.invalid) {
      return;
    }

    const avatarDto: Avatar = {
      imageUrl: this.avatarForm.get('avatarUrl').value
    };

    this.accountService.updateAvatar(avatarDto).subscribe({
      next: () => {
        this.snack.success('Avatar updated successfully');
        this.router.navigate(['/account/profile']);
      },
      error: (error) => {
        this.validationErrors = error.messages;
      }
    });
  }
}

