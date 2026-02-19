import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Production_order } from '../../shared/models/Order';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class OrdersService extends ApiService<Production_order> {
  protected endpoint = 'order';
  constructor(http: HttpClient) {
    
    super(http);
  }
}
