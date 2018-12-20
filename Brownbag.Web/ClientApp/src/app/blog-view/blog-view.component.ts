import { Component, OnInit } from '@angular/core';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { LookupsService } from '../../shared/service/lookups.service';
import { BlogViewService } from './blog-view.service';
import { UserService } from '../../shared/service/user.service';

@Component({
  selector: 'app-blog-view',
  templateUrl: './blog-view.component.html',
  styleUrls: ['./blog-view.component.css']
})
export class BlogViewComponent extends GridComponentBaseService<Models.BlogPostsViewModel> implements OnInit {
  public BlogLookups: Models.LookupViewModel[];
  public CurrentBlogId = 1;
  entityTitleSingular = 'Blog View';
  entityTitlePlural = 'Blogs Content';
  constructor(private lookupsService: LookupsService,
    gridService: BlogViewService,
    notificationsService: AdvGrowlService,
    userService: UserService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService, userService);
  }
  initilizeLookups() {
    this.lookupsService.getBlogs().subscribe(
      result => {
        if (result != null) {
          this.BlogLookups = result;
          this.getGridData();
        }
      });
  }

  getGridData() {
    super.getGridData([{ param: 'blogId', value: this.CurrentBlogId.toString() }]);
  }

  ngOnInit() {
    this.initilizeLookups();
    this.notificationsService.createSuccessMessage('Init Success', 'Blog View Component');
  }
}
