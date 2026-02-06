import { Component, inject, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { PartsService } from '../../../core/services/parts.service';
import { OrdersService } from '../../../core/services/orders.service';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-add-order',
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule
  ],
  templateUrl: './add-order.component.html',
  styleUrl: './add-order.component.scss',
})
export class AddOrderComponent {
  
  parts= signal<any[]>([]);
  private fb = inject(FormBuilder);
  public partsServer = inject(PartsService);
  public ordersServer = inject(OrdersService);
  orderForm: FormGroup = this.fb.nonNullable.group({
  PartId: [null as number | null, Validators.required],
  quantity: [null as number | null, Validators.required]
  });

  ngOnInit(): void {
    this.partsServer.getAll().subscribe({
    next: response => {
      console.log('Contenido de response.data:', response.data);
      this.parts.set(response.data)
    
    },
      error: (err) => console.error('Error cargando categorías', err)
    });
  }

   onSubmit() {
    const partId = this.orderForm.value.part;

    console.log('ID enviado:', partId);
    
    if (this.orderForm.valid) {
      const newOrder = this.orderForm.getRawValue();
      console.log('Enviando datos al backend:', newOrder);
      
      // Aquí llamarías a tu servicio:
      this.ordersServer.post(newOrder).subscribe({
        next: res => {
          console.log('Save:', res);
           this.orderForm.reset({
            part: '',
            quantity: ''
          });
        },
        error: err => {
          console.error('error submitting the form',err);
        }
      })
    }
   }
}
