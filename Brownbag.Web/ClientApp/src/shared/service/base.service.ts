
import { throwError as observableThrowError, Observable } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http/src/response';

export abstract class BaseService {

    constructor() { }

    protected handleError(error: HttpErrorResponse) {

        const applicationError = error.error;
        let errorMessage = '';

        // tslint:disable-next-line:forin
        for (const e in applicationError) {
            errorMessage += e + ': ' + applicationError[e] + '\n';
        }
        // either applicationError in header or model error in body
        if (errorMessage) {
            return observableThrowError(errorMessage);
        }

        let modelStateErrors = '';
        const serverError = error.error;

        if (serverError && !serverError.type) {
            for (const key in serverError) {
                if (serverError[key]) {
                    modelStateErrors += serverError[key] + '\n';
                }
            }
        }

        modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
        if (errorMessage) {
            return observableThrowError(errorMessage || 'Server error');
        }
    }
}
