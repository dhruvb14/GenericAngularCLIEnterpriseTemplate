import { Component, OnInit } from '@angular/core';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { BlogFKService } from './blog-fk.service';

@Component({
  selector: 'app-blog-fk',
  templateUrl: './blog-fk.component.html',
  styleUrls: ['./blog-fk.component.css']
})
export class BlogFKComponent extends GridComponentBaseService<Brownbag.Web.Models.BlogViewModel> implements OnInit {
  public PostsCols: any[];
  constructor(gridService: BlogFKService, notificationsService: AdvGrowlService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService);

    // This Overrides the Title used on the Grid
    this.entityTitleSingular = 'Blog FK';
    this.entityTitlePlural = 'Blogs FK';
    this.PostsCols = [
      { field: 'Title', header: 'Title' },
      { field: 'Content', header: 'Content' },
  ];

  }
  ngOnInit() {
    this.getGridData();
    this.notificationsService.createSuccessMessage('Init Success', 'Blog Component');
  }
}
