import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../../../core/services/account.service';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Avatar } from '../../../shared/models/user/avatar';
import { CookService } from '../../../core/services/cook.service';
import { AboutCook } from '../../../shared/models/cook/aboutCook';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { TextAreaComponent } from "../../../shared/components/text-area/text-area.component";
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-update-about',
  standalone: true,
  imports: [
    MatButton,
    ReactiveFormsModule,
    TextAreaComponent
  ],
  templateUrl: './update-about.component.html',
  styleUrl: './update-about.component.scss'
})
export class UpdateAboutComponent implements OnInit {
  private formBuilder = inject(FormBuilder);
  private cookSerivice = inject(CookService);
  private router = inject(Router);
  private snack = inject(SnackbarService);
  validationErrors?: string[];
  aboutForm = this.formBuilder.group({
    about: ['', [
      Validators.required
    ]]
  });
  about?: string;

  ngOnInit() {
    this.cookSerivice.getAbout().subscribe({
      next: response => {
        this.about = response.about;
        this.aboutForm.patchValue({
          about: this.about
        });
      },
      error: (error) => {
        console.error(error);
        this.snack.error('Failed to load about information');
      }
    });
  }

  onSubmit() {
    if (this.aboutForm.invalid) {
      return;
    }

    const about: AboutCook = {
      about: this.aboutForm.get('about')!.value || ''
    };

    this.cookSerivice.updateAbout(about).subscribe({
      next: () => {
        this.snack.success('About updated successfully');
        this.router.navigate(['/account/profile']);
      },
      error: (error) => {
        this.validationErrors = error.messages;
      }
    });
  }
}
