/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PostComponent } from './post.component';
import { PostService } from './post.service';
import { AdvGrowlService, AdvGrowlModule } from 'primeng-advanced-growl';
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
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PostData } from './post.data';
import { LookupsService } from '../../shared/service/lookups.service';

describe('PostComponent', () => {
  let component: PostComponent;
  let fixture: ComponentFixture<PostComponent>;
  const mockLookupService = jasmine.createSpyObj('mockLookupService', ['getBlogs']);
  const mockAdvGrowlService = jasmine.createSpyObj('mockAdvGrowlService', ['createSuccessMessage']);
  const mockBlogViewService = jasmine.createSpyObj('mockBlogViewService', ['getGrid']);
  const afrTypesResponse: Models.LookupViewModel[] = [
    { 'ID': 1, 'Value': 'google.com' },
    { 'ID': 2, 'Value': 'apple.com' }
  ];

  beforeEach(async(() => {
    mockLookupService.getBlogs.and.returnValue(of(afrTypesResponse));
    mockBlogViewService.getGrid.and.returnValue(of(PostData));
    TestBed.configureTestingModule({
      declarations: [ PostComponent ],
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
        { provide: PostService, useValue: mockBlogViewService },
        { provide: AdvGrowlService, useValue: mockAdvGrowlService },
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should open Add Post modal', async(() => {
    const cell = fixture.debugElement.queryAll(By.css('.ui-table-caption.ui-widget-header.ng-star-inserted .ng-star-inserted button'))[0];
    cell.nativeElement.click();

    fixture.detectChanges();
    const modal = fixture.debugElement.queryAll(By.css('.ui-dialog-titlebar.ui-widget-header span'))[0];
    expect(modal.nativeElement.textContent).toEqual('Add Post');
  }));

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h2').textContent;
    expect(titleText).toEqual('Posts');
  }));

  it('should call onRowSelect on row click', async(() => {
    const spy = spyOn(component, 'onRowSelect');
    fixture.detectChanges();
    const cell = fixture.debugElement.queryAll(By.css('.ui-table-tbody .ng-star-inserted'))[0];
    cell.nativeElement.click();
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      expect(spy).toHaveBeenCalled();
    });
  }));

});
