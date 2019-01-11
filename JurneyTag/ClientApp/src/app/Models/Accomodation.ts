import { Address } from "./Address";
import { Alimentation } from "./Alimentation";
import { MapLocation } from "./Location";
import { Room } from "./Room";

export interface Accomodation {
    id : number;
    name : string;
    description : string;
    address : Address;
    location : MapLocation;
    type : string;
    standard : string;
    alimentations : Alimentation[];
    rooms : Room[];
    mainImage : any;
}