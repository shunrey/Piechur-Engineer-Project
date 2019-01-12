import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { AttractionService } from './../attraction.service';
import { Attraction } from './../Models/Attraction';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare let L;
declare let tomtom: any;

@Component({
  selector: 'attraction-new',
  templateUrl: './attraction-new.component.html',
  styleUrls: ['./attraction-new.component.css']
})
export class AttractionNewComponent implements OnInit {

  
  constructor(private attractionService : AttractionService, private snackBar : MatSnackBar,
              private router : Router, private httpClient : HttpClient) { }
  
  map:any;
  marker: any;
  woj: string;
  response : any;
  latitude: number = 50.05481;
  longitude : number = 19.92784;
  attractionPeriods : string[] = ['Cały sezon', 'Okres zimowy', 'Okres letni', 'Nie dotyczy'];

  attraction : Attraction = {
    name : '',
    description : '',
    seasonOpen : '',
    location : {
      mapPositionLatitude: undefined,
      mapPositionLongitude: undefined,
    },
    address : {
      city : '',
      street: '',
      build: '',
    },
    ticketPrice : undefined,
    halfTicketPrice : undefined,
    mainImage: undefined,
    id : undefined,
  };

  ngOnInit() {
  }

  initalizeMap() {
    this.map = tomtom.L.map('map', {
      key: '8oXUWjwdr1KtlIlQyrBsTXyAd1wqfDcI',
      basePath: '/assets/sdk',
      center: [ this.latitude, this.longitude ],
      zoom: 16,
      source : 'vector'
    });
    this.marker = tomtom.L.marker([this.latitude, this.longitude]).addTo(this.map);
  }
  
  reloadMap(){
    this.map.setView([this.latitude, this.longitude],16);
    this.map.removeLayer(this.marker);
    this.marker = tomtom.L.marker([this.latitude, this.longitude]).addTo(this.map);
  }
  
  log(){
    console.log("Hi");
  }
  
  submit(){
    console.log("Here" + this.attraction);
    this.attraction.location.mapPositionLatitude = this.latitude;
    this.attraction.location.mapPositionLongitude = this.longitude;
    this.attractionService.addAttraction(this.attraction).subscribe(resp => {
      this.snackBar.open("Dodano nową atrakcję do katalogu", "Zamknij", {
        duration: 2000,
      });
      this.router.navigate(['/listAttr']);
    })
  }
  
  getCoordinates(){
    this.httpClient.get("https://api.tomtom.com/search/2/geocode/"+this.attraction.address.city + " " +
                                                                   this.attraction.address.street + " " +
                                                                   this.attraction.address.build +".json?countrySet=Pl&key=8oXUWjwdr1KtlIlQyrBsTXyAd1wqfDcI")
                   .subscribe( (resp) => {
                     this.response = resp;
                     console.log(this.response)
                     this.latitude = this.response.results[0].position.lat;
                     this.longitude = this.response.results[0].position.lon;
                     if (this.map == undefined) this.initalizeMap(); 
                     if (this.map != null) this.reloadMap();
                   })
  }
  
  selectionChange(event){
    if (event.selectedIndex == 1){
      this.getCoordinates();
      
    }
    if (event.selectedIndex == 0){
      this.getCoordinates();
      
    }
  }

}
