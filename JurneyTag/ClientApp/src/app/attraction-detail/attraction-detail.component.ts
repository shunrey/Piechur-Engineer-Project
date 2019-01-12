import { AttractionService } from './../attraction.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

declare let L;
declare let tomtom: any;
@Component({
  selector: 'app-attraction-detail',
  templateUrl: './attraction-detail.component.html',
  styleUrls: ['./attraction-detail.component.css']
})
export class AttractionDetailComponent implements OnInit {

  mainImage : any;
  map:any;
  marker: any;

  constructor(@Inject(MAT_DIALOG_DATA) private attraction : any, private attractionService : AttractionService){}
  
  ngOnInit(){
    this.attractionService.getMainPhoto(this.attraction.id)
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
    center: [ this.attraction.location.mapPositionLatitude, this.attraction.location.mapPositionLongitude ],
    zoom: 10,
    source : 'vector'
  });
  this.marker = tomtom.L.marker([this.attraction.location.mapPositionLatitude, this.attraction.location.mapPositionLongitude]).addTo(this.map);
}}