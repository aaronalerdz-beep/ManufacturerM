import { Component, inject, OnInit, signal } from '@angular/core';
import { MatTableModule} from '@angular/material/table'
import { TableColumn } from '../../../shared/models/TableColumn';
import {  GenericTableComponent } from '../../../shared/components/generic-table/generic-table.component';
import { MatDialog } from '@angular/material/dialog'
import { FiltersListComponent } from '../filters-list/filters-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from "@angular/material/icon";
import { MatMenuModule } from "@angular/material/menu";
import { MachinesService } from '../../../core/services/machines.service';
import { machine } from '../../../shared/models/machine';

@Component({
  selector: 'app-machine-list',
  imports: [
    MatTableModule,
    GenericTableComponent,
    MatButtonModule,
    MatIconModule,
    MatMenuModule
  ],
  templateUrl: './machine-list.component.html',
  styleUrl: './machine-list.component.scss',
})
export class MachineListComponent {

    private machineService = inject(MachinesService)
    private dialogService = inject(MatDialog)
    machines = signal<machine[]>([]);
  
    
    columns: TableColumn<machine>[] = [
    { key: 'idSeq', label: 'No.', columnId: 'idSeq' },
    { key: 'name_machine', label: 'Name', columnId: 'name_machine' },
    { key: 'area', label: 'Area', columnId: 'area' },
    ];
    
  ngOnInit(): void {
    this.initializeList();
  }

  initializeList(){
    this.machineService.getAll().subscribe({
    next: response => {
        console.log(response.data);
        this.machines.set(response.data)
    },
    error: error=> console.log(error),
    complete: ()=> console.log('complete')
      
    })
  }
  
    selected?: string;
  
    onRowSelected(m: machine) {
      this.selected = m.name_machine;
      console.log('ID seleccionado:', this.selected);
    }
  
}
