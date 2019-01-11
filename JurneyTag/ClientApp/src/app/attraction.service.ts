import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Attraction } from './Models/Attraction';

@Injectable({
  providedIn: 'root'
})
export class AttractionService {

  constructor(private httpClient : HttpClient) { }

  addAttraction(attraction : Attraction){
    return this.httpClient.post('',attraction);
  }
}
