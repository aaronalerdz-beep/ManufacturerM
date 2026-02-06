import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { Part } from '../../shared/models/part';

@Injectable({
  providedIn: 'root',
})
export class PartsService extends ApiService<Part> {
  
  protected endpoint = 'parts';

  constructor(http: HttpClient) {
    super(http);
  }
}
