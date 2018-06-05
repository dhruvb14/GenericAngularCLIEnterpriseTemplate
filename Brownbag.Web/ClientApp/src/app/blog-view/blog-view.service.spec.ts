/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BlogViewService } from './blog-view.service';

describe('Service: BlogView', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BlogViewService]
    });
  });

  it('should ...', inject([BlogViewService], (service: BlogViewService) => {
    expect(service).toBeTruthy();
  }));
});
