import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AllUsersModule } from './app/allUsers/allUsers.module';
import { FavouriteUsersModule } from './app/favouriteUsers/favouriteUsers.module';
import { AppModule } from './app/app.module';

platformBrowserDynamic().bootstrapModule(AppModule, {
  ngZoneEventCoalescing: true,
})
  .catch(err => console.error(err));

platformBrowserDynamic().bootstrapModule(AllUsersModule, {
  ngZoneEventCoalescing: true,
})
  .catch(err => console.error(err));
platformBrowserDynamic().bootstrapModule(FavouriteUsersModule, {
  ngZoneEventCoalescing: true,
})
  .catch(err => console.error(err));
