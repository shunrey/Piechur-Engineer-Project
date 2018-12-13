import { City } from './Model/City';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  
  private url : string = "https://localhost:5001/api/city/add";

  constructor(private httpClient: HttpClient) {}

  addCity(city:City){
      console.log(JSON.stringify(city));
      this.httpClient.post(this.url, city)
                     .subscribe(resp => console.log(resp));
  }
}
