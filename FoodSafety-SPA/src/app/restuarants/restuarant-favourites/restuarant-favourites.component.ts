import { Component, OnInit } from '@angular/core';
import { Restuarant } from 'src/app/models/restuarants';
import { AuthService } from 'src/_services/auth.service';
import { RestuarantService } from 'src/_services/restuarant.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/_services/alertify.service';

@Component({
  selector: 'app-restuarant-favourites',
  templateUrl: './restuarant-favourites.component.html',
  styleUrls: ['./restuarant-favourites.component.css']
})
export class RestuarantFavouritesComponent implements OnInit {
  restuarants: any[];

  constructor(private authService: AuthService, private restuarantService: RestuarantService,
              private route: ActivatedRoute, private alert: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.restuarants = data['data'];
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  removeFavorite(id) {
    this.alert.confirm("Are you sure you want to remove this restaurant from favorites?", () => {
      this.restuarantService.removeFavorite(id, this.authService.decodedToken.nameid).subscribe(() => {
        this.restuarants.splice(this.restuarants.findIndex(m => m.businessId === id), 1);
        this.alert.success('Successfully removed from favorites');
      }, error => {
        this.alert.error(error.error);
      });
    });
  }

}
