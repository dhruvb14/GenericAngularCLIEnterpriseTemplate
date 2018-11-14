
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, CanDeactivate } from '@angular/router';
import { UserService } from './user.service';

import { Observable } from 'rxjs';
import { AdvGrowlService } from 'primeng-advanced-growl';
@Injectable()
export class AuthGuardService implements CanActivate {
    private user;
    constructor(private router: Router, private userservice: UserService, private notificationsService: AdvGrowlService) {
    }

    // public canAsctivate(route: ActivatedRouteSnapshot,
    //     state: RouterStateSnapshot): Observable<boolean> | boolean {
    //     const permissions = route.data['Permissions'] as Array<string>;
    //         if (this.userservice.isInRole('Administrator')) {
    //             if (this.userservice.isInRole('IsDeveloper')) {
    //                 const success = 'Allowed based on the IsSuperAdmin Role';
    //                 this.notificationsService.createSuccessMessage(success, '');
    //             }
    //             return true;
    //         }
    //         if (this.userservice.user.roles) {
    //             if ((permissions == null || this.userservice.user.Permissions.filter(r => permissions.indexOf(r) !== -1).length > 0)) {
    //                 if (this.userservice.isInRole('IsDeveloper')) {
    //                     const success = 'Allowed based on the following role: ' + permissions.toString().replace(',', ' ');
    //                     this.notificationsService.createSuccessMessage(success, '');
    //                 }
    //                 return true;
    //             }
    //         }
    //     }
    //     const error = 'You do not have access to this page, it requires the following permissions: ' + permissions.toString();
    //     this.notificationsService.createErrorMessage(error, 'Error!', 0);
    //     return false;
    // }
    public canActivate(route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> {
        return this.userservice.user.pipe(map(
            user => {
                const roles = route.data['roles'] as Array<string>;
                if (roles == null || user.roles.filter(r => roles.indexOf(r) !== -1).length > 0) {
                    const success = 'Allowed based on the following role: ' + roles.toString().replace(',', ' ');
                    this.notificationsService.createSuccessMessage(success, '');
                    return true;
                }
                const error = 'You do not have access to this page, it requires the following permissions: ' + roles.toString();
                this.notificationsService.createErrorMessage(error, 'Error!', 0);
                return false;
            }
        ));
    }
}

export interface CanComponentDeactivate {
    canDeactivate: () => Observable<boolean> | Promise<boolean> | boolean;
}

@Injectable()
export class CanDeactivateGuard implements CanDeactivate<CanComponentDeactivate> {
    canDeactivate(component: CanComponentDeactivate,
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot) {
        const url: string = state.url;
        console.log('Url: ' + url);

        return component.canDeactivate ? component.canDeactivate() : true;
    }
}
