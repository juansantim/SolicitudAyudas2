import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';

import { collectionItem } from 'src/app/model/collectionItem';
import { DataService } from 'src/app/services/data.service';

import Swal from 'sweetalert2';
import { UtilsService } from 'src/app/services/utils.service';
import { AppCookieService } from 'src/app/services/app-cookie.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

import { ActivatedRoute, Router } from '@angular/router';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { esDoLocale } from 'ngx-bootstrap/locale';
import { UploadedFile } from 'src/app/model/UploadedFile';
import { select, Store } from '@ngrx/store';
import { AppAuthState } from 'src/app/store/app.auth.reducers';
import { userProfile } from 'src/app/store/app.selectors';
import { first } from 'rxjs/operators';
import { ItemModel } from 'src/app/model/itemModel';
import { TipoSolicitud } from 'src/app/model/Solicitud/TipoSolicitud';
import { HttpDataResponse } from 'src/app/model/HttpDataResponse';

defineLocale('es-do', esDoLocale);

@Component({
  selector: 'app-registro-solicitud',
  templateUrl: './registro-solicitud.component.html',
  styleUrls: ['./registro-solicitud.component.css']
})
export class RegistroSolicitudComponent implements OnInit {

  bearer: string;
  //form controls:
  solicitudAyudaForm = new FormGroup({

    solicitudId: new FormControl(''),
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
    direccion: new FormControl('', Validators.required),
    montoAyuda: new FormControl(''),
    esJubiladoInabima: new FormControl(''),
    estadoCuenta: new FormControl('', Validators.required),
    motivoSolicitud: new FormControl('', Validators.required),
    cargo: new FormControl('', Validators.required),
    banco: new FormControl(''),
    numeroCuentaBanco: new FormControl(''),

    QuienRecibeAyuda: new FormControl(''),

    RBActaNacimiento: new FormControl(''),
    RBPadreMadre: new FormControl(''),
    RBConyuge: new FormControl(''),
    otroTipoSolicitud: new FormControl(''),
    fechaSolicitud: new FormControl('', Validators.required)
  });

  QuienRecibiraAyuda: Array<collectionItem> = [
    new collectionItem('--SELECCIONE--', null, ''),
    new collectionItem('El Solicitante', 1, ''),
    new collectionItem('Hijo/Hija', 2, 'RBActaNacimiento'),
    new collectionItem('Padre/Madre', 3, 'RBPadreMadre'),
    new collectionItem('Conyuge o Esposa/Esposo', 4, 'RBConyuge'),
  ]

  //end of form controls
  constructor(private dataService: DataService,
    private util: UtilsService,
    private cookieService: AppCookieService,
    private localeService: BsLocaleService,
    private router: Router,
    private route: ActivatedRoute,
    private store: Store<AppAuthState>) {
    console.log(this.QuienRecibiraAyuda);
  }

  cargando: boolean;
  uploadedFiles: Array<UploadedFile> = [];

