import { TestBed, inject } from '@angular/core/testing';

import { OffertService } from './offert.service';

describe('OffertService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OffertService]
    });
  });

  it('should be created', inject([OffertService], (service: OffertService) => {
    expect(service).toBeTruthy();
  }));
});
