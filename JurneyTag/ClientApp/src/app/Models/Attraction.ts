import { Address } from "./Address";
import { MapLocation } from "./Location";

export interface Attraction {
    id : number,
    name : string,
    description : string,
    seasonOpen : string,
    ticketPrice : number,
    halfTicketPrice : number,
    address : Address,
    location : MapLocation,
    _dynamicDateAttraction : Date,
    mainImage : any;
}