  ngOnInit() {


    this.store.pipe(
      select(userProfile),
      first()
    ).subscribe(profile => {
      this.bearer = profile.Token;
    })

    this.setSeccionalesDisabled();

    this.localeService.use('es-do');

    this.dataService.GetSeccionales().subscribe(data => {
      this.seccionales = data;
      this.setSeccionalesEnabled();
    }, err => {
      Swal.fire('Error', 'Hubo un error al cargar seccionales. Intente nuevamente mas tarde', 'error')
    })

    this.dataService.GetTiposSolicitudesConRequisitos().subscribe(data => {
      this.tiposSolicitudes = data;
    }, err => {
      console.log(err);
    })

    this.dataService.GetBancos().subscribe(bancos => {
      this.bancos = bancos;
    })

    this.cargandoSeccionales = false;

    const routeParams = this.route.snapshot.paramMap;
    const solicitudId = Number(routeParams.get('solicitudId'));

    if (solicitudId) {
      this.dataService.GetPuedeModificarSolicitud().subscribe(puede => {
        if (puede) {
          this.cargando = true;

          this.dataService.GetDetalleSolicitud(solicitudId).subscribe(solicitud => {

            this.solicitudAyudaForm.controls.solicitudId.setValue(solicitudId);

            this.solicitudAyudaForm.controls.cedula.setValue(solicitud.CedulaSolicitante);
            this.solicitudAyudaForm.controls.cedula.disable();

            this.solicitudAyudaForm.controls.nombreCompleto.setValue(solicitud.Maestro);
            this.solicitudAyudaForm.controls.nombreCompleto.disable();

            this.solicitudAyudaForm.controls.fechaNacimiento.setValue(new Date(solicitud.FechaNacimiento));
            this.solicitudAyudaForm.controls.fechaNacimiento.disable();

            this.solicitudAyudaForm.controls.sexo.setValue(solicitud.SexoMaestro);
            this.solicitudAyudaForm.controls.sexo.disable();

            this.maestro = {};

            this.solicitudAyudaForm.controls.seccional.setValue(solicitud.Seccional);

            this.selectedSeccional = {
              Id: solicitud.SeccionalId
            }

            this.solicitudAyudaForm.controls.seccional.disable();

            this.solicitudAyudaForm.controls.cargo.setValue(solicitud.Cargo);
            this.solicitudAyudaForm.controls.cargo.disable();

            this.solicitudAyudaForm.controls.tipoDeAyuda.setValue(solicitud.TipoSolicitudId);
            this.solicitudAyudaForm.controls.tipoDeAyuda.disable();

            if (solicitud.CategoriaId === 3) {
              this.EspecificarOtro = true;
            }
            else {
              this.EspecificarOtro = false;
            }

            this.solicitudAyudaForm.controls.montoAyuda.setValue(solicitud.MontoSolicitado);

            this.solicitudAyudaForm.controls.banco.setValue(solicitud.BancoId);

            this.solicitudAyudaForm.controls.numeroCuentaBanco.setValue(solicitud.NumeroCuentaBanco)

            this.solicitudAyudaForm.controls.telefonoCelular.setValue(solicitud.Celular)
            this.solicitudAyudaForm.controls.telefonoResidencia.setValue(solicitud.TelefonoCasa)
            this.solicitudAyudaForm.controls.telefonoLaboral.setValue(solicitud.TelefonoTrabajo)
            this.solicitudAyudaForm.controls.email.setValue(solicitud.Email)
            this.solicitudAyudaForm.controls.direccion.setValue(solicitud.Direccion)

            this.solicitudAyudaForm.controls.quienRecibeAyuda.setValue(solicitud.QuienRecibeAyuda);

            this.solicitudAyudaForm.controls.RBActaNacimiento.setValue(solicitud.ActaNacimientoHijoHija);
            this.solicitudAyudaForm.controls.RBPadreMadre.setValue(solicitud.CopiaCedulaPadreMadre);
            this.solicitudAyudaForm.controls.RBConyuge.setValue(solicitud.ActaMatrimonioUnion);

            this.solicitudAyudaForm.controls.esJubiladoInabima.setValue(solicitud.EsJubiladoInabima ? 'true' : 'false');
            this.solicitudAyudaForm.controls.esJubiladoInabima.markAsTouched();

            this.solicitudAyudaForm.controls.motivoSolicitud.setValue(solicitud.MotivoSolicitud);

            this.solicitudAyudaForm.controls.estadoCuenta.setValue(solicitud.EsJubiladoInabima ? true : false);

            this.solicitudAyudaForm.controls.otroTipoSolicitud.setValue(solicitud.OtroTipoSolicitud);

            this.solicitudAyudaForm.controls.fechaSolicitud.setValue(new Date(solicitud.FechaSolicitud));

            this.uploadedFiles = solicitud.Adjuntos;

            if (solicitud.Requisitos.length > 0) {

              solicitud.Requisitos.forEach(element => {
                let control = new FormControl('', Validators.required);

                this.solicitudAyudaForm.addControl(element.FormName, control);
                control.markAllAsTouched();

                control.setValue(element.Values.length ? element.value : true)
              });

            }

            this.RequisitosSolicitud = solicitud.Requisitos;

            this.cargando = false;
          }, error => {
            this.cargando = false;
          })


        }
        else {
          this.router.navigate([`/accesoDenegado/`]);
        }
      })
    }

  }

