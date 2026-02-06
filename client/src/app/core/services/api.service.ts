import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pagination } from '../../shared/models/pagination';

export abstract class ApiService<T> {
  
  protected abstract endpoint: string;
  protected baseUrl = 'https://localhost:7133/api';

  constructor(protected http: HttpClient) {}

  post(data: T): Observable<T> {
    return this.http.post<T>(`${this.baseUrl}/${this.endpoint}`, data);
  }

  getAll(): Observable<Pagination<T>> {
    return this.http.get<Pagination<T>>(`${this.baseUrl}/${this.endpoint}`);
  }

  getById(id: number): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${this.endpoint}/${id}`);
  }

  put(id: number, data: T): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/${this.endpoint}/${id}`, data);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${this.endpoint}/${id}`);
  }
}
