import { Component, OnInit, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { Restuarant } from '../models/restuarants';
import { RestuarantService } from 'src/_services/restuarant.service';
import { Route } from '@angular/compiler/src/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/_services/auth.service';
import { AlertifyService } from 'src/_services/alertify.service';
import { Pagination, PaginatedResult } from '../models/pagination';

@Component({
  selector: 'app-restuarants',
  templateUrl: './restuarants.component.html',
  styleUrls: ['./restuarants.component.css']
})
export class RestuarantsComponent implements OnInit, AfterViewInit {
  @ViewChild('mapContainer', {static: false}) gmap: ElementRef;
  map: google.maps.Map;

  lat = 47.608013;
  lng = -122.335167;

  coordinates = new google.maps.LatLng(this.lat, this.lng);

  mapOptions: google.maps.MapOptions = {
    center: this.coordinates,
    zoom: 8
  };

  marker = new google.maps.Marker({
    position: this.coordinates,
    map: this.map,
  });

  markers = [];
 
  restuarants: Restuarant[];
  listParams: any = {};
  pagination: Pagination;

  constructor(private restuarantService: RestuarantService, private route: ActivatedRoute, 
              private authService: AuthService, private alert: AlertifyService) { }

  ngOnInit() {

    this.route.data.subscribe(data => {
      this.restuarants = data['data'].result;
      this.pagination = data['data'].pagination;
      this.lat = this.restuarants[0].latitude;
      this.lng = this.restuarants[0].longtitude;
    });

    this.getMarkers();
  }

  pageChanged(event: any): void{
    this.pagination.currentPage = event.page;
    this.loadRestuarants();
  }

  loadRestuarants() {
    this.restuarantService.getRestuarants(this.pagination.currentPage, this.pagination.itemsPerPage)
      .subscribe(
        (res: PaginatedResult<Restuarant[]>) => {
          this.restuarants = res.result;
          this.pagination = res.pagination;
        }, error => {
          this.alert.error(error);
        });
  }

  addFavorite(id) {
    this.alert.confirm("Are you sure you want to add this restaurant to favorite?", () => {
      this.restuarantService.addFavorite(id, this.authService.decodedToken.nameid).subscribe( () => {
        this.alert.success('Added new favorite');
      }, error => {
        this.alert.error(error.error);
      });
    })

  }

  getMarkers() {
    this.restuarants.forEach(r => {
      this.markers.push({
        position: new google.maps.LatLng(r.latitude, r.longtitude),
        map: this.map,
        title: r.name,
      });
    });
  }



  ngAfterViewInit() {
    this.mapInitializer();
  }

  mapInitializer() {
    this.map = new google.maps.Map(this.gmap.nativeElement,
    this.mapOptions);

    this.marker.addListener("click", () => {
      const infoWindow = new google.maps.InfoWindow({
        content: this.marker.getTitle()
      });
      infoWindow.open(this.marker.getMap(), this.marker);
    });

    this.marker.setMap(this.map);

    this.loadAllMarkers();
  }

  loadAllMarkers() {
    
    this.markers.forEach(markerInfo => {
      const marker = new google.maps.Marker({
        ...markerInfo
      });

      const infoWindow = new google.maps.InfoWindow({
        content: marker.getTitle()
      });

      marker.addListener("click", () => {
        infoWindow.open(marker.getMap(), marker);

      });

      marker.setMap(this.map);

    });


  }


}