  //Solicitud: SolicitudAyuda;
  seccionales: Array<any>;
  selectedSeccional: any;
  cargandoSeccionales: boolean;
  tiposSolicitudes: Array<TipoSolicitud>;
  TipoDeAyuda: any;
  RequisitosSolicitud: Array<any>;
  bancos: Array<ItemModel> = [];

  archivos: File[] = [];

  isLoading() {
    return this.cargandoSeccionales;
  }

  typeaheadOnSelect(e: TypeaheadMatch): void {
    console.log(e.item);
    this.selectedSeccional = e.item;
    this.setSeccionalesDisabled();
  }

  setSeccionalesDisabled() {
    this.solicitudAyudaForm.get('seccional').disable();
  }

  setSeccionalesEnabled() {
    this.solicitudAyudaForm.get('seccional').enable();
  }



  maestro: any;
  cargandoCedula: boolean;
  SearchCedula() {
    var fieldCedula = this.solicitudAyudaForm.get('cedula');

    if (fieldCedula.valid) {
      let cedula = this.solicitudAyudaForm.get('cedula').value
      this.cargandoCedula = true;

      this.dataService.GetMaestro(cedula).subscribe(response => {
        if (response.success) {
          if (response.data) {
            let maestro = response.data;
            let seccional = {
              id: maestro.seccionalId,
              nombre: maestro.seccional
            };

            let seccionalField = this.solicitudAyudaForm.get('seccional');
            seccionalField.setValue(seccional.nombre);
            seccionalField.disable();
            this.selectedSeccional = seccional;

            let nombreCompletoFiled = this.solicitudAyudaForm.get('nombreCompleto');
            nombreCompletoFiled.setValue(maestro.nombreCompleto);

            let fechaNacimientoField = this.solicitudAyudaForm.get('fechaNacimiento');
            let date = new Date(maestro.fechaNacimiento)
            fechaNacimientoField.setValue(date);

            let sexoField = this.solicitudAyudaForm.get('sexo');
            sexoField.setValue(maestro.sexo)

            let cargoField = this.solicitudAyudaForm.get('cargo');
            cargoField.setValue(maestro.cargo);

            this.maestro = maestro;

          }
          else {
            console.log('no hay ningun maestro registrado con esta cedula');
          }


        }

        this.cargandoCedula = false;
      }, error => {
        this.cargandoCedula = false;
      })

    }
    else {
      console.log(fieldCedula.errors);
      Swal.fire('Error al buscar maestro', 'Favor completar la cédula antes de consultar', 'error');
    }

  }

  bsConfig = { dateInputFormat: 'DD/MM/YYYY' }

  limpiarMaestro() {
    this.maestro = null;

    let seccionalField = this.solicitudAyudaForm.get('seccional');
    seccionalField.setValue('');
    seccionalField.enable();

    this.selectedSeccional = null;

    let nombreCompletoFiled = this.solicitudAyudaForm.get('nombreCompleto');
    nombreCompletoFiled.setValue('');

    let fechaNacimientoField = this.solicitudAyudaForm.get('fechaNacimiento');
    fechaNacimientoField.setValue('');

    let sexoField = this.solicitudAyudaForm.get('sexo');
    sexoField.setValue('');

    let cargoField = this.solicitudAyudaForm.get('cargo');
    cargoField.setValue('');


  }

  removerSeccional() {
    this.selectedSeccional = null;
    this.selected = null;
    this.setSeccionalesEnabled();
    this.solicitudAyudaForm.get('seccional').setValue(null);
  }

  selected: any;

  esJubiladoInabima() {
    return this.solicitudAyudaForm.get('esJubiladoInabima').value === 'true';
  }

  EspecificarOtro: boolean;

