import { inject, Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { forkJoin, tap } from 'rxjs';
import { SignalrService } from './signalr.service';

@Injectable({
  providedIn: 'root',
})
export class InitService {
  private accountService = inject(AccountService);
  private signalrService = inject(SignalrService);

  init(){

  return forkJoin({
    user:this.accountService.getUserInfo().pipe(
      tap(user => {
        if(user) this.signalrService.createHubConnection();
      })
    )
    });
  }
  
}
