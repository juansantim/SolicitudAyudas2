import { TestBed } from '@angular/core/testing';

import { AppCookieService } from './app-cookie.service';

describe('AppCookieService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AppCookieService = TestBed.get(AppCookieService);
    expect(service).toBeTruthy();
  });
});
