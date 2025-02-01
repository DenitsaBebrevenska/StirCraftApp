import { Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl, ReactiveFormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatError, MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-text-area',
  standalone: true,
  imports: [
    MatInputModule,
    ReactiveFormsModule,
    MatFormField,
    MatLabel,
    MatError
  ],
  templateUrl: './text-area.component.html',
  styleUrl: './text-area.component.scss'
})
export class TextAreaComponent implements ControlValueAccessor {
  @Input() label = '';
  @Input() rows = '';
  @Input() required = false;

  constructor(@Self() public controlDir: NgControl) {
    this.controlDir.valueAccessor = this;
  }

  writeValue(obj: any): void {

  }

  registerOnChange(fn: any): void {

  }

  registerOnTouched(fn: any): void {

  }

  get control() {
    return this.controlDir.control as FormControl;
  }
}
