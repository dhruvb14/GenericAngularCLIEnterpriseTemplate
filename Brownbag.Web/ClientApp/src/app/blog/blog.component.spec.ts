/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule, HttpBackend } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
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

import { BlogComponent } from './blog.component';
import { BlogService } from './blog.service';
import { BlogData } from './blog.data';

describe('BlogComponent', () => {
  let component: BlogComponent;
  let fixture: ComponentFixture<BlogComponent>;
  const mockAdvGrowlService = jasmine.createSpyObj('mockAdvGrowlService', ['createSuccessMessage']);
  const mockBlogViewService = jasmine.createSpyObj('mockBlogViewService', ['getGrid']);

  beforeEach(async(() => {
    mockBlogViewService.getGrid.and.returnValue(Observable.of(BlogData));
    TestBed.configureTestingModule({
      declarations: [BlogComponent],
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
        { provide: BlogService, useValue: mockBlogViewService },
        { provide: AdvGrowlService, useValue: mockAdvGrowlService },
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should open Add Blog modal', async(() => {
    const cell = fixture.debugElement.queryAll(By.css('.ui-table-caption.ui-widget-header.ng-star-inserted .ng-star-inserted button'))[0];
    cell.nativeElement.click();

    fixture.detectChanges();
    const modal = fixture.debugElement.queryAll(By.css('.ui-dialog-titlebar.ui-widget-header span'))[0];
    expect(modal.nativeElement.textContent).toEqual('Add Blog');
  }));

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h2').textContent;
    expect(titleText).toEqual('Blogs');
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

  // it('should open Edit Post modal', async(() => {
  //   fixture.detectChanges();
  //   // const cell = fixture.debugElement.queryAll(By.css('.ui-table-tbody .ng-star-inserted'))[0];
  //   const cell = fixture.debugElement.queryAll(By.css('tr.ng-star-inserted'))[1];
  //   cell.nativeElement.click();
  //   fixture.detectChanges();

  //   const modal = fixture.debugElement.queryAll(By.css('#ui-dialog-1-label'))[0];
  //   expect(modal.nativeElement.textContent).toEqual('Edit Blog');
  // }));

});
