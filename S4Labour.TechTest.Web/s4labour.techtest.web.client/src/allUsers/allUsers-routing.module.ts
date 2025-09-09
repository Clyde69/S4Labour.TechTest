import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FavouriteUsersComponent } from '../favouriteUsers/favouriteUsers.component';
import { AllUsersComponent } from './allUsers.component';

const routes: Routes = [
  { path: 'index', component: AllUsersComponent },
  { path: 'favourites', component: FavouriteUsersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AllUsersRoutingModule { }
