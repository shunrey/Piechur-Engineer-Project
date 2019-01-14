import { Component, OnInit } from '@angular/core';
import { OffertService } from '../offert.service';
import { Offert } from '../Models/Offert';

@Component({
  selector: 'app-offert-list',
  templateUrl: './offert-list.component.html',
  styleUrls: ['./offert-list.component.css']
})
export class OffertListComponent implements OnInit {

  constructor(private offertService : OffertService) { }

   offerts: any;
   offertsList: Offert[] = [];

    ngOnInit() {
    
      this.offertService.getAllOfferts()
                        .subscribe(result => {
                           this.offerts = result;
                           console.log(this.offerts);
                           this.offerts.forEach(offert => {
                             this.offertsList.push(Object.assign({},offert));
                           });
                        });
  }


 createImageFromBlob(image: Blob, cityId: any) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
    //this.offertsList.find(x => x.id == cityId).mainImage = reader.result;
    }, false);

     if (image) {
       reader.readAsDataURL(image);
   }
 }

}
