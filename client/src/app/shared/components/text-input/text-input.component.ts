import { Component, inject, Input, input, Self, signal } from '@angular/core';
import { ControlValueAccessor, FormBuilder, FormControl, NgControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatCard } from '@angular/material/card';
import { MatInput } from '@angular/material/input';
import { MatError, MatFormField, MatLabel } from '@angular/material/select';
import { AccountService } from '../../../core/services/account.service';
import { Router } from '@angular/router';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-text-input',
  imports: [
    ReactiveFormsModule,
    MatFormField,
    MatLabel,
    MatInput,
    MatError
  ],
  templateUrl: './text-input.component.html',
  styleUrl: './text-input.component.scss',
})
export class TextInputComponent implements ControlValueAccessor{
  @Input() label = '';
  @Input() type = 'text';

  constructor(@Self() public controlDir: NgControl){
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
