import { Component, OnInit } from '@angular/core';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { SolicitudAyuda } from 'src/app/model/SolicitudAyuda';
import { DataService } from 'src/app/services/data.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-registro-solicitud',
  templateUrl: './registro-solicitud.component.html',
  styleUrls: ['./registro-solicitud.component.css']
})
export class RegistroSolicitudComponent implements OnInit {

  constructor(private dataService: DataService) {

  }

  Solicitud: SolicitudAyuda;

  seccionales: Array<any>;
  selectedSeccional: any;
  cargandoSeccionales: boolean;

  isLoading() {
    return this.cargandoSeccionales;
  }

  typeaheadOnSelect(e: TypeaheadMatch): void {
    this.selectedSeccional = e.item;
  }

  ngOnInit() {
    this.cargandoSeccionales = true;
    this.Solicitud = new SolicitudAyuda();

    // this.dataService.GetSeccionales().subscribe(data => {
    //   this.seccionales = data;
    //   this.cargandoSeccionales = false;
    // }, err => {
    //   this.cargandoSeccionales = false;
    // })

    this.cargandoSeccionales = false;
    this.seccionales = [
      {nombre: "Municipio Azua"},
      {nombre: "Municipio Guayabal"},
      {nombre: "Municipio Las Yayas"},
      {nombre: "Municipio Padre las casas"}
    ]

  }


  removerSeccional() {
    this.selectedSeccional = null;
    this.selected = null;
  }

  selected: any;

  esJubiladoInabima(){
    return  this.Solicitud.esjubiladoinabima === 'true';
  }

  registrarSolicitud(){
    Swal.fire({
      title:'Aviso', 
      text:'Solicitud de ayuda Nro# 2134 registrara satisfactoriamente', 
      icon:'info',
      showConfirmButton:true,
      showCloseButton: true,
      showCancelButton: true,
      confirmButtonText:'Imprimir',
    })
  }

  AgregarAdjunto(){
    this.Solicitud.adjuntos.push({});
  }
}

//Mask plugin documentation
//https://www.npmjs.com/package/ngx-mask