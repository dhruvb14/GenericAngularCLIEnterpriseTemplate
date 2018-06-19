/* tslint:disable:no-unused-variable */

import { TestBed, async, inject, getTestBed } from '@angular/core/testing';
import { BlogViewService } from './blog-view.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { GridRestCallsBaseService } from '../../shared/service/grid-base-rest.service';

describe('Service: BlogView', () => {
  let injector: TestBed;
  let httpMock: HttpTestingController;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [BlogViewService, GridRestCallsBaseService]
    });
    injector = getTestBed();
    httpMock = injector.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  // tslint:disable-next-line:max-line-length
  it('should match endpoint for BlogView getGrid', inject([BlogViewService, GridRestCallsBaseService], (service: BlogViewService, base: GridRestCallsBaseService) => {
    expect(service).toBeTruthy();
    const page = 0;
    const rows = 10;
    const searchQuery = undefined;
        service.getGrid(page, rows, searchQuery).subscribe();

        const testUri = service.baseUrl + service.endpoint + `?currentPage=0&rows=10`;
        const reqMatch = {
            method: 'Get',
            url: testUri
        };

        httpMock.expectOne(reqMatch);
  }));

  // tslint:disable-next-line:max-line-length
  it('should match endpoint for BlogView getGrid w/Optional Param', inject([BlogViewService, GridRestCallsBaseService], (service: BlogViewService, base: GridRestCallsBaseService) => {
    expect(service).toBeTruthy();
    const page = 0;
    const rows = 10;
    const CurrentBlogId = 1000;
    const searchQuery = undefined;
        service.getGrid(page, rows, searchQuery, [{ param: 'blogId', value: CurrentBlogId.toString() }]).subscribe();

        const testUri = service.baseUrl + service.endpoint + `?currentPage=0&rows=10&blogId=1000`;
        const reqMatch = {
            method: 'Get',
            url: testUri
        };

        httpMock.expectOne(reqMatch);
  }));
  // tslint:disable-next-line:max-line-length
  it('should match endpoint for BlogView getGridItemDetails', inject([BlogViewService, GridRestCallsBaseService], (service: BlogViewService, base: GridRestCallsBaseService) => {
    expect(service).toBeTruthy();
    const itemId = '10';
        service.getGridItemDetails(itemId).subscribe();

        const testUri = service.baseUrl + service.endpoint + itemId;
        const reqMatch = {
            method: 'Get',
            url: testUri
        };

        httpMock.expectOne(reqMatch);
  }));
  // tslint:disable-next-line:max-line-length
  it('should match endpoint for blog updateGridItem', inject([BlogViewService, GridRestCallsBaseService], (service: BlogViewService, base: GridRestCallsBaseService) => {
    expect(service).toBeTruthy();
    const fakeEntity = {};
        service.updateGridItem(fakeEntity).subscribe();

        const testUri = service.baseUrl + service.endpoint;
        const reqMatch = {
            method: 'Put',
            url: testUri,
        };

        httpMock.expectOne(reqMatch);
  }));
});
