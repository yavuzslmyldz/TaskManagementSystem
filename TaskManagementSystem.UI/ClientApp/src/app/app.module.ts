import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TaskEditorComponent } from './tasks/task-editor/task-editor.component';
import { TaskFormComponent } from './tasks/task-form/task-form.component';
import { CommentsComponent, } from './comments/comments.component';
import { CommentFormComponent, } from './comment-form/comment-form.component';
import { CommentFilterPipe, } from './app-util/commentFilter.pipe';
import { TaskService } from './app-service/task.service';
import { CommentService } from './app-service/comment.service';


import { MatTableModule } from '@angular/material/table';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSnackBarModule, MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    DashboardComponent,
    TaskEditorComponent,
    TaskFormComponent,
    CommentsComponent,
    CommentFilterPipe,
    CommentFormComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatTableModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'edit-task/:id', component: TaskEditorComponent },
      { path: 'add-task', component: TaskFormComponent }
    ])
  ],
  providers: [
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 } },
    TaskService,
    CommentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
