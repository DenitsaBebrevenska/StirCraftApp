import { Component, inject, OnInit } from '@angular/core';
import { AboutCook } from '../../../shared/models/cook/aboutCook';
import { TextAreaComponent } from '../../../shared/components/text-area/text-area.component';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Router } from '@angular/router';
import { CooksService } from '../../../core/services/cooks.service';
import { CookService } from '../../../core/services/cook.service';

@Component({
  selector: 'app-become-cook',
  standalone: true,
  imports: [
    TextAreaComponent,
    ReactiveFormsModule
  ],
  templateUrl: './become-cook.component.html',
  styleUrl: './become-cook.component.scss'
})
export class BecomeCookComponent {
  private cookService = inject(CookService);
  private formBuilder = inject(FormBuilder);
  private snack = inject(SnackbarService);
  private router = inject(Router);
  validationErrors?: string[];
  becomeCookDto: AboutCook = { about: '' };
  applicationForm = this.formBuilder.group({
    about: ['', Validators.required],
  });

  onSubmit() {
    if (this.applicationForm.invalid) return;

    this.becomeCookDto.about = this.applicationForm.value.about ?? ''

    this.cookService.becomeCook(this.becomeCookDto).subscribe({
      next: () => {
        this.snack.success('Welcome to StirCraft kitchen!');
        this.router.navigateByUrl('/logout'); //force logout to refresh user roles
      },
      error: errors => this.validationErrors = errors
    });
  }
}