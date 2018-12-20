import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AdvGrowlModule } from 'primeng-advanced-growl';
import {
  DropdownModule,
  DialogModule,
  PaginatorModule,
  InputTextareaModule,
  RatingModule,
  EditorModule,
  DataGridModule,
  CardModule,
  ListboxModule
} from 'primeng/primeng';
import { LookupsService } from '../shared/service/lookups.service';
import { AppComponent } from './app.component';
import { BlogFKComponent } from './blog-fk/blog-fk.component';
import { BlogFKService } from './blog-fk/blog-fk.service';
import { BlogViewComponent } from './blog-view/blog-view.component';
import { BlogViewService } from './blog-view/blog-view.service';
import { BlogComponent } from './blog/blog.component';
import { BlogService } from './blog/blog.service';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PostComponent } from './post/post.component';
import { PostService } from './post/post.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from '../shared/service/user.service';
import { AuthGuardService } from '../shared/service/auth-guard.service';
import { HttpRequestInterceptor } from '../shared/service/http-request.interceptor';
import { UsersComponent } from './users/users.component';
import { TableModule } from 'primeng/table';
import { UsersLookupService } from './users/users-lookup.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    BlogComponent,
    PostComponent,
    BlogViewComponent,
    BlogFKComponent,
    UsersComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NgbModule.forRoot(),
    HttpClientModule,
    FormsModule,
    DropdownModule,
    TableModule,
    DialogModule,
    PaginatorModule,
    InputTextareaModule,
    RatingModule,
    EditorModule,
    DataGridModule,
    CardModule,
    BrowserAnimationsModule,
    AdvGrowlModule,
    ListboxModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      {
        path: 'counter', component: CounterComponent, canActivate: [AuthGuardService],
        data: { roles: ['Developer'] }
      },
      {
        path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuardService],
        data: { roles: ['Developer'] }
      },
      {
        path: 'blog', component: BlogComponent, canActivate: [AuthGuardService],
        data: { roles: ['Administrator'] }
      },
      {
        path: 'post', component: PostComponent, canActivate: [AuthGuardService],
        data: { roles: ['Administrator'] }
      },
      {
        path: 'blogview', component: BlogViewComponent, canActivate: [AuthGuardService],
        data: { roles: ['Administrator'] }
      },
      {
        path: 'blogviewfk', component: BlogFKComponent, canActivate: [AuthGuardService],
        data: { roles: ['Administrator'] }
      },
      {
        path: 'users', component: UsersComponent, canActivate: [AuthGuardService],
        data: { roles: ['Administrator'] }
      },
    ]),
  ],

  providers: [BlogService,
    BlogViewService,
    BlogFKService,
    PostService,
    LookupsService,
    UserService,
    UsersLookupService,
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpRequestInterceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
