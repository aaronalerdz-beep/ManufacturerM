import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { PartsService } from '../../../core/services/parts.service';
import { MatIconModule } from '@angular/material/icon';
@Component({
  selector: 'app-add-part',
  imports: [
    MatIconModule,
    ReactiveFormsModule
  ],
  templateUrl: './add-part.component.html',
  styleUrl: './add-part.component.scss',
})
export class AddPartComponent {
  private fb = inject(FormBuilder);
  public partsServer = inject(PartsService);

  // Definimos el formulario con validaciones básicas
  partForm: FormGroup = this.fb.nonNullable.group({
    description: ['', [Validators.required, Validators.minLength(5)]],
    material: ['', Validators.required],
    sequence: ['', [Validators.required, Validators.min(1)]],
    weight: ['', [Validators.required, Validators.min(0.01)]]
  });

  onSubmit() {
    
    if (this.partForm.valid) {
      const newPart = this.partForm.getRawValue();
      console.log('Enviando datos al backend:', newPart);
      
      // Aquí llamarías a tu servicio:
      this.partsServer.post(newPart).subscribe({
        next: res => {
          console.log('Save:', res);
           this.partForm.reset({
            description: '',
            material: '',
            sequence: '',
            weight: ''
          });
        },
        error: err => {
          console.error('error submitting the form',err);
        }
      })
    }
  }
}
