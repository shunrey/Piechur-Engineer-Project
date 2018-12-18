import { CityService } from './../city.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { CityDetailComponent } from '../city-detail/city-detail.component';

@Component({
  selector: 'city-list',
  templateUrl: './city-list.component.html',
  styleUrls: ['./city-list.component.css']
})
export class CityListComponent implements OnInit {

  constructor(private cityService:CityService, private dialog : MatDialog) { }

  cities : any;
  imageToShow : any;

  ngOnInit() {
    this.cityService.getAllCities()
                    .subscribe(result => {
                      console.log(result);
                      this.cities = result;

                      this.cities.forEach(city => {      
                        this.cityService.getMainPhoto(city.id)
                                           .subscribe(result => {
                                              console.log(result)
                                              this.createImageFromBlob(result)
                                           });  
                    });
    
    });
  }

  createImageFromBlob(image: Blob) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
       this.imageToShow = reader.result;
    }, false);
 
    if (image) {
       reader.readAsDataURL(image);
    }
}

openDialog(city) {
   
  const dialogRef = this.dialog.open(CityDetailComponent, {
    data: city,
    autoFocus: false
  });

  dialogRef.afterClosed().subscribe(result => {
    console.log(`Dialog result: ${result}`);
  });
}

}