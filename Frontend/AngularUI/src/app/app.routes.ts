import { Routes } from '@angular/router';
import { ItemsMasterdata } from './features/masterdata/items-masterdata/items-masterdata';
import { WarehousesMasterdata } from './features/masterdata/warehouses-masterdata/warehouses-masterdata';
import { ProposalEditing } from './features/proposal-editing/proposal-editing/proposal-editing';
import { Settings } from './features/settings/settings/settings';
import { About } from './features/about/about/about';
import { Contact } from './features/contact/contact/contact';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'proposal-editing' },
  { path: 'masterdata/items', component: ItemsMasterdata },
  { path: 'masterdata/warehouses', component: WarehousesMasterdata },
  { path: 'proposal-editing', component: ProposalEditing },
  { path: 'settings', component: Settings },
  { path: 'about', component: About },
  { path: 'contact', component: Contact },
  { path: '**', redirectTo: 'proposal-editing' },
];
