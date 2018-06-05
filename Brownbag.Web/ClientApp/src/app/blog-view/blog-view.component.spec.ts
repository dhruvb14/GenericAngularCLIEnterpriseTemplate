/* tslint:disable:no-unused-variable */
import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdvGrowlModule, AdvGrowlService } from 'primeng-advanced-growl';
import { CardModule } from 'primeng/card';
import { DataGridModule } from 'primeng/datagrid';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { EditorModule } from 'primeng/editor';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { PaginatorModule } from 'primeng/paginator';
import { RatingModule } from 'primeng/rating';
import { TableModule } from 'primeng/table';
import { Observable } from 'rxjs/Observable';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { LookupsService } from '../../shared/service/lookups.service';
import { BlogViewComponent } from './blog-view.component';
import { blogViewGridData } from './blog-view.data';
import { BlogViewService } from './blog-view.service';


describe('BlogViewComponent', () => {
  let component: BlogViewComponent;
  let fixture: ComponentFixture<BlogViewComponent>;
  let LookupsServiceStub: Partial<LookupsService>;
  let BlogViewServiceStub: Partial<BlogViewService>;
  const AfrTypesResponse: Brownbag.Web.Models.LookupViewModel[] = [{ 'ID': 1, 'Value': 'google.com' }, { 'ID': 2, 'Value': 'apple.com' }];
  LookupsServiceStub = {
    getBlogs() {
      return Observable.of(AfrTypesResponse);
    }
  };
  BlogViewServiceStub = {
    // tslint:disable-next-line:max-line-length
    getGrid<T>(page: number, rows: number, searchQuery: string, optionalHttpParams?: { param: string, value: string }[]): Observable<T> {
      return Observable.of(blogViewGridData);
    }
  };
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [BlogViewComponent],
      imports: [
        HttpClientModule,
        FormsModule,
        DropdownModule,
        TableModule,
        DialogModule,
        PaginatorModule,
        InputTextareaModule,
        RatingModule,
        EditorModule,
        DataGridModule,
        CardModule,
        BrowserAnimationsModule,
        AdvGrowlModule,
      ],
      providers: [
        { provide: LookupsService, useValue: LookupsServiceStub },
        { provide: BlogViewService, useValue: BlogViewServiceStub },
        { provide: AdvGrowlService, useValue: AdvGrowlService },
        { provide: GridComponentBaseService, useValue: GridComponentBaseService }
      ]
      // private lookupsService: LookupsService, gridService: BlogViewService, notificationsService: AdvGrowlService
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
