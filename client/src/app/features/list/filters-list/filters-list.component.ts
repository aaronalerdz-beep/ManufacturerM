import { Component, inject, Inject } from '@angular/core';
import { ListService } from '../../../core/services/list.service';
import { MatDivider } from '@angular/material/divider';
import { MatListModule, MatSelectionList, MatSelectionListChange  } from '@angular/material/list'
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-filters-list',
  imports: [
    MatDivider,
    MatListModule,
    MatSelectionList,
    MatButtonModule,
    FormsModule
  ],
  templateUrl: './filters-list.component.html',
  styleUrl: './filters-list.component.scss',
})
export class FiltersListComponent {
  public listServer = inject(ListService);
  private dialogRef = inject(MatDialogRef<FiltersListComponent>);
  data = inject(MAT_DIALOG_DATA);

  selectedMaterial: string[] = [];

  ngOnInit() {
    this.selectedMaterial = [...(this.data?.selectedMaterial ?? [])];
  }

  onSelectionChange(event: MatSelectionListChange) {
    this.selectedMaterial = event.source.selectedOptions.selected
      .map(option => option.value);
  }

  applyFilters() {

    this.dialogRef.close({
      selectedMaterial: this.selectedMaterial
    });
  }
}
