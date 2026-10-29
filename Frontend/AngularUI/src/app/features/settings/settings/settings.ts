import { Component, OnInit, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

interface AppSettingsValue {
  enableNotifications: boolean;
  theme: string;
  pageSize: string;
  defaultWarehouse: string;
}

@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-settings',
  styleUrl: './settings.css',
  templateUrl: './settings.html',
})
export class Settings implements OnInit {
  protected readonly settingsForm = new FormGroup({
    enableNotifications: new FormControl(true, { nonNullable: true }),
    theme: new FormControl('light', { nonNullable: true }),
    pageSize: new FormControl('25', { nonNullable: true }),
    defaultWarehouse: new FormControl('Main Warehouse', { nonNullable: true }),
  });

  protected readonly saveMessage = signal('');

  ngOnInit(): void {
    const settingsValue = localStorage.getItem('app-settings');
    if (!settingsValue) {
      return;
    }

    try {
      const parsed = JSON.parse(settingsValue) as Partial<AppSettingsValue>;
      this.settingsForm.patchValue({
        enableNotifications: parsed.enableNotifications ?? true,
        theme: parsed.theme ?? 'light',
        pageSize: parsed.pageSize ?? '25',
        defaultWarehouse: parsed.defaultWarehouse ?? 'Main Warehouse',
      });
    } catch {
      this.saveMessage.set('Stored settings could not be read. Defaults were restored.');
    }
  }

  protected saveSettings(): void {
    localStorage.setItem('app-settings', JSON.stringify(this.settingsForm.getRawValue()));
    this.saveMessage.set('Settings saved locally.');
  }
}
