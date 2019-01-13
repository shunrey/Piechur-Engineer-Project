import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-offert-attraction-detail',
  templateUrl: './offert-attraction-detail.component.html',
  styleUrls: ['./offert-attraction-detail.component.css']
})
export class OffertAttractionDetailComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) private attraction : any) { }

  ngOnInit() {
  }

}
