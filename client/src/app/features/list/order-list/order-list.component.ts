import { Component, computed, inject, signal } from '@angular/core';
import { GenericTableComponent } from "../../../shared/components/generic-table/generic-table.component";
import { MatIcon } from "@angular/material/icon";
import { MatDialog } from '@angular/material/dialog';
import { OrdersService } from '../../../core/services/orders.service';
import { Production_order } from '../../../shared/models/order';
import { TableColumn } from '../../../shared/models/tableColumn';
import { PartsService } from '../../../core/services/parts.service';
import { Part } from '../../../shared/models/part';


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

    public partsServer = inject(PartsService);
    private ordersService = inject(OrdersService)
    private dialogService = inject(MatDialog)
    parts = signal<Part[]>([]);
    orders = signal<Production_order[]>([]);
    

    columns: TableColumn<any>[] = [
      { key: 'partNum', label: 'Part Number', columnId: 'partName' }, 
      { key: 'description', label: 'Description', columnId: 'description' }, 
      { key: 'target_quantity', label: 'Quantity', columnId: 'target' },
      { key: 'final_quantity', label: 'Final Quantity', columnId: 'final' },
      { key: 'started_time', label: 'Started', columnId: 'start' },
      { key: 'finished_time', label: 'Finished', columnId: 'end' }
    ];
        
  ngOnInit(): void {
    this.initializeList();
    this.initializepartList();
  }
  initializepartList() {
    this.partsServer.getAll().subscribe({
    next: response => {
      this.parts.set(response.data)
    },
      error: (err) => console.error('Error:', err)
    });
  }
  initializeList(){
    this.ordersService.getAll().subscribe({
    next: response => {
        console.log(response.data);
        this.orders.set(response.data)
    },
    error: error=> console.log(error)      
    })
  }
  
  ordersWithPartNames = computed(() => {
    const currentOrders = this.orders();
    const currentParts = this.parts();

    if (currentParts.length === 0) return currentOrders;

    return currentOrders.map(order => {
      const part = currentParts.find(p => p.idSeq === order.partIdSeq);
      console.log("this is a part" + part)
      return {
        ...order,
        partNum: part ? part.partNum : 'N/A',
        description: part ? part.description: 'N/A' 
      };
    });
  });

    selected?: number;
  
    onRowSelected(o: Production_order) {
      this.selected = o.partIdSeq;
      console.log('ID seleccionado:', this.selected);
    }
}
