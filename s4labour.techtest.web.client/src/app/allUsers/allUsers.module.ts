import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AllUsersComponent } from './allUsers.component';
import { UserListComponent } from '../userlist/userlist.component';
import { UserComponent } from '../user/user.component';

@NgModule({
  declarations: [
    AllUsersComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    UserListComponent, UserComponent
  ],
  providers: [],
  bootstrap: [AllUsersComponent]
})
export class AllUsersModule { }
