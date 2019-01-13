import { City } from './Models/City';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseContentType } from '@angular/http';


@Injectable({
  providedIn: 'root'
})
export class CityService {
  
  private urlCityAdd : string = "https://localhost:5001/api/city/add";
  private urlCityRemove : string = "https://localhost:5001/api/city/delete"
  private urlCityGetAll : string = "https://localhost:5001/api/city/getAll";
  private urlCityGet : string = "https://localhost:5001/api/city/getCity";
  private urlGetMainPhoto : string = "https://localhost:5001/api/photo/getCityPhoto"

  constructor(private httpClient: HttpClient) {}

  addCity(city:City){
      console.log(JSON.stringify(city));
     return this.httpClient.post(this.urlCityAdd, city);
                     
  }

  getCity(id : number){
    return this.httpClient.get(this.urlCityGet + '/' + id);
  }

  getAllCities(){
    return this.httpClient.get(this.urlCityGetAll);
  }

  getMainPhoto(cityId:number){
     return this.httpClient.get(this.urlGetMainPhoto + '?id=' + cityId +'&sufix=Main',{
       responseType: 'blob'
     });
  }

  removeCity(id : number){
    console.log(id);
    console.log(this.urlCityRemove + '/' + id);
      return this.httpClient.delete(this.urlCityRemove + '/' + id);
      
  }
}
