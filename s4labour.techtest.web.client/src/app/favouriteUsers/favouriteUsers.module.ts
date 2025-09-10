import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//import { FavouriteUsersRoutingModule } from './favouriteUsers-routing.module';
import { FavouriteUsersComponent } from './favouriteUsers.component';
import { UserListComponent } from '../userlist/userlist.component';
import { UserComponent } from '../user/user.component';

@NgModule({
  declarations: [
    FavouriteUsersComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    //FavouriteUsersRoutingModule,
    UserListComponent, UserComponent
  ],
  providers: [],
  bootstrap: [FavouriteUsersComponent]
})
export class FavouriteUsersModule { }
