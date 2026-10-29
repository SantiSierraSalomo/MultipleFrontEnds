import { Component, OnInit, computed, inject, signal } from '@angular/core';
import { ItemsService } from '../../../core/services/items';

@Component({
  imports: [],
  selector: 'app-items-masterdata',
  styleUrl: './items-masterdata.css',
  templateUrl: './items-masterdata.html',
})
export class ItemsMasterdata implements OnInit {
  private readonly itemsService = inject(ItemsService);

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

    this.itemsService.getItems().subscribe({
      next: (items) => {
        this.rows.set(items);
      },
      error: (error) => {
        const message = error instanceof Error ? error.message : 'Unknown error';
        this.rows.set([]);
        this.errorMessage.set(`Failed to load Items: ${message}`);
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
