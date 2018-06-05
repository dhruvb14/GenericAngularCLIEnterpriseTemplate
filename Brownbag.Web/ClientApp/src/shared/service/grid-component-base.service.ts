import { AdvGrowlService } from 'primeng-advanced-growl';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import { GridRestCallsBaseService } from './grid-base-rest.service';

export abstract class GridComponentBaseService<T> {
    public state: Brownbag.Web.Models.PrimeNG.Grid.GridViewModel<T>;
    public displayDialog: boolean;
    public selectedGridItem: T;
    public isNew: boolean;
    public editErrors: string;
    public searchQueryDebouncer: Subject<string> = new Subject<string>();

    // These are the default titles used if you do not override them in implementation
    public entityTitleSingular = 'Generic Entity';
    public entityTitlePlural = 'Generic Entities';
    /*
    This constructor expects a service handed to it which knows about the correct endpoints
    to communicate with. For examples look at the admin folder as all services in there
    are setup to use this grid base class correctly.
    */
    constructor(public gridService: GridRestCallsBaseService, public notificationsService: AdvGrowlService) {
        /*
        How to debounce search queries in angular without touch @angular/forms
        https://stackoverflow.com/a/40777621
        This SearchQueryDebouncer doesnt fire off search queries until after 500ms
        this helps reduce database load. It is not important for local but will be
        once we move to server client setup. This does NOT however deal with problems
        related to a query which was fired first returning second and overwriting the
        results of the correct (second) query.
        */
        this.searchQueryDebouncer
            .debounceTime(500) // wait 500ms after the last event before emitting last event
            .distinctUntilChanged() // only emit if value is different from previous value
            .subscribe(model => {
                this.state.SearchQuery = model;
                this.globalSearch(model);
            });
        /*
        This creates empty objects to prevent errors,
        this also adds intellisense to HTML templates
        since baseclass uses ANY as the type and we
        want strong typing
        */
        this.state = <Brownbag.Web.Models.PrimeNG.Grid.GridViewModel<T>>{};
    }
    showDialogToAdd() {
        this.editErrors = undefined;
        this.isNew = true;
        this.selectedGridItem = <T>{};
        this.displayDialog = true;
    }
    paginate(event: GridPaginatorEvent) {
        this.state.Page = event.page + 1;
        this.state.Rows = event.rows;
        this.getGridData();
    }
    onRowSelect(event: any) {
        this.isNew = false;
        this.editErrors = undefined;
        this.selectedGridItem = this.clone(event.data);
        // Below check is to see if the data has already been fetched in previous
        // Call, if already in the selectd plan no need to refetch data
        this.gridService.getGridItemDetails<T>((<any>this.selectedGridItem).Id)
            .subscribe(
                result => {
                    if (result != null) {
                        this.selectedGridItem = result;
                        this.displayDialog = true;
                    }
                },
                error => {
                    this.state.Errors = error;
                    this.notificationsService.createTimedErrorMessage(error, 'Error!', 0);
                });
    }
    getGridData(optionalHttpParams?: { param: string, value: string }[]) {
        // tslint:disable-next-line:max-line-length
        this.gridService.getGrid<Brownbag.Web.Models.PrimeNG.Grid.GridViewModel<T>>(this.state.Page || undefined, this.state.Rows || undefined, this.state.SearchQuery || undefined, optionalHttpParams || undefined)
            .subscribe(
                result => {
                    if (result != null) {
                        this.state = result;
                    }
                },
                error => {
                    this.state.Errors = error;
                    this.notificationsService.createTimedErrorMessage(error, 'Error!', 0);
                });
    }
    searchDebouncer(text: string) {
        this.searchQueryDebouncer.next(text);
    }
    globalSearch(event: string) {
        if (event) {
            this.state.SearchQuery = event;
        }
        this.state.Page = undefined;
        this.state.Rows = undefined;
        this.state.First = undefined;
        this.state.PageCount = undefined;
        this.getGridData();
    }
    /*
    This clone method does NOT work for > single dimensional objects
    If you find you need a multi-dimensional clone please override it
    in your implemented class not this base class;
    */
    clone(e: T): T {
        const entity = <T>{};
        // tslint:disable-next-line:forin
        for (const prop in e) {
            if ((<any>prop) instanceof Object) {
                entity[<any>prop] = this.clone(<any>prop);
            }
            entity[prop] = e[prop];
        }
        return entity;
    }
    /*
    This method assumes that you use the EXACT same name attribute in
    the edit/add form as you do in the database. If you follow this
    assumption then just submitting the form data allows for basic CRUD
    without need to create a new object to send
    */
    save(formData: T) {
        this.editErrors = undefined;
        this.gridService.updateGridItem<T>(formData)
            .subscribe(
                result => {
                    if (result != null && !this.editErrors) {
                        this.displayDialog = false;
                        this.selectedGridItem = undefined;
                        this.editErrors = undefined;
                        this.notificationsService.createSuccessMessage('Save Successful', '');
                        this.getGridData();
                    }
                },
                error => {
                    this.editErrors = error;
                    this.notificationsService.createTimedErrorMessage(error, 'Error!', 0);
                });
    }

    close() {
        this.selectedGridItem = <T>{};
        this.displayDialog = false;
        this.getGridData();
    }

}
export interface GridPaginatorEvent {
    first: number;
    rows: number;
    page: number;
    pageCount: number;
}
