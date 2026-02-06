import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { machine } from '../../shared/models/machine';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class MachinesService extends ApiService<machine> {
  protected endpoint = 'machine';
  constructor(http: HttpClient) {
    console.log('orders')
    super(http);
  }
}
