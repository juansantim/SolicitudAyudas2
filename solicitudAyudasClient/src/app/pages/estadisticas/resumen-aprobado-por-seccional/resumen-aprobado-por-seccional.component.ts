import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { esDoLocale } from 'ngx-bootstrap/locale';
defineLocale('es-do', esDoLocale);

@Component({
  selector: 'app-resumen-aprobado-por-seccional',
  templateUrl: './resumen-aprobado-por-seccional.component.html',
  styleUrls: ['./resumen-aprobado-por-seccional.component.css']
})
export class ResumenAprobadoPorSeccionalComponent implements OnInit {


  desde:Date;
  hasta:Date;
  seccionalId: number;
  cargando: boolean;

  constructor(private dataService:DataService) { }

  ngOnInit() {
    this.dataService.cargandoReporte.subscribe(value => {
      this.cargando = value;
    })
  }

  toDay(){
    return new Date();
  }

  generar(){
    this.dataService.ResumenSolicitudesAprobadoPorSucursal(this.desde, this.hasta, this.seccionalId);
  }

  SetSeccional(event){
    this.seccionalId = event;
  }

  ClearSeccional(){
    this.seccionalId = null;
  }
}
