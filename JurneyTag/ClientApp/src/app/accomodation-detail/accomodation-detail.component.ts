import { AccomodationService } from './../accomodation.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

declare let L;
declare let tomtom: any;

@Component({
  selector: 'app-accomodation-detail',
  templateUrl: './accomodation-detail.component.html',
  styleUrls: ['./accomodation-detail.component.css']
})
export class AccomodationDetailComponent implements OnInit {
  mainImage : any;
  map:any;
  marker: any;

  constructor(@Inject(MAT_DIALOG_DATA) private accomodation : any, private accomodationService : AccomodationService){}
  
  ngOnInit(){
    this.accomodationService.getMainPhoto(this.accomodation.id)
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
    center: [ this.accomodation.location.mapPositionLatitude, this.accomodation.location.mapPositionLongitude ],
    zoom: 10,
    source : 'vector'
  });
  this.marker = tomtom.L.marker([this.accomodation.location.mapPositionLatitude, this.accomodation.location.mapPositionLongitude]).addTo(this.map);
}
}
