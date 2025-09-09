import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AllUsersModule } from './allUsers/allUsers.module';
import { FavouriteUsersModule } from './favouriteUsers/favouriteUsers.module';

platformBrowserDynamic().bootstrapModule(AllUsersModule, {
  ngZoneEventCoalescing: true,
})
  .catch(err => console.error(err));
platformBrowserDynamic().bootstrapModule(FavouriteUsersModule, {
  ngZoneEventCoalescing: true,
})
  .catch(err => console.error(err));
