import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Order } from '../../shared/models/Order';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class OrdersService extends ApiService<Order> {
  protected endpoint = 'order';
  constructor(http: HttpClient) {
    console.log('orders')
    super(http);
  }
}
