import { Component, OnInit } from '@angular/core';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { LookupsService } from '../../shared/service/lookups.service';
import { BlogViewService } from './blog-view.service';

@Component({
  selector: 'app-blog-view',
  templateUrl: './blog-view.component.html',
  styleUrls: ['./blog-view.component.css']
})
export class BlogViewComponent extends GridComponentBaseService<Brownbag.Web.Models.BlogPostsViewModel> implements OnInit {
  public BlogLookups: Brownbag.Web.Models.LookupViewModel[];
  public CurrentBlogId = 1;
  constructor(private lookupsService: LookupsService, gridService: BlogViewService, notificationsService: AdvGrowlService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService);

    // This Overrides the Title used on the Grid
    this.entityTitleSingular = 'Blog View';
    this.entityTitlePlural = 'Blogs Content';
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
    this.notificationsService.createSuccessMessage('Created Success Message', 'Summary');
  }
}
