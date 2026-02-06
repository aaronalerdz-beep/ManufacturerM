import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Part } from '../../shared/models/part';
import { Pagination } from '../../shared/models/pagination';

@Injectable({
  providedIn: 'root',
})
export class AddService {
  
  baseUrl = 'https://localhost:7133/api/'
  private http = inject(HttpClient);

  
}
