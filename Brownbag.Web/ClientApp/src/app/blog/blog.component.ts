import { Component, OnInit } from '@angular/core';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { BlogService } from './blog.service';
import { UserService } from '../../shared/service/user.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent extends GridComponentBaseService<Models.BlogViewModel> implements OnInit {
  public PostsCols: any[];
  entityTitleSingular = 'Blog';
  entityTitlePlural = 'Blogs';
  constructor(gridService: BlogService, notificationsService: AdvGrowlService, userService: UserService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService, userService);

    // This Overrides the Title used on the Grid
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
