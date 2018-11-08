
import {shareReplay, map} from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject ,  Observable } from 'rxjs';


@Injectable()
export class UserService extends BehaviorSubject<UserModel> {

    public isAdmin: Observable<Boolean>;
    public isReviewer: Observable<Boolean>;
    public isScoringEmployee: Observable<Boolean>;
    public isBudgetRep: Observable<Boolean>;
    public isFINAdmin: Observable<Boolean>;
    public isSectionPOC: Observable<Boolean>;
    public isEvaluator: Observable<Boolean>;
    public isLCMAdmin: Observable<Boolean>;
    public isProjectManager: Observable<Boolean>;
    public isReadOnly: Observable<Boolean>;
    public isSubprogramOwner: Observable<Boolean>;

    constructor(private http: HttpClient) {
        super(null);
        this.getUserInformation();
        this.isAdmin = this.isInRole('Admin');
        this.isScoringEmployee = this.isInRole('Scoring Employee');
        this.isBudgetRep = this.isInRole('Budget Rep');
        this.isFINAdmin = this.isInRole('FIN Admin');
        this.isSectionPOC = this.isInRole('Section POC');
        this.isEvaluator = this.isInRole('Evaluator');
        this.isLCMAdmin = this.isInRole('LCM Admin');
        this.isProjectManager = this.isInRole('Project Manager');
        this.isReadOnly = this.isInRole('Read Only');
        this.isSubprogramOwner = this.isInRole('Subprogram Owner');
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
