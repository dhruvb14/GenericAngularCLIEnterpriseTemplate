
import {shareReplay, map} from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject ,  Observable } from 'rxjs';


@Injectable()
export class UserService extends BehaviorSubject<UserModel> {

    public isAdmin: Observable<Boolean>;

    constructor(private http: HttpClient) {
        super(null);
        this.getUserInformation();
        this.isAdmin = this.isInRole('Administrator');
    }
    public user: Observable<UserModel>;

    fetch(): void {
        if (!this.user) {
            this.user = this.http.get<UserModel>('api/account/user').pipe(shareReplay());
        }
    }
    getUserInformation(): void {
        this.fetch();
        this.user
            .subscribe(data => {
                super.next(data);
            });
    }

    isInRole(role: string): Observable<boolean> {
        return this.user.pipe(map(user => {
            return (role == null || user.roles.filter(r => role === r).length > 0);
        }));
    }
    getUserName(): Observable<string> {
        return this.user.pipe(map(user => {
            return user.name;
        }));
    }

    isUserInList(guidList: Models.GuidLookupViewModel[]): Observable<boolean> {
        return this.user.pipe(map(user => {
            for (const author of guidList) {
                if (author.ID === user.id) {
                    return true;
                }
            }
            return false;
        }));
    }
    isCurrentUserMatch(guidID: string): Observable<boolean> {
        return this.user.pipe(map(user => {
            if (guidID === user.id) {
                return true;
            }
            return false;
        }));
    }


}

export class UserModel {
    roles: any[];
    name: string;
    id: string;
}
