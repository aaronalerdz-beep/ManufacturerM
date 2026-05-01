import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Production_order } from '../../shared/models/order';
import { HttpClient } from '@angular/common/http';
import { monthorders } from '../../shared/models/monthorders';
import { countOrderPart } from '../../shared/models/countorder';

@Injectable({
  providedIn: 'root',
})
export class OrdersService extends ApiService<Production_order> {
  protected endpoint = 'order';
  constructor(http: HttpClient) {
    
    super(http);
  }
  getMonthlyStats() {
    const url = `${this.baseUrl}/${this.endpoint}/stats/monthly`;
  return this.http.get<monthorders[]>(url);
  }
  getCountOrders() {
    const url = `${this.baseUrl}/${this.endpoint}/count/parts`;
  return this.http.get<countOrderPart[]>(url);
  }
}
