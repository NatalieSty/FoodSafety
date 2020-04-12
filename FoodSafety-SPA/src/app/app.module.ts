import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AlertModule } from 'ngx-bootstrap';


import { AppComponent } from './app.component';
import { RestuarantsComponent } from './restuarants/restuarants.component';
import { RestuarantService } from 'src/_services/restuarant.service';
import { NavComponent } from './nav/nav.component';
import { RestuarantFavouritesComponent } from './restuarants/restuarant-favourites/restuarant-favourites.component';
import { RestaurantListResolver } from './_resolver/restaurant-list.resolver';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';

@NgModule({
   declarations: [
      AppComponent,
      RestuarantsComponent,
      NavComponent,
      RestuarantFavouritesComponent,
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      AlertModule.forRoot(),
      RouterModule.forRoot(appRoutes),

      
   ],
   providers: [
      RestuarantService,
      RestaurantListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
