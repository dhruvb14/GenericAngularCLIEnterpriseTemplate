import { PostService } from './post.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed, async, inject, getTestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';
import { GridRestCallsBaseService } from '../../shared/service/grid-base-rest.service';

describe('Service: Post', () => {
  let injector: TestBed;
  let httpMock: HttpTestingController;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [PostService, GridRestCallsBaseService]
    });
    injector = getTestBed();
    httpMock = injector.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });
  // tslint:disable-next-line:max-line-length
  it('should match endpoint for Post getGrid', inject([PostService, GridRestCallsBaseService], (service: PostService, base: GridRestCallsBaseService) => {
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
  it('should match endpoint for Post getGridItemDetails', inject([PostService, GridRestCallsBaseService], (service: PostService, base: GridRestCallsBaseService) => {
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
  it('should match endpoint for Post updateGridItem', inject([PostService, GridRestCallsBaseService], (service: PostService, base: GridRestCallsBaseService) => {
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
