
import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { cycle } from '../../shared/models/cycle';

@Injectable({
  providedIn: 'root',
})
export class CyclesService extends ApiService<cycle> {

  protected endpoint = 'cycle';
  constructor(http: HttpClient) {
    console.log('cycle')
    super(http);
  }
  
}