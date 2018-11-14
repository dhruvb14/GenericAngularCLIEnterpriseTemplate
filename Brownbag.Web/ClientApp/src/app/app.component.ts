import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { UserService, UserModel } from '../shared/service/user.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Brownbag';
  footer = new Date().getFullYear() + ' Brownbag';
  public user: Observable<UserModel>;
  constructor(private router: Router, userService: UserService) {
    this.user = userService;
  }
  ngOnInit() {
    // This is so anytime you click a link it takes you to the top of the page
    // REF: https://stackoverflow.com/questions/39601026/angular-2-scroll-to-top-on-route-change
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
      window.scrollTo(0, 0);
    });
  }
}
