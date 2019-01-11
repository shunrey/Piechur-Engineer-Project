import { Photo } from './../Models/Photo';
import { CityService } from './../city.service';
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { CityDetailComponent } from '../city-detail/city-detail.component';
import { City } from '../Models/City';

@Component({
  selector: 'city-list',
  templateUrl: './city-list.component.html',
  styleUrls: ['./city-list.component.css']
})
export class CityListComponent implements OnInit {

  constructor(private cityService: CityService, private snackBar: MatSnackBar, 
              private cdr: ChangeDetectorRef,
              private dialog: MatDialog, private confirmDialog: MatDialog) { }

  cities: any;
  citiesList: City[] = [];

  ngOnInit() {
    this.cityService.getAllCities()
      .subscribe(result => {
        console.log(result);
        this.cities = result;
        this.cities.forEach(city => {
          this.addCityToList(city);
        });
        this.citiesList.forEach(city => {
          this.cityService.getMainPhoto(city.id)
            .subscribe(res => {
              this.createImageFromBlob(res, city.id)
            });
        });
      });
  }

  createImageFromBlob(image: Blob, cityId: any) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
      this.citiesList.find(x => x.id == cityId).mainImage = reader.result;
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


  addCityToList(cityResult) {

    this.citiesList.push({
      id: cityResult.id,
      name: cityResult.name,
      description: cityResult.description,
      population: cityResult.metersAboveSeaLevel,
      area: cityResult.population,
      metersAboveSeaLevel: cityResult.area,
      populationDensity: cityResult.populationDensity,
      location: {
        mapPositionLatitude: cityResult.location.mapPositionLatitude,
        mapPositionLongitude: cityResult.location.mapPositionLongitude,
      },
      mainImage: undefined
    });
    // console.log(this.imageToShow);
    console.log(this.citiesList);
  }

  removeCity(id) {
    this.cityService.removeCity(id).subscribe(resp => {
      this.snackBar.open("Usunięto miejscowość", "Zamknij", {
        duration: 2000,
      });
     
    })
    this.cdr.detectChanges();
}
}


