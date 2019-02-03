import { MatSnackBar } from '@angular/material';
import { Component, OnInit } from '@angular/core';
import { OffertService } from '../offert.service';
import { Offert } from '../Models/Offert';

@Component({
  selector: 'app-offert-list',
  templateUrl: './offert-list.component.html',
  styleUrls: ['./offert-list.component.css']
})
export class OffertListComponent implements OnInit {

  constructor(private offertService : OffertService, private snackBar : MatSnackBar) { }

   offerts: any;
   offertsList: Offert[] = [];

    ngOnInit() { 
     this.loadData();
  }

  loadData(){
    this.offertService.getAllOfferts()
    .subscribe(result => {
       this.offerts = result;
       console.log(this.offerts);
       this.offerts.forEach(offert => {
         this.offertsList.push(Object.assign({},offert));
       });
       this.offertsList.forEach(of => {
         this.offertService.getMainPhoto(of.id).subscribe(res => {
           this.createImageFromBlob(res, of.id);
         });
       });
    });
  }


 createImageFromBlob(image: Blob, cityId: any) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
    this.offertsList.find(x => x.id == cityId).mainImage = reader.result;
    }, false);

     if (image) {
       reader.readAsDataURL(image);
   }
 }

 publish(id){
   console.log(id);
   this.offertService.publishOffert(id).subscribe(resp => {
    this.snackBar.open("Opublikowano ofertę", "Zamknij", {
      duration: 2000,
    });
     console.log("success");
    let offer = this.offertsList.find(o => o.id == id);
    offer.isPublished = true;
   })
 }

}
