import { AccomodationService } from './../accomodation.service';
import { City } from './../Models/City';
import { Address } from './../Models/Address';
import { Accomodation } from './../Models/Accomodation';
import { AccomodationAlimentationComponent } from './../accomodation-alimentation/accomodation-alimentation.component';
import { AccomodationRoomComponent } from './../accomodation-room/accomodation-room.component';
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog, MatTableDataSource, MatDialogClose, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
declare let L;
declare let tomtom: any;

@Component({
  selector: 'accomodation-new',
  templateUrl: './accomodation-new.component.html',
  styleUrls: ['./accomodation-new.component.css']
})
export class AccomodationNewComponent implements OnInit {

  constructor(private httpClient : HttpClient, private dialog:MatDialog,
              private accomodationService : AccomodationService,
              private alDialog : MatDialog, 
              private router : Router,
              private matSnackBar: MatSnackBar,
              private changeDetectorRefs: ChangeDetectorRef) { }
  accomodationTypes : string[] = [ "Hotel", "Hostel", "Nocleg", "Domek"]
  accomodationStandards : string[] = [ "Niski", "Średni", "Wysoki", "Bardzo wysoki"]

  displayedColumnsRooms: string[] = ['Standard', 'Rodzaj', 'Ilość', 'Cena od osoby' , 'Usuń'];
  displayedColumnsAlimentation: string[] = ['Rodzaj', 'W cenie pokoju', 'Dodatkowa cena', 'Usuń'];

  rooms : any[] = [];
  aliementations : any[] = [];

  dataSourceRooms = new MatTableDataSource(this.rooms);
  dataSourceAlimentations = new MatTableDataSource(this.aliementations);
  

  map:any;
  marker: any;
  woj: string;
  response : any;
  latitude: number = 50.05481;
  longitude : number = 19.92784;

  
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
  }
 
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

  getCoordinates(){
    this.httpClient.get("https://api.tomtom.com/search/2/geocode/" +this.accomodation.address.city + " " +
                                                                    this.accomodation.address.street + " " +
                                                                    this.accomodation.address.build + ".json?countrySet=Pl&key=8oXUWjwdr1KtlIlQyrBsTXyAd1wqfDcI")
                   .subscribe( (resp) => {
                     this.response = resp;
                     console.log(this.response.results)
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

addRoom(){
    const dialogRef = this.dialog.open(AccomodationRoomComponent, {
      autoFocus: true,
      restoreFocus: true,
      height: '300px',      
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
      this.rooms.push(result);
      this.dataSourceRooms.data = this.rooms;
      //this.changeDetectorRefs.detectChanges();
      console.log(this.rooms);
    }); 
}

removeRoom(room){
  console.log(room);
  let index = this.rooms.indexOf(room);
  this.rooms.splice(index, 1);
  console.log(this.rooms);
  this.dataSourceRooms.data = this.rooms;
}

addAlimentation(){
  const dialogRef = this.alDialog.open(AccomodationAlimentationComponent, {
    autoFocus: true,
    restoreFocus: true,
    height: '300px',      
  });

  dialogRef.afterClosed().subscribe(result => {
    console.log(`Dialog result: ${result}`);
    this.aliementations.push(result);
    this.dataSourceAlimentations.data = this.aliementations;
    //this.changeDetectorRefs.detectChanges();
    console.log("Alimentations:" + this.aliementations);
  }); 
}

removeAlimentation(alimentation){
  console.log(alimentation);
  let index = this.aliementations.indexOf(alimentation);
  this.aliementations.splice(index, 1);
  console.log(this.aliementations);
  this.dataSourceRooms.data = this.aliementations;
}

submit(){
  this.accomodation.location.mapPositionLatitude = this.latitude;
  this.accomodation.location.mapPositionLongitude = this.longitude;
  this.rooms.forEach(room => {
     this.accomodation.rooms.push({
       number : room.number,
       standard: room.standard,
       type : room.type,
       price : room.price
     });
  });
  this.aliementations.forEach(alm => {
     this.accomodation.alimentations.push({
       type : alm.type,
       isInOffert : alm.isInOffert,
       addPrice : alm.addPrice
     });
  });

  this.accomodationService.addAccomodation(this.accomodation).subscribe(response => {
    this.matSnackBar.open("Dodano nowe zakwaterowanie do katalogu", "Zamknij", {
      duration: 2000,
    });
    console.log(response);
    this.router.navigate(['/listAccd']);
  });

 
}
}
