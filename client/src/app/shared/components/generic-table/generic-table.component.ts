import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { TableColumn } from '../../models/TableColumn';
import { CommonModule } from '@angular/common';
import { MatMenuModule } from "@angular/material/menu";
import { MatIconModule } from "@angular/material/icon";

@Component({
  selector: 'app-generic-table',
  standalone: true,
  imports: [
    MatTableModule,
    CommonModule,
    MatMenuModule,
    MatIconModule
],
  templateUrl: './generic-table.component.html',
})
export class GenericTableComponent<T> {

  @Input() data: T[] = [];
  @Input() columns: TableColumn<T>[] = [];

  @Output() rowSelected = new EventEmitter<T>();

  get displayedColumns(): string[] {
    return this.columns.map(c => c.columnId);
  }

  onRowClick(row: T) {
    this.rowSelected.emit(row);
    
  }
  
}
