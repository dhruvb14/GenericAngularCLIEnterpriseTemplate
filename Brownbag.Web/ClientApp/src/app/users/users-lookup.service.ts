import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GridRestCallsBaseService } from '../../shared/service/grid-base-rest.service';

@Injectable()
export class UsersLookupService extends GridRestCallsBaseService {
    endpoint = '/Users/';
    constructor(http: HttpClient) {
        super(http);
    }
}
