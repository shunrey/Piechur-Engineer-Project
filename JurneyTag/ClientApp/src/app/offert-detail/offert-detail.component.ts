import { AttractionService } from './../attraction.service';
import { AccomodationService } from './../accomodation.service';
import { CityService } from './../city.service';
import { Component, OnInit } from '@angular/core';
import { OffertService } from '../offert.service';
import { City } from '../Models/City';
import { Accomodation } from '../Models/Accomodation';
import { Attraction } from '../Models/Attraction';
import { Offert } from '../Models/Offert';

@Component({
  selector: 'app-offert-detail',
  templateUrl: './offert-detail.component.html',
  styleUrls: ['./offert-detail.component.css']
})
export class OffertDetailComponent implements OnInit {

  constructor(private offertService:OffertService, private cityService:CityService,
              private accomodationService:AccomodationService, private attractionService : AttractionService) { }
   

  ngOnInit() {
    this.offertService.getOffert(1).subscribe(resp =>{
      this.offert = resp as Offert;
     
      this.cityService.getCity(this.offert.cityId).subscribe(resp => {
        this.city = resp as City;
        console.log(this.city);
      });
      this.accomodationService.getAccomodation(this.offert.accomodationId).subscribe(resp => {
        this.accomodation = resp as Accomodation;
        console.log(this.accomodation);
      });
      this.offert.attractionsDates.forEach(a => {
        this.attractionService.getAttraction(a.attractionId).subscribe(resp => {
          this.attraction = resp as Attraction;
          this.attraction._dynamicDateAttraction = a.attractionDate;
          this.attractions.push(Object.assign({},this.attraction));
        });
      });    
    console.log(this.offert); 
    console.log(this.attractions);
    });
   
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









}
