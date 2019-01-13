import { AttractionDate } from './AttractionDate';

export interface Offert {
    id : number;
    name : string;
    dateStart : Date;
    dateEnd : Date;
    description : string;
    accomodationId : number;
    cityId : number;
    attractionsDates : AttractionDate[];
    minPrice : number;
    maxPrice : number;
    offertType : string;
    maxPlaces : number;
}