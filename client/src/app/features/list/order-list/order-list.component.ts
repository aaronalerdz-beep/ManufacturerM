import { Component } from '@angular/core';
import { GenericTableComponent } from "../../../shared/components/generic-table/generic-table.component";
import { MatIcon } from "@angular/material/icon";

@Component({
  selector: 'app-order-list',
  imports: [GenericTableComponent, MatIcon],
  templateUrl: './order-list.component.html',
  styleUrl: './order-list.component.scss',
})
export class OrderListComponent {

}
