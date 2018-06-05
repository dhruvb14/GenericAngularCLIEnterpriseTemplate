import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class LookupsService {

    baseUrl = '/api/Lookups';

    constructor(private http: HttpClient) {
    }
    getBlogs() {
        return this.http.get<Brownbag.Web.Models.LookupViewModel[]>(this.baseUrl + '/Blogs');
    }
}
