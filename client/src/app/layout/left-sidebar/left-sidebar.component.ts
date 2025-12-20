import { Component, inject } from '@angular/core';
import { MatIcon } from "@angular/material/icon";
import { MatButtonModule } from '@angular/material/button';
import { SidenavService } from '../../core/services/sidenav.service';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-left-sidebar',
  imports: [
    MatIcon,
    MatButtonModule,
    RouterLink
],
  templateUrl: './left-sidebar.component.html',
  styleUrl: './left-sidebar.component.scss',
})
export class LeftSidebarComponent {
  private sidenavService = inject(SidenavService);

  toggleMenu() {
    this.sidenavService.toggle();
  }
  PartsList(){
    
  }
}
