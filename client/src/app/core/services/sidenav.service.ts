import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SidenavService {
  isOpen = signal(false);

  toggle(){
    this.isOpen.update(val => !val);
  }
}
