import { ClientInfo } from './../Models/ClientInfo';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { DataSource } from '@angular/cdk/table';
import { MatTableDataSource, MatSnackBar } from '@angular/material';
import { OffertService } from '../offert.service';

@Component({
  selector: 'app-clients-list',
  templateUrl: './clients-list.component.html',
  styleUrls: ['./clients-list.component.css']
})
export class ClientsListComponent implements OnInit {

  displayedColumnsClients : string[] = ['Imię', 'Nazwisko', 'Telefon', 'Email','Zaakceptuj','Usuń'];
  displayedColumnsAccClients : string[] = ['Imię', 'Nazwisko', 'Telefon', 'Email', 'Informacje'];
  displayedColumnsRejClients : string[] = ['Imię', 'Nazwisko', 'Telefon', 'Email'];

  client : any = {
    name : 'Jan',
    surname : 'Korek',
    phone : '345567655',
    email : 'korek@gmail.com'
  };

  clients : any;
  clientsAllList : ClientInfo[] = [];
  clientsAcceptedList : ClientInfo[] = [];
  clientsRejectedList : ClientInfo[] = [];
  offertId : number;
  dataSourceAllClients = new MatTableDataSource();
  dataSourceAcceptedClients = new MatTableDataSource();
  dataSourceRejectedClients = new MatTableDataSource();

  constructor(private route: ActivatedRoute, private offertService : OffertService, private snackBar: MatSnackBar) 
  {
      route.params.subscribe(p => {
        this.offertId= +p['id'];
       // this.offertName = p['name'];
      });
  }

  ngOnInit() {
    this.offertService.getClients(this.offertId).subscribe(resp => {
      console.log(resp);
       this.clientsAllList = resp as ClientInfo[];
       this.assignData(resp);
       });
    }

    assignData(resp){
      this.clientsAllList = (resp as ClientInfo[]).filter(c => c.isAccepted == false)
                                                  .filter(c => c.isRejected == false); 
      this.clientsAcceptedList = (resp as ClientInfo[]).filter(c => c.isAccepted == true);
      this.clientsRejectedList = (resp as ClientInfo[]).filter(c => c.isRejected == true);

      this.dataSourceAllClients.data = this.clientsAllList;
      this.dataSourceAcceptedClients.data = this.clientsAcceptedList;
      this.dataSourceRejectedClients.data = this.clientsRejectedList;
    }

    reinitialiseData(){
      this.dataSourceAllClients.data = this.clientsAllList;
      this.dataSourceAcceptedClients.data = this.clientsAcceptedList;
      this.dataSourceRejectedClients.data = this.clientsRejectedList;
    }

    acceptClient(client){
      let cli = this.clientsAllList.find(c => c.id == client.id);
      cli.isAccepted = true;
  
      this.offertService.checkClient(cli).subscribe(resp => {
      });

      let index = this.clientsAllList.indexOf(cli);
      this.clientsAllList.splice(index,1);
      this.clientsAcceptedList.push(cli);

      this.reinitialiseData();
      this.snackBar.open("Zaakceptowano klienta. Wysłano potwierdzenie wiadomością Email", "Zamknij", {
        duration: 2000,
      });

      console.log(cli);
    }

     rejectClient(client){
      let cli = this.clientsAllList.find(c => c.id == client.id);
      cli.isRejected = true;

  

      this.offertService.checkClient(cli).subscribe(resp => {
      });

      let index = this.clientsAllList.indexOf(cli);
      this.clientsAllList.splice(index,1);
      this.clientsRejectedList.push(cli);

      this.reinitialiseData();
      this.snackBar.open("Odrzucono klienta. Wysłano potwierdzenie wiadomością Email", "Zamknij", {
        duration: 2000,
      });

      console.log(cli);

      console.log(cli);
    }
    
  }


