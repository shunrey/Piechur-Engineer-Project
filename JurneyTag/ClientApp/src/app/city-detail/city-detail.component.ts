import { CityService } from './../city.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

declare let L;
declare let tomtom: any;

@Component({
  selector: 'city-detail',
  templateUrl: './city-detail.component.html',
  styleUrls: ['./city-detail.component.css']
})
export class CityDetailComponent implements OnInit {

  mainImage : any;
  map:any;
  marker: any;

  constructor(@Inject(MAT_DIALOG_DATA) private city : any, private cityService : CityService){}
  
  ngOnInit(){
    this.cityService.getMainPhoto(this.city.id)
    .subscribe(result => {
       console.log(result);
       this.initalizeMap();
       this.createImageFromBlob(result)
    });  
    
  }

  createImageFromBlob(image: Blob) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
       this.mainImage = reader.result;
    }, false);
 
    if (image) {
       reader.readAsDataURL(image);
    }
}

initalizeMap() {
  this.map = tomtom.L.map('map', {
    key: '8oXUWjwdr1KtlIlQyrBsTXyAd1wqfDcI',
    basePath: '/assets/sdk',
    center: [ this.city.location.mapPositionLatitude, this.city.location.mapPositionLongitude ],
    zoom: 10,
    source : 'vector'
  });
  this.marker = tomtom.L.marker([this.city.location.mapPositionLatitude, this.city.location.mapPositionLongitude]).addTo(this.map);
}
}
