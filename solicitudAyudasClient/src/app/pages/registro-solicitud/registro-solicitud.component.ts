import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
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

  //form controls:
  solicitudAyudaForm = new FormGroup({
    cedula: new FormControl(''),
    seccional: new FormControl(''),
    tipoDeAyuda: new FormControl(''),
    nombreCompleto: new FormControl(''),
    fechaNacimiento: new FormControl(''),
    quienRecibeAyuda: new FormControl(''),
    telefonoCelular: new FormControl(''),
    telefonoResidencia: new FormControl(''),
    telefonoLaboral: new FormControl(''),
    email: new FormControl(''),
    sexo: new FormControl(''),
    direccion: new FormControl(''),
    montoAyuda: new FormControl(''),
  });



  //end of form controls
  constructor(private dataService: DataService, private fb: FormBuilder) {
    //this.fb
  }

  Solicitud: SolicitudAyuda;

  seccionales: Array<any>;
  selectedSeccional: any;
  cargandoSeccionales: boolean;
  tiposSolicitudes: Array<any>;
  TipoDeAyuda: any;
  RequisitosSolicitud: Array<any>;

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

    this.dataService.GetTiposSolicitudesConRequisitos().subscribe(data => {
      this.tiposSolicitudes = data;
    }, err => {
      console.log(err);
    })

    this.cargandoSeccionales = false;
    this.seccionales = [
      { nombre: "Municipio Azua" },
      { nombre: "Municipio Guayabal" },
      { nombre: "Municipio Las Yayas" },
      { nombre: "Municipio Padre las casas" }
    ]

  }


  removerSeccional() {
    this.selectedSeccional = null;
    this.selected = null;
  }

  selected: any;

  esJubiladoInabima() {
    return this.Solicitud.esjubiladoinabima === 'true';
  }

  registrarSolicitud() {
    Swal.fire({
      title: 'Aviso',
      text: 'Solicitud de ayuda Nro# 2134 registrara satisfactoriamente',
      icon: 'info',
      showConfirmButton: true,
      showCloseButton: true,
      showCancelButton: true,
      confirmButtonText: 'Imprimir',
    })
  }

  AgregarAdjunto() {
    this.Solicitud.adjuntos.push({});
  }

  onChangeTipoSolicitud(tipoSolicitud) {
    var tipoSolictud = this.tiposSolicitudes.filter(tipo => tipo.id == tipoSolicitud)[0]
    console.log(tipoSolictud);

    let keys = [];

    Object.keys(this.solicitudAyudaForm.controls).forEach(key => {
      keys.push(key);
    });

    keys.filter((k) => {
      k.startsWith("rd")
    }).forEach(key => {
      this.solicitudAyudaForm.removeControl(key);
    })

    if (tipoSolictud.requisitos.length > 0) {
      tipoSolictud.requisitos.forEach(element => {
        this.solicitudAyudaForm.addControl(element.formName, new FormControl())
      });

    }
    console.log(this.solicitudAyudaForm.controls);
    this.RequisitosSolicitud = tipoSolictud.requisitos;    
  }

  GetErrors(fieldName, errorName){
    var control = this.solicitudAyudaForm.get(fieldName);

    if(control.pristine || !control.errors){
      return false;
    }
    else{
      return control.errors[errorName];
    }

  }

  onSubmit(){
    console.log('form submitted')
  }

}

//Mask plugin documentation
//https://www.npmjs.com/package/ngx-mask