  onChangeTipoSolicitud(tipoSolicitudId) {

    var tipoSolictud = this.tiposSolicitudes.filter(tipo => tipo.Id == tipoSolicitudId)[0]

    let keys = [];

    Object.keys(this.solicitudAyudaForm.controls).forEach(key => {
      keys.push(key);
    });

    keys.filter((k) => {
      k.startsWith("rd")
    }).forEach(key => {
      this.solicitudAyudaForm.removeControl(key);
    })

    if (tipoSolictud.Requisitos.length > 0) {
      tipoSolictud.Requisitos.forEach(element => {
        this.solicitudAyudaForm.addControl(element.FormName, new FormControl())
        //console.log(element.formName);
      });

    }
    this.RequisitosSolicitud = tipoSolictud.Requisitos;

    if (tipoSolictud.CategoriaId === 3) {
      this.EspecificarOtro = true;
    }
    else {
      this.EspecificarOtro = false;
    }
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

    let quienRecibira = !value ? this.QuienRecibiraAyuda[0] : this.QuienRecibiraAyuda.filter(q => q.value == value)[0];

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
    if (value == 'true') {
      field.clearValidators();
      field.setValidators(Validators.required)
      field.updateValueAndValidity();
    }
    else {
      field.clearValidators();
      field.updateValueAndValidity();
    }
    console.log(value);
  }


