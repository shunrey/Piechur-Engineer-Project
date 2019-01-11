import { Accomodation } from './Models/Accomodation';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccomodationService {

  private urlAccomodationAdd : string = '';
  private urlAccomodationGetAll : string = '';

  constructor(private httpClient : HttpClient) { }

  addAccomodation(accomodation : Accomodation){
       return this.httpClient.post(this.urlAccomodationAdd, accomodation);
  }

  getAllAccomodations(){
    return this.httpClient.get(this.urlAccomodationGetAll);
  }
  
}
