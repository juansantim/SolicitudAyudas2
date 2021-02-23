import { Component, OnInit } from '@angular/core';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { esDoLocale } from 'ngx-bootstrap/locale';
import { DataService } from 'src/app/services/data.service';

defineLocale('es-do', esDoLocale);

@Component({
  selector: 'app-resumen-solicitado-por-sucursal',
  templateUrl: './resumen-solicitado-por-sucursal.component.html',
  styleUrls: ['./resumen-solicitado-por-sucursal.component.css']
})
export class ResumenSolicitadoPorSucursalComponent implements OnInit {

  desde:Date;
  hasta:Date;

  constructor(private dataService:DataService) { }

  ngOnInit() {
  }

  toDay(){
    return new Date();
  }

  generar(){
    this.dataService.ResumenSolicitudesPorSucursal(this.desde, this.hasta);
  }
}
