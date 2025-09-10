import { Routes, RouterModule } from '@angular/router';

import { AllUsersComponent } from './allUsers/allUsers.component';
import { FavouriteUsersComponent } from './favouriteUsers/favouriteUsers.component';

const routes: Routes = [
  { path: '', component: AllUsersComponent },
  { path: 'favourites', component: FavouriteUsersComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
