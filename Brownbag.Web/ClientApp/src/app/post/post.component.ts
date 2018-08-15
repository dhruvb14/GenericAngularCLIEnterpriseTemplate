import { Component, OnInit } from '@angular/core';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { LookupsService } from '../../shared/service/lookups.service';
import { PostService } from './post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent extends GridComponentBaseService<Models.PostViewModel> implements OnInit {
  public BlogLookups: Models.LookupViewModel[];

  constructor(private lookupsService: LookupsService, gridService: PostService, notificationsService: AdvGrowlService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService);

    // This Overrides the Title used on the Grid
    this.entityTitleSingular = 'Post';
    this.entityTitlePlural = 'Posts';

  }
  initilizeLookups() {
    this.lookupsService.getBlogs().subscribe(
      result => {
        if (result != null) {
          this.BlogLookups = result;
        }
      });
  }
  ngOnInit() {
    this.getGridData();
    this.initilizeLookups();
    this.notificationsService.createSuccessMessage('Init Success', 'Post Component');
  }
}
