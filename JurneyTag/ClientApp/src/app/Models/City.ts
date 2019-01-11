import { MapLocation } from "./Location";

export interface City {
    id : number;
    name : string;
    description : string;
    metersAboveSeaLevel : number;
    population : number;
    area : number;
    populationDensity: number;
    location : MapLocation;
    mainImage : any;
}