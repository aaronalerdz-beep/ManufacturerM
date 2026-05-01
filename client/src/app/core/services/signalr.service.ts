import { Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { cycleMService } from '../../shared/models/cycleMService';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  hubUrl = environment.hubUrl;
  hubConnection?: HubConnection;
  cycleStats = signal<cycleMService | null>(null);


  createHubConnection(){
    if (this.hubConnection?.state === HubConnectionState.Connected) return;
    this.hubConnection = new HubConnectionBuilder().withUrl(this.hubUrl,{
      withCredentials: true
    }).withAutomaticReconnect().build();
    this.hubConnection.start().catch(error => console.log(error));
      
    this.hubConnection.on('ReceiveCycleUpdate', (data) => {
        console.log('New stat Received', data);
        this.cycleStats.set(data);
      });
  }
  stopHubConnection() {
    this.hubConnection?.stop().catch(error => console.log(error));

  }

}
