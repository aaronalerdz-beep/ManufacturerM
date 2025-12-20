import { Routes } from '@angular/router';
import { ListComponent } from './features/list/list.component';
import { AddPartComponent } from './features/add/add-part/add-part.component';
import { AddOrderComponent } from './features/add/add-order/add-order.component';
import { HomeComponent } from './layout/home/home.component';

export const routes: Routes = [
    {path: '', component: ListComponent},
    {path: 'list', component: ListComponent},
    {path: 'addpart', component: AddPartComponent},
    {path: 'addorder', component: AddOrderComponent},
    {path: '**', redirectTo: '', pathMatch: 'full'},
    
];
