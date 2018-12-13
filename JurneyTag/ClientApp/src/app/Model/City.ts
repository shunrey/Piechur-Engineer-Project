import { MapLocation } from "./Location";

export interface City {
    id : number;
    name : string;
    description : string;
    location : MapLocation;
}