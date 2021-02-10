import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { setTime } from 'ngx-bootstrap/chronos/utils/date-setters';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { promise } from 'protractor';
import { from } from 'rxjs';
import { collectionItem } from 'src/app/model/collectionItem';
import { SolicitudAyuda } from 'src/app/model/SolicitudAyuda';
import { DataService } from 'src/app/services/data.service';

import Swal from 'sweetalert2';
import axios from 'axios';

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
    email: new FormControl('', Validators.email),
    sexo: new FormControl(''),
    direccion: new FormControl(''),
    montoAyuda: new FormControl(''),
    esJubiladoInabima: new FormControl(''),
    estadoCuenta: new FormControl('', Validators.required),
    motivoSolicitud: new FormControl('', Validators.required)
  });


  QuienRecibiraAyuda: Array<collectionItem> = [
    new collectionItem('--SELECCIONE--', null, ''),
    new collectionItem('El Solicitante', 1, ''),
    new collectionItem('Hijo/Hija', 2, 'RBActaNacimiento'),
    new collectionItem('Padre/Madre', 3, 'RBPadreMadre'),
    new collectionItem('Conyuge o Esposa/Esposo', 4, 'RBConyuge'),
  ]

  //end of form controls
  constructor(private dataService: DataService, private fb: FormBuilder) {
    console.log(this.QuienRecibiraAyuda);
  }

  Solicitud: SolicitudAyuda;
  seccionales: Array<any>;
  selectedSeccional: any;
  cargandoSeccionales: boolean;
  tiposSolicitudes: Array<any>;
  TipoDeAyuda: any;
  RequisitosSolicitud: Array<any>;

  archivos: File[] = [];

  isLoading() {
    return this.cargandoSeccionales;
  }

  typeaheadOnSelect(e: TypeaheadMatch): void {
    this.selectedSeccional = e.item;
  }

  ngOnInit() {
    this.cargandoSeccionales = true;
    this.Solicitud = new SolicitudAyuda();


    this.dataService.GetSeccionales().subscribe(data => {
      this.seccionales = data;
      this.cargandoSeccionales = false;
    }, err => {
      this.cargandoSeccionales = false;
    })

    this.dataService.GetTiposSolicitudesConRequisitos().subscribe(data => {
      this.tiposSolicitudes = data;
    }, err => {
      console.log(err);
    })

    this.cargandoSeccionales = false;

  }

  SearchCedula() {
    var fieldCedula = this.solicitudAyudaForm.get('cedula');
    if (fieldCedula.valid) {
      let cedula = this.solicitudAyudaForm.get('cedula').value
      console.log(cedula)
    }
    else {
      console.log(fieldCedula.errors);
      Swal.fire('Error al buscar maestro', 'Favor completar la cédula antes de consultar', 'error');
    }

  }

  removerSeccional() {
    this.selectedSeccional = null;
    this.selected = null;
  }

  selected: any;

  esJubiladoInabima() {
    return this.solicitudAyudaForm.get('esJubiladoInabima').value === 'true';
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

  GetErrors(fieldName, errorName) {
    var control = this.solicitudAyudaForm.get(fieldName);

    if (control.pristine || !control.errors) {
      return false;
    }
    else {
      return control.errors[errorName];
    }

  }


  onChangeQuienRecibiraAyuda(value) {
    console.log(value);

    let quienRecibira = this.QuienRecibiraAyuda.filter(q => q.value == value)[0];

    //let keys = this.QuienRecibiraAyuda.filter(x => x.formControlName != value &&  x.formControlName != '' );

    this.QuienRecibiraAyuda.forEach(key => {
      this.solicitudAyudaForm.removeControl(key.formControlName);
    });

    if (quienRecibira.formControlName) {
      let fc = new FormControl(quienRecibira.formControlName, Validators.required);
      fc.setValue(null);

      this.solicitudAyudaForm.addControl(quienRecibira.formControlName, fc);
    }
  }

  onChangeSolicitadoaJubilado(value) {
    let field = this.solicitudAyudaForm.get('estadoCuenta');
    if(value == 'true'){
      field.clearValidators();
      field.setValidators(Validators.required)
      field.updateValueAndValidity();
    }
    else{
      field.clearValidators();
      field.updateValueAndValidity();
    }
    console.log(value);
  }


  onSubmit() { 

   
    Object.keys(this.solicitudAyudaForm.controls).forEach(controlName => {
      let control = this.solicitudAyudaForm.get(controlName)
      if(!control.valid){
        console.log(control, controlName);
        
      }
    });

    if (this.solicitudAyudaForm.valid && this.archivos.length) {

      Swal.fire({        
        icon: 'warning',
        title: 'Seguro que desea continuar?',
        text: 'Esta seguro que desea registrar la solicitud con los datos digitados?',
        showCancelButton: true,
        cancelButtonText: 'Cancelar',
        showConfirmButton: true,    
        confirmButtonText: 'Enviar Solicitud',
        showLoaderOnConfirm: true,
        allowOutsideClick: false,
        preConfirm:  () => {
          let form = new FormData();
          form.append("CedulaSolicitante", this.solicitudAyudaForm.get('cedula').value)
          
          form.append("Celular", this.solicitudAyudaForm.get('telefonoCelular').value);
          form.append("TelefonoCasa", this.solicitudAyudaForm.get('telefonoResidencia').value);
          form.append("TelefonoTrabajo", this.solicitudAyudaForm.get('telefonoLaboral').value);
          form.append("Email", this.solicitudAyudaForm.get('email').value);

          form.append("Concepto", this.solicitudAyudaForm.get('motivoSolicitud').value);
          form.append("MontoSolicitado", this.solicitudAyudaForm.get('montoAyuda').value);

          let requisitos = [];
          this.RequisitosSolicitud.forEach(r => {
            let controlRequisito = this.solicitudAyudaForm.get(r.formName);
            requisitos.push({
              RequisitoTiposSolicitudId: r.id,
              Value: controlRequisito.value
            })
          })

          form.append("Requisitos", JSON.stringify(requisitos))

          console.log(requisitos);
          
          this.archivos.forEach(f => {
            form.append(f.name, f, f.name);
          })

          return axios.post('/api/Solicitud/post', form,  {withCredentials: true})
          .catch(error => {
            Swal.showValidationMessage(`Request failed: ${error}`)
          })
        }
      }).then(result => {
        if(result.isConfirmed){
          console.log(result.value);          
        }
      })

      

    }
    else {
      Object.keys(this.solicitudAyudaForm.controls).forEach(key => {
        this.solicitudAyudaForm.get(key).markAsDirty();
      });

      Swal.fire('Error en formulario', 'Existen errores en el formulario, favor verificar mensajes en rojo.', 'error')
    }

  }

  GetAllErrors(){

  }

  SetFiles(fileList) {
    this.archivos = fileList;
  }

}

//Mask plugin documentation
//https://www.npmjs.com/package/ngx-mask