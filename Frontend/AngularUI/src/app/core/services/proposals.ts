import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../config/api.config';
import { ApiRow } from './items';

export interface ProposalFilters {
  itemId?: string;
  warehouseId?: string;
  proposalIndex?: string;
}

@Injectable({
  providedIn: 'root',
})
export class ProposalsService {
  private readonly httpClient = inject(HttpClient);
  private readonly apiBaseUrl = inject(API_BASE_URL);

  getProposals(filters?: ProposalFilters): Observable<ReadonlyArray<ApiRow>> {
    let params = new HttpParams();

    if (filters?.itemId) {
      params = params.set('itemId', filters.itemId);
    }
    if (filters?.warehouseId) {
      params = params.set('warehouseId', filters.warehouseId);
    }
    if (filters?.proposalIndex) {
      params = params.set('proposalIndex', filters.proposalIndex);
    }

    return this.httpClient.get<ReadonlyArray<ApiRow>>(`${this.apiBaseUrl}/api/Proposals`, {
      params,
    });
  }
}
