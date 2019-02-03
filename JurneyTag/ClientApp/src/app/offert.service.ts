import { ClientInfo } from './Models/ClientInfo';
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
  private urlGetMainPhoto : string = "https://localhost:5001/api/photo/getOffertPhoto";
  private urlPublishOffert : string = "https://localhost:5001/api/offert/publishOffert";
  private urlAddClient : string = "https://localhost:5001/api/offert/addClient";
  private urlGetClients : string = "https://localhost:5001/api/offert/getClients";
  private urlCheckClient : string = "https://localhost:5001/api/offert/checkClient";

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

  getMainPhoto(offertId : number){
    return this.httpClient.get(this.urlGetMainPhoto + '?id=' + offertId +'&sufix=Main',{
      responseType: 'blob'
    });
 }

 publishOffert(id : number){
    return this.httpClient.post(this.urlPublishOffert, id);
 }

 addClient(clientInfo : ClientInfo){
   return this.httpClient.post(this.urlAddClient, clientInfo);
 }

 getClients(offertId : number){
   return this.httpClient.get(this.urlGetClients + "/" + offertId);
 }

 checkClient(clientInfo : ClientInfo){
   return this.httpClient.post(this.urlCheckClient, clientInfo);
 }
}