  onSubmit() {


    Object.keys(this.solicitudAyudaForm.controls).forEach(controlName => {
      let control = this.solicitudAyudaForm.get(controlName)
      if (!control.valid) {
        console.log(control, controlName);
      }
    });

    if (this.solicitudAyudaForm.valid) {

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
        preConfirm: () => {
          let form = new FormData();

          form.append("SolicitudId", this.solicitudAyudaForm.get('solicitudId') ? this.solicitudAyudaForm.get('solicitudId').value : 0);

          form.append("SeccionalId", this.selectedSeccional.Id);
          form.append("CedulaSolicitante", this.solicitudAyudaForm.get('cedula').value)

          form.append("Celular", this.solicitudAyudaForm.get('telefonoCelular').value);
          form.append("TelefonoCasa", this.solicitudAyudaForm.get('telefonoResidencia').value);
          form.append("TelefonoTrabajo", this.solicitudAyudaForm.get('telefonoLaboral').value);
          form.append("Email", this.solicitudAyudaForm.get('email').value);
          form.append("TipoSolicitudId", this.solicitudAyudaForm.get('tipoDeAyuda').value);

          form.append("Concepto", this.solicitudAyudaForm.get('motivoSolicitud').value);
          form.append("MontoSolicitado", this.solicitudAyudaForm.get('montoAyuda').value);

          form.append("Direccion", this.solicitudAyudaForm.get('direccion').value);
          form.append("BancoId", this.solicitudAyudaForm.get('banco').value,);
          form.append("NumeroCuentaBanco", this.solicitudAyudaForm.get('numeroCuentaBanco').value);

          form.append("QuienRecibeAyuda", this.solicitudAyudaForm.get('quienRecibeAyuda').value);

          form.append("ActaNacimientoHijoHija", this.solicitudAyudaForm.get('RBActaNacimiento') ? this.solicitudAyudaForm.get('RBActaNacimiento').value : false);
          form.append("CopiaCedulaPadreMadre", this.solicitudAyudaForm.get('RBPadreMadre') ? this.solicitudAyudaForm.get('RBPadreMadre').value : false);
          form.append("ActaMatrimonioUnion", this.solicitudAyudaForm.get('RBConyuge') ? this.solicitudAyudaForm.get('RBConyuge').value : false);
          form.append("EsJubiladoInabima", this.solicitudAyudaForm.get('esJubiladoInabima') ? this.solicitudAyudaForm.get('esJubiladoInabima').value : false);
          form.append("EstadoCuenta", this.solicitudAyudaForm.get('estadoCuenta') ? this.solicitudAyudaForm.get('estadoCuenta').value : false);

          form.append("OtroTipoSolicitud", this.solicitudAyudaForm.get('otroTipoSolicitud').value);


          form.append("FechaSolicitud", this.solicitudAyudaForm.get('fechaSolicitud').value.toISOString());

          let requisitos = [];

          this.RequisitosSolicitud.forEach(r => {

            let controlRequisito = this.solicitudAyudaForm.get(r.FormName);

            requisitos.push({
              RequisitoTiposSolicitudId: r.Id,
              Value: controlRequisito.value
            })
          })

          form.append("Requisitos", JSON.stringify(requisitos));

          form.append("MaestroDTO", JSON.stringify({
            Cedula: this.solicitudAyudaForm.get('cedula').value,
            NombreCompleto: this.solicitudAyudaForm.get('nombreCompleto').value,
            FechaNacimiento: this.solicitudAyudaForm.get('fechaNacimiento').value,
            Sexo: this.solicitudAyudaForm.get('sexo').value,
            SeccionalId: this.selectedSeccional.Id,
            Cargo: this.solicitudAyudaForm.get('cargo').value,

          }))


          this.archivos.forEach(f => {
            form.append(f.name, f, f.name);
          })



          let headers = { 'Authorization': `Bearer ${this.bearer}`, 'Access-Control-Allow-Origin': '*' }

          let url = this.dataService.GetUrl('Solicitud/post');

          return fetch(url, {
            method: 'POST',
            headers: headers,
            body: form,
          })
            .then(response => {
              return response.json()
            })
            .then(response => {
              let responseMessage = response;

              if (responseMessage.Success) {
                let solicitudId = responseMessage.Data.SolicitudId;

                Swal.fire({
                  title: 'Solicitud de ayuda registrada satisfactoriamente',
                  text: `El número de solicitud registrado es ${solicitudId}.`,
                  icon: 'success',
                  confirmButtonText: 'Ok',
                  showConfirmButton: true
                }).then(alertResult => {

                  //this.router.navigate(['/detalle', solicitudId]);
                  this.GoToDetails(solicitudId);
                });
              }
              else {
                let ul = this.util.GetUnorderedList(responseMessage.errors);
                Swal.showValidationMessage(`Request failed: ${ul}`);
              }

            })
            .catch(error => {
              Swal.showValidationMessage(`Request failed: ${error}`)
            })

        }
      }).then(result => {
        if (result.isConfirmed) {
          console.log(result.value);
        }
      }).catch(err => {
        Swal.fire({
          title: 'Error al enviar datos',
          text: 'Error',
          icon: 'error'
        })
      })

    }
    else {
      Object.keys(this.solicitudAyudaForm.controls).forEach(key => {
        this.solicitudAyudaForm.get(key).markAsDirty();
      });

      Swal.fire('Error en formulario', 'Existen errores en el formulario, favor verificar mensajes en rojo.', 'error')
    }

  }

  GoToDetails(solicitudId) {
    this.router.navigate(['/detalle', solicitudId]);
  }

  SetFiles(fileList) {
    this.archivos = fileList;
  }

  anularSolicitud() {

    const solicitudId: number = this.solicitudAyudaForm.controls.solicitudId.value;

    Swal.fire({
      title: 'Anular Solicitud',
      text: `Seguro que desea Anular esta solicitud?`,
      icon: 'question',
      showConfirmButton: true,
      confirmButtonText: 'Si, Anular',
      confirmButtonColor: 'red',
      showCancelButton: true,
      cancelButtonText: 'No',
      preConfirm: () => {
        return new Promise((resolve, reject) => {
          this.dataService.Anular(solicitudId).subscribe(response => {
            resolve(response)
          }, err => {
            reject(err);
          })

        })
      }
    }).then((alertResult: any) => {
      if (alertResult.isConfirmed) {
        
        const response:HttpDataResponse<number> = alertResult.value;

        if (response && response.Success) {
          Swal.fire({
            title: `Solicitud Anulada`,
            text: `solicitud ${solicitudId} anulada correctamente`,
            icon: 'warning'
          })

          this.GoToDetails(solicitudId);          
        }
        else {
          Swal.fire({
            title: 'Error al anular solicitud',
            html: `Error al procesar: ${this.util.GetUlList(response)}`,
            icon: 'error'
          })
        }
      }
    }).catch(error => {
      Swal.showValidationMessage(
        `Request failed: ${error}`
      )
    });
  }

}


//Mask plugin documentation
//https://www.npmjs.com/package/ngx-mask