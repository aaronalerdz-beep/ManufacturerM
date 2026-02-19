import { Component, inject, signal } from '@angular/core';
import { GenericTableComponent } from "../../../shared/components/generic-table/generic-table.component";
import { MatIcon } from "@angular/material/icon";
import { MatDialog } from '@angular/material/dialog';
import { OrdersService } from '../../../core/services/orders.service';
import { Production_order } from '../../../shared/models/Order';
import { TableColumn } from '../../../shared/models/TableColumn';

@Component({
  selector: 'app-order-list',
  imports: [
    GenericTableComponent, 
    MatIcon
  ],
  templateUrl: './order-list.component.html',
  styleUrl: './order-list.component.scss',
})
export class OrderListComponent {
  
    private machineService = inject(OrdersService)
    private dialogService = inject(MatDialog)
    orders = signal<Production_order[]>([]);

    columns: TableColumn<Production_order>[] = [
      { key: 'PartIdSeq', label: 'ID Part', columnId: 'partId' },
      { key: 'target_quantity', label: 'Meta', columnId: 'target' },
      { key: 'final_quantity', label: 'Finalizado', columnId: 'final' },
      { key: 'started_time', label: 'Inicio', columnId: 'start' },
      { key: 'finished_time', label: 'Fin', columnId: 'end' }
    ];
        
ngOnInit(): void {
    this.initializeList();
  }

  initializeList(){
    this.machineService.getAll().subscribe({
    next: response => {
        console.log(response.data);
        this.orders.set(response.data)
    },
    error: error=> console.log(error),
    complete: ()=> console.log('complete')
      
    })
  }
  
    selected?: number;
  
    onRowSelected(o: Production_order) {
      this.selected = o.PartIdSeq;
      console.log('ID seleccionado:', this.selected);
    }
}
