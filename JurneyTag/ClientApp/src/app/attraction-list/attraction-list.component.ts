import { Attraction } from './../Models/Attraction';
import { AttractionService } from './../attraction.service';
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { MatSnackBar, MatDialog } from '@angular/material';
import { AttractionDetailComponent } from '../attraction-detail/attraction-detail.component';

@Component({
  selector: 'app-attraction-list',
  templateUrl: './attraction-list.component.html',
  styleUrls: ['./attraction-list.component.css']
})
export class AttractionListComponent implements OnInit {

  constructor(private attractionService: AttractionService, private snackBar: MatSnackBar, 
              private cdr: ChangeDetectorRef,
              private dialog: MatDialog, private confirmDialog: MatDialog) { }

attractions: any;
attractionsList: Attraction[] = [];

ngOnInit() {
this.attractionService.getAllAttractions()
                      .subscribe(result => {
                        console.log(result);
                        this.attractions = result;
                        this.attractions.forEach(attr => {
                                    this.addAccdToList(attr);
                        });
                        this.attractionsList.forEach(attr => {
                        this.attractionService.getMainPhoto(attr.id)
                                      .subscribe(res => {
                        this.createImageFromBlob(res, attr.id)
                              });
                          });
                      });
}

createImageFromBlob(image: Blob, accId: any) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
    this.attractionsList.find(x => x.id == accId).mainImage = reader.result;
                               }, false);

      if (image) {
          reader.readAsDataURL(image);
        }
}

openDialog(attr) {

    const dialogRef = this.dialog.open(AttractionDetailComponent, {
    data: attr,
    autoFocus: false
});

    dialogRef.afterClosed().subscribe(result => {
    console.log(`Dialog result: ${result}`);
});
}


addAccdToList(attrResult) {

  this.attractionsList.push({
    id: attrResult.id,
    name: attrResult.name,
    description: attrResult.description,
    location: {
      mapPositionLatitude: attrResult.location.mapPositionLatitude,
      mapPositionLongitude: attrResult.location.mapPositionLongitude,
    },
    address: {
      city : attrResult.address.city,
      street : attrResult.address.street,
      build : attrResult.address.build,
    },
      seasonOpen : attrResult.seasonOpen,
      ticketPrice : attrResult.ticketPrice,
      halfTicketPrice : attrResult.halfTicketPrice,
      mainImage: undefined
});
// console.log(this.imageToShow);
console.log(this.attractionsList);
}

removeCity(id) {
  this.attractionService.getMainPhoto(id).subscribe(resp => {
  this.snackBar.open("Usunięto miejscowość", "Zamknij", {
    duration: 2000,
});

})
this.cdr.detectChanges();
}
}