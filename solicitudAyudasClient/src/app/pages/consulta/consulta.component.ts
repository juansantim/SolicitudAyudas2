import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { ConsultaService } from './consulta.service';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent implements OnInit {  
  itemsPerPage:number = 10;
  page:number = 1;
  totalItems:number;
  data = [];

  constructor(private consultaService: ConsultaService,
     private dataService: DataService) { }

  ngOnInit() {
    this.consultaService.aplicarFiltroEvent.subscribe(filtro => {      
      
      filtro.ItemsPerPage = this.itemsPerPage;
      filtro.Page = this.page;
      
      this.dataService.ConsultaSolicitudes(filtro).subscribe(data => {        
        this.totalItems= data.totalItems;
        this.data = data.data;
        //console.log(data);
      });
    });

  }

}
