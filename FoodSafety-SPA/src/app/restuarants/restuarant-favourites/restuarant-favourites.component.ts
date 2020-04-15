import { Component, OnInit } from '@angular/core';
import { Restuarant } from 'src/app/models/restuarants';
import { AuthService } from 'src/_services/auth.service';
import { RestuarantService } from 'src/_services/restuarant.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-restuarant-favourites',
  templateUrl: './restuarant-favourites.component.html',
  styleUrls: ['./restuarant-favourites.component.css']
})
export class RestuarantFavouritesComponent implements OnInit {
  restuarants: any[];

  constructor(private authService: AuthService, private restuarantService: RestuarantService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.restuarants = data['data'];
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

}
