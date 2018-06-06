import { Injectable } from '@angular/core';
import { GridRestCallsBaseService } from '../../shared/service/grid-base-rest.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class BlogFKService extends GridRestCallsBaseService {
    constructor(http: HttpClient) {
        super(http);
        this.baseUrl = '/api';
        this.endpoint = '/BlogFK/';
    }
}
