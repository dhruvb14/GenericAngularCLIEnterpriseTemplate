import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { UserService } from '../../shared/service/user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  navbarCollapsed: Boolean;
  readonly baseURL = environment.apiUrl;
  constructor(public userService: UserService) {

  }
}
