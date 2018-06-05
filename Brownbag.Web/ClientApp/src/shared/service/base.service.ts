import { HttpErrorResponse } from '@angular/common/http/src/response';
import { Observable } from 'rxjs/Observable';

export abstract class BaseService {

    constructor() {    }

    protected handleError(error: HttpErrorResponse) {

        const applicationError = error.error;
        let errorMessage = '';
        if (error.status === 401) {
            errorMessage = 'Your Login token has expired. Please reload the page. All changes will be lost\n';
            return Observable.throw(errorMessage);
        }
        if (error.status === 403) {
            errorMessage = 'You are not authorized to access that data\n';
            return Observable.throw(errorMessage);
        }
        if (error.status === 404) {
            errorMessage = 'File Not Found\n';
            return Observable.throw(errorMessage);
        }
        // tslint:disable-next-line:forin
        for (const e in applicationError) {
            errorMessage += e + ': ' + applicationError[e] + '\n';
        }
        // either applicationError in header or model error in body
        if (errorMessage) {
            return Observable.throw(errorMessage);
        }

        let modelStateErrors = '';
        const serverError = error.error;

        if (!serverError.type) {
            for (const key in serverError) {
                if (serverError[key]) {
                    modelStateErrors += serverError[key] + '\n';
                }
            }
        }

        modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
        return Observable.throw(errorMessage || 'Server error');
    }
}
