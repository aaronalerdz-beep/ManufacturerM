import { Component, inject } from '@angular/core';
import {  MatToolbarModule } from '@angular/material/toolbar';
import {  MatIcon } from '@angular/material/icon';
import { MatMenuModule, MatMenuTrigger, MatMenu, MatMenuItem,  } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { SidenavService } from '../../core/services/sidenav.service';
import { MatBadgeModule} from '@angular/material/badge';
import { MatProgressBar} from '@angular/material/progress-bar';
import { Router, RouterLink, RouterLinkActive } from "@angular/router";
import { AccountService } from '../../core/services/account.service';
import { MatDivider } from '@angular/material/divider';
import { BusyServices } from '../../core/services/busy.service';


@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatMenuModule,
    MatToolbarModule,
    MatIcon,
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    RouterLink,
],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  private sidenavService = inject(SidenavService);
  busyServices = inject(BusyServices);
  accountService = inject(AccountService);
  private router = inject(Router);

  logout(){
    this.accountService.logout().subscribe({
      next: () => {
        this.accountService.currentUser.set(null);
        this.router.navigateByUrl('/account/login')
      }
    })
  }

  toggleMenu() {
    this.sidenavService.toggle();
  }
}
