import { TestBed } from '@angular/core/testing';

import { AppLocalStorageService } from './app-local-storage.service';

describe('AppLocalStorageService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AppLocalStorageService = TestBed.get(AppLocalStorageService);
    expect(service).toBeTruthy();
  });
});
