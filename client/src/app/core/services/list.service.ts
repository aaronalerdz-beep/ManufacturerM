import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Part } from '../../shared/models/part';
import { Pagination } from '../../shared/models/pagination';

@Injectable({
  providedIn: 'root',
})
export class ListService {
  
  baseUrl = 'https://localhost:7133/api/'
  private http = inject(HttpClient);

  materials= signal<string[]>([]);

  getList(materials?: string[]){
    let params = new HttpParams();

    if (materials && materials.length > 0) {
      params = params.set('materials', materials.join(',')); // <- importante
    }
    params = params.append('pageSize', 20);

    return this.http.get<Pagination<Part>>(this.baseUrl + 'parts', {params})
  }

  getMaterial(){
    if (this.materials().length > 0) return;
    this.http.get<string[]>(this.baseUrl + 'parts/material').subscribe({
      next: response => this.materials.set(response)
    })
  }
}
