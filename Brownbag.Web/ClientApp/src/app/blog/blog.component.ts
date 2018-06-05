import { Component, OnInit } from '@angular/core';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { BlogService } from './blog.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent extends GridComponentBaseService<Brownbag.Web.Models.BlogViewModel> implements OnInit {
  public PostsCols: any[];
  constructor(gridService: BlogService, notificationsService: AdvGrowlService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService);

    // This Overrides the Title used on the Grid
    this.entityTitleSingular = 'Blog';
    this.entityTitlePlural = 'Blogs';
    this.PostsCols = [
      { field: 'Title', header: 'Title' },
      { field: 'Content', header: 'Content' },
  ];

  }
  ngOnInit() {
    this.getGridData();
    this.notificationsService.createSuccessMessage('Created Success Message', 'Summary');
  }
}
