import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'accomodation-room',
  templateUrl: './accomodation-room.component.html',
  styleUrls: ['./accomodation-room.component.css']
})
export class AccomodationRoomComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<AccomodationRoomComponent>,@Inject(MAT_DIALOG_DATA) private city : any) { }

  room : any = {
    number: 0,
    standard: '',
    type: '',
    price: 0
  }
   
  roomStandards : string[] = ['Normalny', 'Apartament']
  roomTypes : string[] = ['Jednoosobowy','Dwuosobowy','Trzyosobowy','Czterosobowy','Pięcioosobowy','Więcej']
  ngOnInit() {
  }

  submit(){
    console.log(this.room);
    this.dialogRef.close(this.room);
  }

}
