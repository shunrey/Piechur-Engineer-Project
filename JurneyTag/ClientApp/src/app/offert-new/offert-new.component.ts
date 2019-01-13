import { AttractionService } from './../attraction.service';
import { Attraction } from './../Models/Attraction';
import { AccomodationService } from './../accomodation.service';
import { Accomodation } from './../Models/Accomodation';
import { CityService } from './../city.service';
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { City } from '../Models/City';
import { DataSource } from '@angular/cdk/table';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { OffertAttractionDetailComponent } from '../offert-attraction-detail/offert-attraction-detail.component';

@Component({
  selector: 'app-offert-new',
  templateUrl: './offert-new.component.html',
  styleUrls: ['./offert-new.component.css']
})
export class OffertNewComponent implements OnInit {
 
  constructor(private cityService : CityService, private accomodationService : AccomodationService, 
              private cdr: ChangeDetectorRef, private attractionService : AttractionService,
              private dialog: MatDialog) { }

  cities : City[] = [];
  accomodations : Accomodation[] = [];
  attractions : Attraction[] = [];

  dataSourceAttractions = new MatTableDataSource();
  selectedAttractions : Attraction[] = [];

  displayedColumnsAttractions : string[] = ['Nazwa atrakcji', 'Data atrakcji','Usuń'];
 
  
  ngOnInit() {
    this.cityService.getAllCities().subscribe(res => {
      this.cities = res as City[];
      console.log(this.cities);
    });
    this.accomodationService.getAllAccomodations().subscribe(res => {
      this.accomodations = res as Accomodation[];
    });
    this.attractionService.getAllAttractions().subscribe(res=> {
      this.attractions = res as Attraction[];
    })
  }

  createImageFromBlob(image: Blob, object: any) {
        let reader = new FileReader();
        reader.addEventListener("load", () => {
        object.mainImage = reader.result;
                                        }, false);

      if (image) {
        reader.readAsDataURL(image);
        }

  }

  pickCityPhoto(){
    console.log("Event" + this.selectedCity.id);
    this.cityService.getMainPhoto(this.selectedCity.id).subscribe(res=>{
      this.createImageFromBlob(res,this.selectedCity)
    });
  }

  pickAccomodationPhoto(){
    console.log("Event" + this.selectedAccomodation.id);
    this.accomodationService.getMainPhoto(this.selectedAccomodation.id).subscribe(res=>{
      this.createImageFromBlob(res,this.selectedAccomodation)
    });
  }

  changeDet(){
    console.log(this.attrNumber);
    this.cdr.detectChanges();
    
  }


  addAttraction(){
    let dateString = this.selectedAttraction._dynamicDateAttraction.toLocaleDateString();
    console.log(dateString);
    this.selectedAttractions.push(Object.assign({},this.selectedAttraction));
    console.log(this.selectedAttractions);
    this.dataSourceAttractions.data = this.selectedAttractions;
  }

  openDialogAttraction($event,row){

    const dialogRef = this.dialog.open(OffertAttractionDetailComponent, {
      data: row,
      autoFocus: false,
      width: '600px',
      height: '500px'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
    console.log(row);
  }


  selectedCity : City ={
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

  selectedAccomodation : Accomodation = {
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

  selectedAttraction : Attraction = {
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
  
   
    

  attrNumber : number;
}
