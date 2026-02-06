import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MachinesService } from '../../../core/services/machines.service';

@Component({
  selector: 'app-add-machine',
  imports: [
    MatIconModule,
    ReactiveFormsModule
  ],
  templateUrl: './add-machine.component.html',
  styleUrl: './add-machine.component.scss',
})
export class AddMachineComponent {
  private fb = inject(FormBuilder);
  public partsServer = inject(MachinesService);

  machineForm: FormGroup = this.fb.nonNullable.group({
    machineName: ['', [Validators.required, Validators.minLength(5)]],
    area: ['', [Validators.required, Validators.minLength(5)]]
  });


  
   onSubmit() {
    
    if (this.machineForm.valid) {
      const newMachine = this.machineForm.getRawValue();
      console.log('Enviando datos al backend:', newMachine);
      
      // Aquí llamarías a tu servicio:
      this.partsServer.post(newMachine).subscribe({
        next: res => {
          console.log('Save:', res);
           this.machineForm.reset({
            machineName: '',
            area: ''
          });
        },
        error: err => {
          console.error('error submitting the form',err);
        }
      })
    }
   }
}
