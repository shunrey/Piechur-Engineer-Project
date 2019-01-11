import { Address } from "./Address";
import { MapLocation } from "./Location";

export interface Attraction {
    name : string,
    description : string,
    seasonOpen : string,
    ticketPrice : number,
    halfTicketPrice : number,
    address : Address,
    location : MapLocation
}