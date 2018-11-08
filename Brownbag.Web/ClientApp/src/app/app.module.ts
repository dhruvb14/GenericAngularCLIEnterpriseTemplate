import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AdvGrowlModule } from 'primeng-advanced-growl';
import { CardModule } from 'primeng/card';
import { DataGridModule } from 'primeng/datagrid';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { EditorModule } from 'primeng/editor';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { PaginatorModule } from 'primeng/paginator';
import { RatingModule } from 'primeng/rating';
import { TableModule } from 'primeng/table';
import { LookupsService } from '../shared/service/lookups.service';
import { AppComponent } from './app.component';
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

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    BlogComponent,
    PostComponent,
    BlogViewComponent
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
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'blog', component: BlogComponent },
      { path: 'post', component: PostComponent },
      { path: 'blogview', component: BlogViewComponent },
    ]),
  ],
  providers: [BlogService, BlogViewService, PostService, LookupsService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
