import { Component, OnInit, computed, inject, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { forkJoin } from 'rxjs';
import { ItemsService } from '../../../core/services/items';
import { ProposalsService } from '../../../core/services/proposals';
import { WarehousesService } from '../../../core/services/warehouses';

interface SelectOption {
  value: string;
  label: string;
}

@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-proposal-editing',
  styleUrl: './proposal-editing.css',
  templateUrl: './proposal-editing.html',
})
export class ProposalEditing implements OnInit {
  private readonly itemsService = inject(ItemsService);
  private readonly warehousesService = inject(WarehousesService);
  private readonly proposalsService = inject(ProposalsService);

  protected readonly filtersForm = new FormGroup({
    itemId: new FormControl('', { nonNullable: true }),
    warehouseId: new FormControl('', { nonNullable: true }),
    proposalIndex: new FormControl('', { nonNullable: true }),
  });

  protected readonly itemOptions = signal<ReadonlyArray<SelectOption>>([]);
  protected readonly warehouseOptions = signal<ReadonlyArray<SelectOption>>([]);
  protected readonly proposalIndexOptions = signal<ReadonlyArray<SelectOption>>([]);

  protected readonly isLoadingLookups = signal(false);
  protected readonly isLoadingProposals = signal(false);
  protected readonly lookupErrorMessage = signal('');
  protected readonly proposalErrorMessage = signal('');
  protected readonly rows = signal<ReadonlyArray<Record<string, unknown>>>([]);
  protected readonly columns = computed(() => {
    const firstRow = this.rows()[0];
    return firstRow ? Object.keys(firstRow) : [];
  });

  ngOnInit(): void {
    this.loadLookups();
  }

  protected loadLookups(): void {
    this.lookupErrorMessage.set('');
    this.isLoadingLookups.set(true);

    forkJoin({
      items: this.itemsService.getItems(),
      warehouses: this.warehousesService.getWarehouses(),
      proposals: this.proposalsService.getProposals(),
    }).subscribe({
      next: ({ items, warehouses, proposals }) => {
        this.itemOptions.set(this.createOptions(items, ['id', 'itemId'], ['name', 'description'], 'Item'));
        this.warehouseOptions.set(
          this.createOptions(warehouses, ['id', 'warehouseId'], ['name', 'description'], 'Warehouse'),
        );
        this.proposalIndexOptions.set(
          this.createOptions(proposals, ['proposalIndex', 'index'], ['proposalIndex', 'index'], 'Proposal'),
        );
      },
      error: (error) => {
        const message = error instanceof Error ? error.message : 'Unknown error';
        this.lookupErrorMessage.set(`Failed to load filters: ${message}`);
        this.isLoadingLookups.set(false);
      },
      complete: () => {
        this.isLoadingLookups.set(false);
      },
    });
  }

  protected showData(): void {
    this.proposalErrorMessage.set('');
    this.isLoadingProposals.set(true);

    this.proposalsService
      .getProposals({
        itemId: this.filtersForm.controls.itemId.value,
        warehouseId: this.filtersForm.controls.warehouseId.value,
        proposalIndex: this.filtersForm.controls.proposalIndex.value,
      })
      .subscribe({
        next: (proposals) => {
          this.rows.set(proposals);
        },
        error: (error) => {
          const message = error instanceof Error ? error.message : 'Unknown error';
          this.rows.set([]);
          this.proposalErrorMessage.set(`Failed to load Proposals: ${message}`);
          this.isLoadingProposals.set(false);
        },
        complete: () => {
          this.isLoadingProposals.set(false);
        },
      });
  }

  protected formatValue(value: unknown): string {
    if (value === null || value === undefined) {
      return '';
    }

    return String(value);
  }

  private createOptions(
    rows: ReadonlyArray<Record<string, unknown>>,
    idCandidates: ReadonlyArray<string>,
    labelCandidates: ReadonlyArray<string>,
    fallbackPrefix: string,
  ): ReadonlyArray<SelectOption> {
    const options = rows.map((row, index) => {
      const value = this.pickValue(row, idCandidates) ?? `${index + 1}`;
      const label = this.pickValue(row, labelCandidates) ?? `${fallbackPrefix} ${index + 1}`;
      return {
        value,
        label,
      };
    });

    const uniqueByValue = new Map<string, SelectOption>();
    for (const option of options) {
      if (!uniqueByValue.has(option.value)) {
        uniqueByValue.set(option.value, option);
      }
    }

    return Array.from(uniqueByValue.values());
  }

  private pickValue(row: Record<string, unknown>, keys: ReadonlyArray<string>): string | undefined {
    for (const key of keys) {
      const value = row[key];
      if (typeof value === 'string' && value.trim().length > 0) {
        return value;
      }

      if (typeof value === 'number') {
        return `${value}`;
      }
    }

    return undefined;
  }
}
