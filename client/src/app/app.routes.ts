import { Routes } from '@angular/router';
import { ListComponent } from './features/list/list.component';
import { AddPartComponent } from './features/add/add-part/add-part.component';
import { AddOrderComponent } from './features/add/add-order/add-order.component';
import { AddMachineComponent } from './features/add/add-machine/add-machine.component';
import { MachineListComponent } from './features/list/machine-list/machine-list.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';

export const routes: Routes = [
    {path: '', component: DashboardComponent},
    {path: 'list', component: ListComponent},
    {path: 'addpart', component: AddPartComponent},
    {path: 'addorder', component: AddOrderComponent},
    {path: 'addmachine', component: AddMachineComponent},
    {path: 'listMachine', component: MachineListComponent},
    {path: '**', redirectTo: '', pathMatch: 'full'},
    
];
