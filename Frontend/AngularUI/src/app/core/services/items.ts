import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../config/api.config';

export type ApiRow = Record<string, unknown>;

@Injectable({
  providedIn: 'root',
})
export class ItemsService {
  private readonly httpClient = inject(HttpClient);
  private readonly apiBaseUrl = inject(API_BASE_URL);

  getItems(): Observable<ReadonlyArray<ApiRow>> {
    return this.httpClient.get<ReadonlyArray<ApiRow>>(`${this.apiBaseUrl}/api/items`);
  }
}
