import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-client-confirm',
  templateUrl: './client-confirm.component.html',
  styleUrls: ['./client-confirm.component.css']
})
export class ClientConfirmComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ClientConfirmComponent>) { }

  ngOnInit() {
  }

  Ok(){
    this.dialogRef.close();
  }

}
