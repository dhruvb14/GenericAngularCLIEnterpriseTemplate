/* tslint:disable:no-unused-variable */
import { HttpClientModule, HttpBackend } from '@angular/common/http';
import { async, ComponentFixture, TestBed, getTestBed } from '@angular/core/testing';
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
import { GridRestCallsBaseService } from '../../shared/service/grid-base-rest.service';
import { LookupsService } from '../../shared/service/lookups.service';
import { BlogViewComponent } from './blog-view.component';
import { blogViewGridData } from './blog-view.data';
import { BlogViewService } from './blog-view.service';


describe('BlogViewComponent', () => {
  let component: BlogViewComponent;
  let fixture: ComponentFixture<BlogViewComponent>;
  const mockLookupService = jasmine.createSpyObj('mockLookupService', ['getBlogs']);
  const mockBlogViewService = jasmine.createSpyObj('mockBlogViewService', ['getGrid']);
  const mockAdvGrowlService = jasmine.createSpyObj('mockAdvGrowlService', ['createSuccessMessage']);
  const afrTypesResponse: Brownbag.Web.Models.LookupViewModel[] = [
    { 'ID': 1, 'Value': 'google.com' },
    { 'ID': 2, 'Value': 'apple.com' }
  ];

  beforeEach(async(() => {
    mockLookupService.getBlogs.and.returnValue(Observable.of(afrTypesResponse));
    mockBlogViewService.getGrid.and.returnValue(Observable.of(blogViewGridData));
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
        { provide: LookupsService, useValue: mockLookupService },
        { provide: BlogViewService, useValue: mockBlogViewService },
        { provide: AdvGrowlService, useValue: mockAdvGrowlService },
      ]
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
  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h2').textContent;
    expect(titleText).toEqual('Blogs Content');
  }));
  it('should choose second drop down', async(() => {
    component.CurrentBlogId = 2;
    fixture.detectChanges();

    // const titleText = fixture.nativeElement.querySelector('h2').textContent;
    expect(component.CurrentBlogId).toEqual(2);
  }));
});
