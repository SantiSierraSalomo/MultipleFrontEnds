import { Component, OnInit, computed, inject, signal } from '@angular/core';
import { WarehousesService } from '../../../core/services/warehouses';

@Component({
  imports: [],
  selector: 'app-warehouses-masterdata',
  styleUrl: './warehouses-masterdata.css',
  templateUrl: './warehouses-masterdata.html',
})
export class WarehousesMasterdata implements OnInit {
  private readonly warehousesService = inject(WarehousesService);

  protected readonly isLoading = signal(false);
  protected readonly errorMessage = signal('');
  protected readonly rows = signal<ReadonlyArray<Record<string, unknown>>>([]);
  protected readonly columns = computed(() => {
    const firstRow = this.rows()[0];
    return firstRow ? Object.keys(firstRow) : [];
  });

  ngOnInit(): void {
    this.refresh();
  }

  protected refresh(): void {
    this.errorMessage.set('');
    this.isLoading.set(true);

    this.warehousesService.getWarehouses().subscribe({
      next: (warehouses) => {
        this.rows.set(warehouses);
      },
      error: (error) => {
        const message = error instanceof Error ? error.message : 'Unknown error';
        this.rows.set([]);
        this.errorMessage.set(`Failed to load Warehouses: ${message}`);
      },
      complete: () => {
        this.isLoading.set(false);
      },
    });
  }

  protected formatValue(value: unknown): string {
    if (value === null || value === undefined) {
      return '';
    }

    return String(value);
  }
}
