import { AttractionService } from './../attraction.service';
import { AccomodationService } from './../accomodation.service';
import { CityService } from './../city.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { OffertService } from '../offert.service';
import { City } from '../Models/City';
import { Accomodation } from '../Models/Accomodation';
import { Attraction } from '../Models/Attraction';
import { Offert } from '../Models/Offert';
import { mapChildrenIntoArray } from '@angular/router/src/url_tree';
import { ActivatedRoute } from '@angular/router';

declare let L;
declare let tomtom: any;

@Component({
  selector: 'app-offert-detail',
  templateUrl: './offert-detail.component.html',
  styleUrls: ['./offert-detail.component.css']
})
export class OffertDetailComponent implements OnInit {

  constructor(private offertService:OffertService, private cityService:CityService,
              private accomodationService:AccomodationService, private attractionService : AttractionService,
              route : ActivatedRoute) 
              {
                route.params.subscribe(p => {
                  this.offertId= +p['id']
                })
              }
   
  cityMap : any;
  cityMapMarker : any;
  accomodationMap : any;
  accomodationMapMarker : any;
  map : any;
  offertId : number;

  ngOnInit() {
    this.offertService.getOffert(this.offertId).subscribe(resp =>{
      this.offert = resp as Offert;
      this.offert.dateEnd
      this.cityService.getCity(this.offert.cityId).subscribe(resp => {
        this.city = resp as City;
        console.log(this.city);       
      });
      this.cityService.getMainPhoto(this.offert.cityId).subscribe(resp => {
        this.createImageFromBlob(resp, this.city);
      })
      this.accomodationService.getAccomodation(this.offert.accomodationId).subscribe(resp => {
        this.accomodation = resp as Accomodation;
        console.log(this.accomodation);
      });
      this.accomodationService.getMainPhoto(this.offert.accomodationId).subscribe(resp => {
        this.createImageFromBlob(resp, this.accomodation);
      });
      this.offert.attractionsDates.forEach(a => {
        this.attractionService.getAttraction(a.attractionId).subscribe(resp => {
          this.attraction = resp as Attraction;
          this.attraction._dynamicDateAttraction = a.attractionDate;
          console.log("Attr:"+ this.attraction.mainImage);
          this.attractions.push(Object.assign({},this.attraction));
          this.attractions.forEach(at => {
            this.attractionService.getMainPhoto(at.id).subscribe(pres => {
              this.createImageFromBlob(pres, at);
             })
          })
        });
      
        
      });    
    console.log(this.offert); 
  
    });
  
  }
  

  initalizeCityMap() {
     this.cityMap = tomtom.L.map('map', {
      key: '8oXUWjwdr1KtlIlQyrBsTXyAd1wqfDcI',
      basePath: '/assets/sdk',
      center: [ this.city.location.mapPositionLatitude, this.city.location.mapPositionLongitude ],
      zoom: 10,
      source : 'vector'
    });
    this.cityMapMarker = tomtom.L.marker([this.city.location.mapPositionLatitude, this.city.location.mapPositionLongitude]).addTo(this.cityMap);
  }

  initializeAccomodationMap(){
    this.accomodationMap = tomtom.L.map('map2', {
      key: '8oXUWjwdr1KtlIlQyrBsTXyAd1wqfDcI',
      basePath: '/assets/sdk',
      center: [ this.accomodation.location.mapPositionLatitude, this.accomodation.location.mapPositionLongitude ],
      zoom: 13,
      source : 'vector'
    });
    this.accomodationMapMarker = tomtom.L.marker([this.accomodation.location.mapPositionLatitude, this.accomodation.location.mapPositionLongitude]).addTo(this.accomodationMap);
  }

  createImageFromBlob(image: Blob, object : any) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
       object.mainImage = reader.result;
    }, false);
 
    if (image) {
       reader.readAsDataURL(image);
    }
}
  
  onTabChange(event){

    if (event.index == 1)
    {
      this.initalizeCityMap();
    }
    if (event.index == 2)
    {
      this.initializeAccomodationMap();
      console.log(this.attractions);
    }
    if (event.index == 3)
    {
      this.attractions.forEach(a => {
        this.initializeAttractionMaps(a);
      });
           console.log(this.attractions);
    }
 
    console.log(event);
    
  }

  GetAttrMapId(id : number){
    console.log('mapid:'+ 'MapA' +id  )
    this.initializeAttractionMaps('MapA' + id);
    return 'MapA' + id;
  }

  initializeAttractionMaps(attraction){
    let attr = tomtom.L.map('MapA' + attraction.id, {
      key: '8oXUWjwdr1KtlIlQyrBsTXyAd1wqfDcI',
      basePath: '/assets/sdk',
      center: [ attraction.location.mapPositionLatitude, attraction.location.mapPositionLongitude ],
      zoom: 13,
      source : 'vector'
    });
    let marker = tomtom.L.marker([attraction.location.mapPositionLatitude, attraction.location.mapPositionLongitude]).addTo(attr);
  }






  city : City ={
    id: undefined,
    name: '',
    description: '',
    population: undefined,
    area: undefined,
    metersAboveSeaLevel: undefined,
    populationDensity: undefined,
    location : {
      mapPositionLatitude : undefined,
      mapPositionLongitude : undefined,
    },
    mainImage: undefined
  };

  accomodation : Accomodation = {
    id : undefined,
    name : '',
    description : '',
    standard : '',
    type: '',
    address : {
      city : '',
      street : '',
      build : '',
    },
    location : {
      mapPositionLongitude : undefined,
      mapPositionLatitude : undefined,
    },
    rooms : [] = [],
    alimentations : [] = [],
    mainImage: undefined
  };

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
      _dynamicDateAttraction : undefined
    };

    attractions : Attraction[] = [];

   offert : Offert = {
     id : undefined,
     name : '',
     dateStart : undefined,
     dateEnd : undefined,
     description : '',
     accomodationId : undefined,
     cityId : undefined,
     minPrice : undefined,
     maxPrice : undefined,
     offertType : '',
     maxPlaces : undefined,
     attractionsDates : [] = []
   };
   
   localDateEnd : string;
   localDateStart : string;








}
