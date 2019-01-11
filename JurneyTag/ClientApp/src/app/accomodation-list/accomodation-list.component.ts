import { Alimentation } from './../Models/Alimentation';
import { Address } from './../Models/Address';
import { Accomodation } from './../Models/Accomodation';
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { AccomodationService } from '../accomodation.service';
import { MatSnackBar, MatDialog } from '@angular/material';
import { AccomodationDetailComponent } from '../accomodation-detail/accomodation-detail.component';

@Component({
  selector: 'app-accomodation-list',
  templateUrl: './accomodation-list.component.html',
  styleUrls: ['./accomodation-list.component.css']
})
export class AccomodationListComponent implements OnInit {

  constructor(private accomodationService: AccomodationService, private snackBar: MatSnackBar, 
              private cdr: ChangeDetectorRef,
              private dialog: MatDialog, private confirmDialog: MatDialog) { }

 accomodations: any;
 accomodationsList: Accomodation[] = [];

ngOnInit() {
    this.accomodationService.getAllAccomodations()
                            .subscribe(result => {
                                console.log(result);
                                this.accomodations = result;
                                this.accomodations.forEach(accd => {
                                              this.addAccdToList(accd);
                                });
                                this.accomodationsList.forEach(accd => {
                                this.accomodationService.getMainPhoto(accd.id)
                                                .subscribe(res => {
                                this.createImageFromBlob(res, accd.id)
                                        });
                                    });
                                });
}

    createImageFromBlob(image: Blob, accId: any) {
        let reader = new FileReader();
        reader.addEventListener("load", () => {
        this.accomodationsList.find(x => x.id == accId).mainImage = reader.result;
                                        }, false);

      if (image) {
        reader.readAsDataURL(image);
        }
}

openDialog(accd) {

const dialogRef = this.dialog.open(AccomodationDetailComponent, {
data: accd,
autoFocus: false
});

dialogRef.afterClosed().subscribe(result => {
console.log(`Dialog result: ${result}`);
});
}


addAccdToList(accdResult) {

this.accomodationsList.push({
  id: accdResult.id,
  name: accdResult.name,
  description: accdResult.description,
  location: {
    mapPositionLatitude: accdResult.location.mapPositionLatitude,
    mapPositionLongitude: accdResult.location.mapPositionLongitude,
  },
  address: {
    city : accdResult.address.city,
    street : accdResult.address.street,
    build : accdResult.address.build,
  },
  type : accdResult.type,
  rooms: accdResult.rooms,
  alimentations : accdResult.alimentations,
  standard : accdResult.standard, 
  mainImage: undefined
});
// console.log(this.imageToShow);
console.log(this.accomodationsList);
}

removeCity(id) {
this.accomodationService.getMainPhoto(id).subscribe(resp => {
this.snackBar.open("Usunięto miejscowość", "Zamknij", {
duration: 2000,
});

})
this.cdr.detectChanges();
}

}
