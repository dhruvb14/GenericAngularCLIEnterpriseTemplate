import { of as observableOf, Observable } from 'rxjs';

import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {
    constructor() {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // intercept all api requests and append the base api url based on the environment
        req = req.clone({ url: `${environment.apiUrl}${req.url}` });
        req = req.clone({ withCredentials: true });

        // disabled caching (IE issue)
        if (req.method === 'GET') {
            req = req.clone({
                headers: req.headers.set('Cache-Control', 'no-cache').set('Pragma', 'no-cache')
            });
        }

        return next.handle(req);
    }
}
