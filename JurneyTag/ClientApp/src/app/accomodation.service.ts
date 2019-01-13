import { Accomodation } from './Models/Accomodation';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccomodationService {

  private urlAccomodationAdd : string = "https://localhost:5001/api/accomodation/add";
  private urlAccomodationGetAll : string = 'https://localhost:5001/api/accomodation/getAll';
  private urlAccomodationGet : string = 'https://localhost:5001/api/accomodation/getAccomodation';
  private urlGetMainPhoto : string = "https://localhost:5001/api/photo/getAccdPhoto"

  constructor(private httpClient : HttpClient) { }

  addAccomodation(accomodation : Accomodation){
       return this.httpClient.post(this.urlAccomodationAdd, accomodation);
  }

  getAllAccomodations(){
    return this.httpClient.get(this.urlAccomodationGetAll);
  }

  getAccomodation(id : number){
    return this.httpClient.get(this.urlAccomodationGet + '/' + id);
  }

  getMainPhoto(accId:number){
    return this.httpClient.get(this.urlGetMainPhoto + '?id=' + accId +'&sufix=AccdMain',{
      responseType: 'blob'
    });
 }

}
