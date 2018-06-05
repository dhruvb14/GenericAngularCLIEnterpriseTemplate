import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GridRestCallsBaseService } from '../../shared/service/grid-base-rest.service';

@Injectable()
export class BlogViewService extends GridRestCallsBaseService {
    constructor(http: HttpClient) {
        super(http);
        this.baseUrl = '/api';
        this.endpoint = '/BlogView/';
    }
}
