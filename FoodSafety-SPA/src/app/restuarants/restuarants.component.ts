import { Component, OnInit, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { Restuarant } from '../models/restuarants';
import { RestuarantService } from 'src/_services/restuarant.service';
import { Route } from '@angular/compiler/src/core';
import { Router, ActivatedRoute } from '@angular/router';

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

  constructor(private restuarantService: RestuarantService, private route: ActivatedRoute) { }

  ngOnInit() {

    this.route.data.subscribe(data => {
      this.restuarants = data['data'].result;
      this.lat = this.restuarants[0].latitude;
      this.lng = this.restuarants[0].longtitude;
    });
    
    this.getMarkers();
  }

  getMarkers() {
    this.restuarants.forEach(r => {
      this.markers.push({
        position: new google.maps.LatLng(r.latitude, r.longtitude),
        map: this.map,
        title: r.name,
        grade: r.grade
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
    console.log(this.markers);
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
