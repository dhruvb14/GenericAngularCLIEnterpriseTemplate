import { Component, OnInit } from '@angular/core';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { BlogFKService } from './blog-fk.service';
import { UserService } from '../../shared/service/user.service';

@Component({
  selector: 'app-blog-fk',
  templateUrl: './blog-fk.component.html',
  styleUrls: ['./blog-fk.component.css']
})
export class BlogFKComponent extends GridComponentBaseService<Models.BlogFKViewModel> implements OnInit {
  public PostsCols: any[];
  entityTitleSingular = 'Blog FK';
  entityTitlePlural = 'Blogs FK';
  constructor(gridService: BlogFKService, notificationsService: AdvGrowlService, userService: UserService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService, userService);

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
