import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { AllUsersModule } from './allUsers/allUsers.module';
import { FavouriteUsersModule } from './favouriteUsers/favouriteUsers.module';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    AllUsersModule,
    FavouriteUsersModule
  ],
  declarations: [
    AppComponent,
  ],
  exports: [
    AllUsersModule,
    FavouriteUsersModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { };
