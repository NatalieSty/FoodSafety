import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AlertModule } from 'ngx-bootstrap';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { RestuarantsComponent } from './restuarants/restuarants.component';
import { RestuarantService } from 'src/_services/restuarant.service';
import { NavComponent } from './nav/nav.component';
import { RestuarantFavouritesComponent } from './restuarants/restuarant-favourites/restuarant-favourites.component';
import { RestaurantListResolver } from './_resolver/restaurant-list.resolver';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { AuthService } from 'src/_services/auth.service';
import { FormsModule } from '@angular/forms';
import { FavoriteListResolver } from './_resolver/favorite-list.resolver';


export function tokenGetter(){
   return localStorage.getItem('token');
}
@NgModule({
   declarations: [
      AppComponent,
      RestuarantsComponent,
      NavComponent,
      RestuarantFavouritesComponent,
   ],
   imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      AlertModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
      
   ],
   providers: [
      RestuarantService,
      RestaurantListResolver,
      AuthService,
      FavoriteListResolver,
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
