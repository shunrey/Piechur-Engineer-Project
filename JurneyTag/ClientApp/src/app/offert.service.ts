import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Offert } from './Models/Offert';

@Injectable({
  providedIn: 'root'
})
export class OffertService {
  
  private urlAddOffert : string = "https://localhost:5001/api/offert/addOffert";
  private urlGetOffert : string = "https://localhost:5001/api/offert/getOffert";
  private urlGetAllOfferts : string = "https://localhost:5001/api/offert/getAll";

  constructor(private httpClient : HttpClient) { }

  addOffert(offert : Offert){
    return this.httpClient.post(this.urlAddOffert, offert);
  }

  getOffert(id : number){
    return this.httpClient.get(this.urlGetOffert + '/' + id);
  }

  getAllOfferts(){
    return this.httpClient.get(this.urlGetAllOfferts);
  }
}
