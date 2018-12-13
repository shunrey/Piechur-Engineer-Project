import { CityService } from './../city.service';
import { City } from './../Model/City';
import { Icons } from 'quill/ui/icons';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare let L;
declare let tomtom: any;

@Component({
  selector: 'city-new',
  templateUrl: './city-new.component.html',
  styleUrls: ['./city-new.component.css']
})
export class CityNewComponent implements OnInit {
 
  constructor(private httpClient : HttpClient, private cityService : CityService) { }
  
  map:any;
  marker: any;
  woj: string;
  response : any;
  latitude: number = 50.05481;
  longitude : number = 19.92784;
  city : City = {
    id:0,
    name: '',
    description: '',
    location : {
      mapPositionLatitude : 120,
      mapPositionLongitude : 120,
    },
  };

  ngOnInit() {
  }

  customStyle = {
    selectButton: {
      "color": "white",
      "background-color": "#00796b",
    },
    clearButton: {
      "display": "none",
    },
    layout: {
      "background-color": "white",
      "color": "gray",
      "font-size": "15px",
    },
    previewPanel: {
      "background-color": "white",
    }
  };

initalizeMap() {
  this.map = tomtom.L.map('map', {
    key: '8oXUWjwdr1KtlIlQyrBsTXyAd1wqfDcI',
    basePath: '/assets/sdk',
    center: [ this.latitude, this.longitude ],
    zoom: 10,
    source : 'vector'
  });
  this.marker = tomtom.L.marker([this.latitude, this.longitude]).addTo(this.map);
}

reloadMap(){
  this.map.setView([this.latitude, this.longitude],10);
  this.map.removeLayer(this.marker);
  this.marker = tomtom.L.marker([this.latitude, this.longitude]).addTo(this.map);
}

log(){
  console.log("Hi");
}

save(){
  console.log("Here" + this.city);
  this.cityService.addCity(this.city);
}

getCoordinates(){
  this.httpClient.get("https://api.tomtom.com/search/2/geocode/"+this.city.name+".json?countrySet=Pl&key=8oXUWjwdr1KtlIlQyrBsTXyAd1wqfDcI")
                 .subscribe( (resp) => {
                   this.response = resp;
                   console.log(this.response.results[0].position)
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
