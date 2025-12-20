import { Component, signal, inject, OnInit } from '@angular/core';
import { HeaderComponent } from "../../layout/header/header.component";
import { LeftSidebarComponent } from "../../layout/left-sidebar/left-sidebar.component";
import { ListComponent } from "../../features/list/list.component";
import {  MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavContainer, MatSidenavModule } from "@angular/material/sidenav";
import { SidenavService } from '../../core/services/sidenav.service';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [
    HeaderComponent,
    LeftSidebarComponent,
    MatButtonModule,
    MatToolbarModule,
    LeftSidebarComponent,
    MatSidenavContainer,
    MatSidenavModule,
    RouterOutlet
],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
[x: string]: any;
  title = 'client';
  public sidenavService = inject(SidenavService);
}
