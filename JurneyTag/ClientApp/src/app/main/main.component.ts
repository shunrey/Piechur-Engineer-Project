import { Component, OnInit } from '@angular/core';
import { OffertService } from '../offert.service';
import { Offert } from '../Models/Offert';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

 
  constructor(private offertService : OffertService) { }

   offerts: any;
   offertsList: Offert[] = [];

    ngOnInit() {
    
      this.offertService.getAllOfferts()
                        .subscribe(result => {
                           this.offerts = result;
                           console.log(this.offerts);
                           this.offerts.forEach(offert => {
                             if(offert.isPublished)
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

}
