/* tslint:disable:no-unused-variable */

import { TestBed, async, inject, getTestBed } from '@angular/core/testing';
import { LookupsService } from './lookups.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('Service: Lookups', () => {
  let injector: TestBed;
  let httpMock: HttpTestingController;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [LookupsService]
    });
    injector = getTestBed();
    httpMock = injector.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should match endpoint for Lookups getBlogs', inject([LookupsService], (service: LookupsService) => {
    expect(service).toBeTruthy();
    service.getBlogs().subscribe();

    const testUri = service.baseUrl + '/Blogs';
    const reqMatch = {
      method: 'Get',
      url: testUri
    };

    httpMock.expectOne(reqMatch);
  }));
});
