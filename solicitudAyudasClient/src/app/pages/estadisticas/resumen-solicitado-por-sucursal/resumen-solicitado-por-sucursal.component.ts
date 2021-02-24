import { Component, OnInit } from '@angular/core';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { esDoLocale } from 'ngx-bootstrap/locale';
defineLocale('es-do', esDoLocale);

import { DataService } from 'src/app/services/data.service';


@Component({
  selector: 'app-resumen-solicitado-por-sucursal',
  templateUrl: './resumen-solicitado-por-sucursal.component.html',
  styleUrls: ['./resumen-solicitado-por-sucursal.component.css']
})
export class ResumenSolicitadoPorSucursalComponent implements OnInit {

  desde:Date;
  hasta:Date;
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

  timeChange(event){
    console.log(event);
  }

  generar(){
    this.dataService.ResumenSolicitudesPorSucursal(this.desde, this.hasta);
  }
}
