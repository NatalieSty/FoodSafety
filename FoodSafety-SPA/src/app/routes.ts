import { Routes } from '@angular/router';
import { RestuarantsComponent } from './restuarants/restuarants.component';
import { RestaurantListResolver } from './_resolver/restaurant-list.resolver';
import { RestuarantFavouritesComponent } from './restuarants/restuarant-favourites/restuarant-favourites.component';

export const appRoutes: Routes = [
    { path: 'home', component: RestuarantsComponent, resolve: {data: RestaurantListResolver}},
    { path: 'favorites', component: RestuarantFavouritesComponent},
];