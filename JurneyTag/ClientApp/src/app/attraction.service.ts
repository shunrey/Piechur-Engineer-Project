import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Attraction } from './Models/Attraction';

@Injectable({
  providedIn: 'root'
})
export class AttractionService {
  
  private urlAttractionAdd : string = "https://localhost:5001/api/attraction/add";
  private urlAttractionGetAll : string = "https://localhost:5001/api/attraction/getAll";
  private urlAttractionGet : string = "https://localhost:5001/api/attraction/getAttraction";
  private urlGetMainPhoto : string = "https://localhost:5001/api/photo/getAttractionPhoto";

  constructor(private httpClient : HttpClient) { }

  addAttraction(attraction : Attraction){
    return this.httpClient.post(this.urlAttractionAdd,attraction);
  }

  getAllAttractions(){
    return this.httpClient.get(this.urlAttractionGetAll);
  }

  getAttraction(id : number){
    return this.httpClient.get(this.urlAttractionGet + '/' + id);
  }

  getMainPhoto(attrId:number){
    return this.httpClient.get(this.urlGetMainPhoto + '?id=' + attrId +'&sufix=AttrMain',{
      responseType: 'blob'
    });
}
}
