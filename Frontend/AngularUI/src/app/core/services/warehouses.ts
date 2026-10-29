import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../config/api.config';
import { ApiRow } from './items';

@Injectable({
  providedIn: 'root',
})
export class WarehousesService {
  private readonly httpClient = inject(HttpClient);
  private readonly apiBaseUrl = inject(API_BASE_URL);

  getWarehouses(): Observable<ReadonlyArray<ApiRow>> {
    return this.httpClient.get<ReadonlyArray<ApiRow>>(`${this.apiBaseUrl}/api/Warehouses`);
  }
}
