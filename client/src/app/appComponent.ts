import { Component, signal, inject, OnInit } from '@angular/core';
import {  MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavContainer, MatSidenavModule } from "@angular/material/sidenav";
import { SidenavService } from './core/services/sidenav.service';
import { Router, RouterOutlet } from '@angular/router';
import { HomeComponent } from "./layout/home/home.component";

@Component({
  selector: 'app-root',
  imports: [
    HomeComponent
],
  templateUrl: './appComponent.html',
  styleUrl: './appComponent.scss'
})
export class AppComponent  {
}
