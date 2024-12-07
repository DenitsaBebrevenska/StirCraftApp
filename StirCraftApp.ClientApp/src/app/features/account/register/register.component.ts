import { Component, inject } from '@angular/core';
import { AbstractControl, FormBuilder, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatCard } from '@angular/material/card';
import { AccountService } from '../../../core/services/account.service';
import { Router } from '@angular/router';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { TextInputComponent } from "../../../shared/components/text-input/text-input.component";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatCard,
    MatButton,
    TextInputComponent
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  private formBuilder = inject(FormBuilder);
  private accountService = inject(AccountService);
  private router = inject(Router);
  private snack = inject(SnackbarService);
  validationErrors?: string[];

  passwordMatchValidator(): ValidatorFn {
    return (formGroup: AbstractControl): ValidationErrors | null => {
      const password = formGroup.get('password');
      const confirmPassword = formGroup.get('confirmPassword');

      if (password?.value !== confirmPassword?.value) {
        confirmPassword?.setErrors({ passwordMismatch: true });
        return { passwordMismatch: true };
      }

      if (confirmPassword?.hasError('passwordMismatch')) {
        confirmPassword?.setErrors(null);
      }

      return null;
    };
  }


  registerForm = this.formBuilder.group(
    {
      displayName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      confirmPassword: ['', [Validators.required]]
    },
    {
      validators: this.passwordMatchValidator()
    }
  );


  onSubmit() {
    const { confirmPassword, ...registrationData } = this.registerForm.value;
    this.accountService.register(registrationData).subscribe({
      next: () => {
        this.snack.success('Successful registration! You can now log in.');
        this.router.navigateByUrl('/account/login');
      },
      error: errors => this.validationErrors = errors
    });
  }
}
