/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LookupsService } from './lookups.service';

describe('Service: Lookups', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LookupsService]
    });
  });

  it('should ...', inject([LookupsService], (service: LookupsService) => {
    expect(service).toBeTruthy();
  }));
});
