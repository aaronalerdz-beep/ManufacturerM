import { Routes } from '@angular/router';
import { ListComponent } from './features/list/list.component';
import { AddPartComponent } from './features/add/add-part/add-part.component';
import { AddOrderComponent } from './features/add/add-order/add-order.component';
import { AddMachineComponent } from './features/add/add-machine/add-machine.component';
import { MachineListComponent } from './features/list/machine-list/machine-list.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { LoginComponent } from './features/account/login/login.component';
import { RegisterComponent } from './features/account/register/register.component';
import { authGuard } from './core/guards/auth-guard';

export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'dashboard', component: DashboardComponent, canActivate:[authGuard]},
    {path: 'list', component: ListComponent, canActivate:[authGuard]},
    {path: 'addpart', component: AddPartComponent, canActivate:[authGuard]},
    {path: 'addorder', component: AddOrderComponent, canActivate:[authGuard]},
    {path: 'account/login', component: LoginComponent},
    {path: 'account/register', component: RegisterComponent},
    {path: 'addmachine', component: AddMachineComponent, canActivate:[authGuard]},
    {path: 'listMachine', component: MachineListComponent, canActivate:[authGuard]},
    {path: '**', redirectTo: '', pathMatch: 'full'},
    
];
