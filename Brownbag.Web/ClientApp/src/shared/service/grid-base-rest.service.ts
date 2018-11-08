import { BaseService } from './base.service';
// import { ConfigService } from '../utils/config.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';



@Injectable()
export abstract class GridRestCallsBaseService extends BaseService {

    public baseUrl = 'api';
    public abstract endpoint: string;

    constructor(public http: HttpClient) {
        super();
    }
    getGrid<T>(page: number, rows: number, searchQuery: string, optionalHttpParams?: { param: string, value: string }[]): Observable<T> {
        // All grids will have paging and row count so we check them and set defaults
        const pageNumber = page ? page.toString() : '0';
        const rowNumber = rows ? rows.toString() : '10';
        let myParams = new HttpParams();

        // Append the page and row counts
        myParams = myParams.append('currentPage', pageNumber);
        myParams = myParams.append('rows', rowNumber);

        // Check if a search query is being performed and apped it
        if (searchQuery) {
            myParams = myParams.append('searchQuery', searchQuery);
        }

        // This allows for additional overrides for one off grid implementations
        if (optionalHttpParams) {
            optionalHttpParams.forEach(param => {
                myParams = myParams.append(param.param, param.value);
            });
        }
        return this.http.get<T>((this.baseUrl + this.endpoint), { params: myParams })
            .pipe(catchError(err => this.handleError(err)));
    }
    getGridItemDetails<T>(id: string): Observable<T> {
        return this.http.get<T>((this.baseUrl + this.endpoint + id))
            .pipe(catchError(err => this.handleError(err)));
    }
    updateGridItem<T>(entity: T) {
        return this.http.put(this.baseUrl + this.endpoint, entity)
            .pipe(catchError(err => this.handleError(err)));
    }
    createGridItem<T>(entity: T) {
        return this.http.post(this.baseUrl + this.endpoint, entity)
            .pipe(catchError(err => this.handleError(err)));
    }
}
