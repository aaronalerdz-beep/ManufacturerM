import { Component, inject } from '@angular/core';
import {  MatToolbarModule } from '@angular/material/toolbar';
import {  MatIcon } from '@angular/material/icon';
import { MatMenuModule, MatMenuTrigger } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { SidenavService } from '../../core/services/sidenav.service';

@Component({
  selector: 'app-header',
  imports: [
    MatMenuModule,
    MatToolbarModule,
    MatIcon,
    MatSidenavModule, // 🌟 Importante para el menú deslizante
    MatIconModule,
    MatButtonModule,
],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  private sidenavService = inject(SidenavService);

  toggleMenu() {
    this.sidenavService.toggle();
  }
}
