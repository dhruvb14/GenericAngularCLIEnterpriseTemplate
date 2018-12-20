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
import { Observable, of } from 'rxjs';
import { GridRestCallsBaseService } from '../../shared/service/grid-base-rest.service';
import { LookupsService } from '../../shared/service/lookups.service';
import { BlogFKComponent } from './blog-fk.component';
import { BlogFKService } from './blog-fk.service';
import { blogViewGridData } from '../blog-view/blog-view.data';
import { UserService } from '../../shared/service/user.service';


describe('BlogFKComponent', () => {
  let component: BlogFKComponent;
  let fixture: ComponentFixture<BlogFKComponent>;
  const mockLookupService = jasmine.createSpyObj('mockLookupService', ['getBlogs']);
  const mockBlogFKService = jasmine.createSpyObj('mockBlogFKService', ['getGrid']);
  const mockAdvGrowlService = jasmine.createSpyObj('mockAdvGrowlService', ['createSuccessMessage']);
  const mockUserService = jasmine.createSpyObj('mockUserService', ['']);

  const afrTypesResponse: Models.LookupViewModel[] = [
    { 'ID': 1, 'Value': 'google.com' },
    { 'ID': 2, 'Value': 'apple.com' }
  ];

  beforeEach(async(() => {
    mockLookupService.getBlogs.and.returnValue(of(afrTypesResponse));
    mockBlogFKService.getGrid.and.returnValue(of(blogViewGridData));
    TestBed.configureTestingModule({
      declarations: [BlogFKComponent],
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
        { provide: BlogFKService, useValue: mockBlogFKService },
        { provide: AdvGrowlService, useValue: mockAdvGrowlService },
        { provide: UserService, useValue: mockUserService },

      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogFKComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h2').textContent;
    expect(titleText).toEqual('Blogs FK');
  }));
});
