import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ListService } from '../../../core/services/list.service';
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
  public listServer = inject(ListService);

  // Definimos el formulario con validaciones básicas
  partForm: FormGroup = this.fb.group({
    description: ['', [Validators.required, Validators.minLength(5)]],
    material: ['', Validators.required],
    sequence: [0, [Validators.required, Validators.min(1)]],
    weight: [0, [Validators.required, Validators.min(0.01)]]
  });

  onSubmit() {
    if (this.partForm.valid) {
      const newPart = this.partForm.value;
      console.log('Enviando datos al backend:', newPart);
      
      // Aquí llamarías a tu servicio:
      // this.listServer.createPart(newPart).subscribe(...)
    }
  }
}
