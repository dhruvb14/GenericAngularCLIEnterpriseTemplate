import { Component, OnInit } from '@angular/core';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { LookupsService } from '../../shared/service/lookups.service';
import { UserService } from '../../shared/service/user.service';
import { zip } from 'rxjs';
import { UsersLookupService } from './users-lookup.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent extends GridComponentBaseService<Models.UsersViewModel> implements OnInit {
  entityTitleSingular = 'User';
  entityTitlePlural = 'User';
  roles: Models.StringOptionsLookupViewModel[];
  constructor(gridService: UsersLookupService,
    notificationsService: AdvGrowlService,
    public lookupsService: LookupsService,
    public userService: UserService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService, userService);
  }
  ngOnInit() {
    zip(
      this.lookupsService.getRoles(),
    ).subscribe(([roles]) => {
      this.roles = roles;
    });
    this.getGridData();
    // this.notificationsService.createSuccessMessage('Init Success', this.entityTitleSingular + ' Component');
  }
}

