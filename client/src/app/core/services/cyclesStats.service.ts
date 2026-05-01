import { Injectable } from '@angular/core';
import { PressureStats } from '../../shared/models/pressureStats';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CyclesStatsService extends ApiService<PressureStats> {

  protected endpoint = 'cyclestats';
  constructor(http: HttpClient) {
    
    super(http);
  }
  getPressureStats() {
    const url = `${this.baseUrl}/${this.endpoint}/pressure`;
  return this.http.get<PressureStats[]>(url);
  }
  
}