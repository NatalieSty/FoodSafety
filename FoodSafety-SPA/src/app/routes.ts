import { Routes } from '@angular/router';
import { RestuarantsComponent } from './restuarants/restuarants.component';
import { RestaurantListResolver } from './_resolver/restaurant-list.resolver';
import { RestuarantFavouritesComponent } from './restuarants/restuarant-favourites/restuarant-favourites.component';
import { FavoriteListResolver } from './_resolver/favorite-list.resolver';
import { RegisterComponent } from './register/register.component';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserEditResolver } from './_resolver/user-edit.resolver';

export const appRoutes: Routes = [
    { path: 'home', component: RestuarantsComponent, resolve: {data: RestaurantListResolver}},
    { path: 'favorites', component: RestuarantFavouritesComponent, resolve: {data: FavoriteListResolver}},
    { path: 'register', component: RegisterComponent},
    { path: 'user/edit', component: UserEditComponent, resolve: {data: UserEditResolver}},
    { path: '**', redirectTo: 'home', pathMatch: 'full'},
];