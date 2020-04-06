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
      
   ],
   providers: [
      RestuarantService,
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
