import { City } from './Models/City';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseContentType } from '@angular/http';


@Injectable({
  providedIn: 'root'
})
export class CityService {
  
  private urlCityAdd : string = "https://localhost:5001/api/city/add";
  private urlCityGetAll : string = "https://localhost:5001/api/city/getAll";
  private urlGetMainPhoto : string = "https://localhost:5001/api/photo/get"

  constructor(private httpClient: HttpClient) {}

  addCity(city:City){
      console.log(JSON.stringify(city));
      this.httpClient.post(this.urlCityAdd, city)
                     .subscribe(resp => console.log(resp));
  }

  getAllCities(){
    return this.httpClient.get(this.urlCityGetAll);
  }

  getMainPhoto(cityName:string){
     return this.httpClient.get(this.urlGetMainPhoto + '?id=' + cityName +'&sufix=Main',{
       responseType: 'blob'
     });
  }
}
