import { Component, inject, OnInit, signal } from '@angular/core';
import { ListService } from '../../core/services/list.service';
import { Part } from '../../shared/models/part';
import { MatTableModule} from '@angular/material/table'
import { TableColumn } from '../../shared/models/TableColumn';
import {  GenericTableComponent } from '../../shared/components/generic-table/generic-table.component';
import { MatDialog } from '@angular/material/dialog'
import { FiltersListComponent } from './filters-list/filters-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from "@angular/material/icon";

@Component({
  selector: 'app-list',
  imports: [
    MatTableModule,
    GenericTableComponent,
    MatButtonModule,
    MatIcon
],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss',
})
export class ListComponent implements OnInit{
  private listService = inject(ListService)
  private dialogService = inject(MatDialog)
  parts= signal<Part[]>([]);
  selectMaterial= signal<string[]>([]);

  
  columns: TableColumn<Part>[] = [
  { key: 'partNum', label: 'No.', columnId: 'partNum' },
  { key: 'description', label: 'Descripción', columnId: 'description' },
  { key: 'material', label: 'Material', columnId: 'material' },
  { key: 'sequence', label: 'Sequence', columnId: 'sequence' },
  { key: 'weight', label: 'Weight', columnId: 'weight' },
];


  ngOnInit(): void {
    this.initializeList();
  }

  initializeList(){
    this.listService.getMaterial();
      this.listService.getList().subscribe({
      next: response => this.parts.set(response.data),
      error: error=> console.log(error),
      complete: ()=> console.log('complete')
      
    })
  }
  openFiltersDialog(){
    const dialogRef = this.dialogService.open(FiltersListComponent, {
      minWidth: '500px',
      minHeight: '500px',
      data:{
        selectedMaterial: this.selectMaterial()
      }
    });
    dialogRef.afterClosed().subscribe({
      next: result => {

        if (result) {
          this.selectMaterial.set(result.selectedMaterial);


          this.listService.getList(this.selectMaterial()).subscribe({
            next: response => {
              this.parts.set(response.data);
            },
            error: error => console.log(error)
          });
        }
      }
    });
  }

  selectedPartId?: string;

  onRowSelected(part: Part) {
    this.selectedPartId = part.partNum;
    console.log('ID seleccionado:', this.selectedPartId);
  }
}
