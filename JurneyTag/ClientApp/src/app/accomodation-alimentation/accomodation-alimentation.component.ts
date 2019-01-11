import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-accomodation-alimentation',
  templateUrl: './accomodation-alimentation.component.html',
  styleUrls: ['./accomodation-alimentation.component.css']
})
export class AccomodationAlimentationComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<AccomodationAlimentationComponent>,@Inject(MAT_DIALOG_DATA) private city : any) { }

  alimentation : any = {
    type: '',
    isInOffert: '',
    addPrice: 0,
  }

  aliemntationTypes : string[] = ['Śniadanie', 'Obiad', 'Kolacja', 'Obiadokoloacja'];
  alimentationInOffert : string[] = ['Tak', 'Nie'];

  ngOnInit() {
  }

  submit(){
    console.log(this.alimentation);
    this.dialogRef.close(this.alimentation);
  }
}
