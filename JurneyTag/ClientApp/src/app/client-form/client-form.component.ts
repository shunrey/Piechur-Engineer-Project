import { ClientConfirmComponent } from './../client-confirm/client-confirm.component';
import { MatSnackBar, MatDialog } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';

import { ClientInfo } from './../Models/ClientInfo';
import { Component, OnInit } from '@angular/core';
import { OffertService } from '../offert.service';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {

  constructor(private offertService : OffertService, private route : ActivatedRoute, private router : Router,
              private snackBar : MatSnackBar, private dialog : MatDialog) {
    route.params.subscribe(p => {
      this.client.offertId= +p['id'];
      this.offertName = p['name'];
    });
   }
  
  client : ClientInfo = {
    id:undefined,
    offertId:undefined,
    isAccepted:false,
    isRejected:false,
    isRodoChecked:false,
    name: undefined,
    surname: undefined,
    phone: undefined,
    email: undefined,
    preferences: undefined
  }

  offertName : string;

  ngOnInit() {
  }

  save(){
    this.offertService.addClient(this.client).subscribe(resp => {
        const dialogRef = this.dialog.open(ClientConfirmComponent, {
          width: '450px',
        });
      this.router.navigate(['']);       
    });
  }

}
