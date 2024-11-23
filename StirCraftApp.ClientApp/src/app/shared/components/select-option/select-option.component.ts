import { Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl, ReactiveFormsModule } from '@angular/forms';
import { MatError, MatFormField, MatLabel, MatOption, MatSelect } from '@angular/material/select';

@Component({
  selector: 'app-select-option',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormField,
    MatSelect,
    MatError,
    MatLabel,
    MatOption
  ],
  templateUrl: './select-option.component.html',
  styleUrl: './select-option.component.scss'
})
export class SelectOptionComponent implements ControlValueAccessor{
  @Input() label = '';
  @Input() type = 'text';
  @Input() items: { value: any; label: string }[] = [];

  constructor(@Self() public controlDir: NgControl) {
    this.controlDir.valueAccessor = this;
   }

   writeValue(obj: any): void {
   
  }
  
  registerOnChange(fn: any): void {
    
  }
  
  registerOnTouched(fn: any): void {
  
  }

  
  get control(){
    return this.controlDir.control as FormControl;
  }

}
