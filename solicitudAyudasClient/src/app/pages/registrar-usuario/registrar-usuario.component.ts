import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { delay, first, map } from 'rxjs/operators';
import { SeccionalComponent } from 'src/app/common/seccional/seccional.component';
import { HttpDataResponse } from 'src/app/model/HttpDataResponse';
import { ItemModel } from 'src/app/model/itemModel';
//import { CreacionUsuarioDTO } from 'src/app/model/CreacionUsuarioDTO';
import { PermisoUsuarioDTO } from 'src/app/model/PermisoUsuarioDTO';
import { SeccionalDTO } from 'src/app/model/SeccionalDTO';
import { Usuario } from 'src/app/model/Usuarios/Usuario';
import { DataService } from 'src/app/services/data.service';
import { UtilsService } from 'src/app/services/utils.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-registrar-usuario',
  templateUrl: './registrar-usuario.component.html',
  styleUrls: ['./registrar-usuario.component.css']
})
export class RegistrarUsuarioComponent implements OnInit {

  @ViewChild('seccionalComponent') seccionalesComponent: SeccionalComponent;

  formulario = new FormGroup({
    Id: new FormControl(''),
    Cedula: new FormControl(''),
    Email: new FormControl('', Validators.email),
    NombreCompleto: new FormControl(''),
    SeccionalId: new FormControl(''),
    Seccional: new FormControl(''),
    FechaNacimiento: new FormControl(''),
    TelefonoCelular: new FormControl(''),
    TelefonoResidencial: new FormControl(''),
    TelefonoLabora: new FormControl(''),
    Sexo: new FormControl(''),
    Direccion: new FormControl(''),
    Cargo: new FormControl(''),
    Disponible: new FormControl('')
  });

  constructor(private dataService: DataService,
    private utils: UtilsService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.usuarioId$ = this.activatedRoute.params.pipe(
      first(),
      map(prms => prms["usuarioId"] ? parseFloat(prms["usuarioId"]) : 0),
    )
  }

  seccional: any;
  cargando: boolean;
  usuario: Usuario = {} as Usuario;

  usuarioId$: Observable<number>;



  ngOnInit() {
    this.usuarioId$.subscribe(usuarioId => {
      if (usuarioId) {
        this.usuario.Id = usuarioId

        this.cargando = true;
        this.dataService.GetDetalleUsuario(usuarioId).subscribe(response => {
          let usr = response.Data;

          this.formulario.get('Id').setValue(usr.Id);
          this.formulario.get('Cedula').setValue(usr.Cedula);
          this.formulario.get('Email').setValue(usr.Email);
          this.formulario.get('NombreCompleto').setValue(usr.NombreCompleto);
          this.formulario.get('SeccionalId').setValue(usr.SeccionalId);
          this.formulario.get('Seccional').setValue(usr.Seccional);
          this.formulario.get('FechaNacimiento').setValue(new Date(usr.FechaNacimiento));
          this.formulario.get('TelefonoCelular').setValue(usr.TelefonoCelular);
          this.formulario.get('TelefonoResidencial').setValue(usr.TelefonoResidencial);
          this.formulario.get('TelefonoLabora').setValue(usr.TelefonoLabora);
          this.formulario.get('Sexo').setValue(usr.Sexo);
          this.formulario.get('Direccion').setValue(usr.Direccion);
          this.formulario.get('Cargo').setValue(usr.Cargo);
          this.formulario.get('Disponible').setValue(usr.Disponible);



          this.cargando = false;
          this.dataService.userUserLoaded.next(this.usuario.Id);
          let seccionalDto: SeccionalDTO = new SeccionalDTO();
          seccionalDto.seccionalId = usr.SeccionalId;

          seccionalDto.seccional = usr.Seccional;

          this.usuario.PermisosUsuario = usr.PermisosUsuario;
          this.usuario.ComisionesAprobacion = usr.ComisionesAprobacion;

          this.dataService.setSeccional.next(seccionalDto);

        }, error => {
          this.cargando = false;
        });
      }
      else {
        this.dataService.GetPermisosYComisiones().subscribe(response => {
          if (response.success) {
            this.usuario.PermisosUsuario = response.data.permisos;
            this.usuario.ComisionesAprobacion = response.data.comisiones;
          }

        }, error => {

        })
      }
    })
  }

  onPermisosChange(event) {
    this.usuario.PermisosUsuario = event;
  }

  onComisionesUsuarioChange(event) {
    this.usuario.ComisionesAprobacion = event;
    console.log(event)
  }

  onSubmit() {

    let action = this.usuario.Id ? "Actualizar" : "Crear";

    if (this.formulario.valid) {
      Swal.fire({
        title: `Aviso`,
        text: `Desea ${action} este usuario?`,
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        showConfirmButton: true,
        icon: 'warning',
        showLoaderOnConfirm: true,
        allowOutsideClick: false,
        confirmButtonText: action,
        preConfirm: () => {
          return new Promise((resolve, reject) => {

            const usuario = this.formulario.value as Usuario;
            usuario.PermisosUsuario = [... this.usuario.PermisosUsuario];
            usuario.ComisionesAprobacion = [...this.usuario.ComisionesAprobacion];


            this.dataService.CrearUsuario(usuario).subscribe(response => {

              resolve(response);
            }, error => {
              reject(error);
            });

          }).catch(err => {
            this.utils.DefaultGeneralFail();
          })
        }
      }).then(alertResult => {
        let response: HttpDataResponse<any> = alertResult.value as HttpDataResponse<any>;

        if (response.Success) {
          Swal.fire({
            title: `Usuario ${action} satisfactoriamente`,
            text: "Datos guardados correctamente",
            icon: 'info'
          }).then(alertResult => {
            this.router.navigate(['/consultausuarios'])
          });
        }
        else {
          Swal.fire('Hubo un error al procesar solicitud', this.utils.GetUlList(response), 'error');
        }

        //console.log('RESOLVED', alertResult);
      }).catch(err => {
        this.utils.DefaultGeneralFail();
      })
    }
    else {
      Object.keys(this.formulario.controls).forEach(controlName => {
        let control = this.formulario.get(controlName)
        control.markAsDirty();
      });
    }


  }

  SearchEmail() {
    let { email } = this.formulario.controls;

    this.dataService.GetUsuarioPorEmail(email.value).subscribe((response) => {
      if (response.success) {
        let createdUser = response.data;
        if (createdUser) {
          Swal.fire('Error', `Ya se ha creado un usuario con el email ${email.value}`, 'error');
        }
      }
      else {
        Swal.fire('Error al validar email', this.utils.GetUnorderedList(response.console.errors), 'error');
      }
    });
  }

  SetSeccional(event:ItemModel) {
    this.seccional = event;
    this.formulario.controls.SeccionalId.setValue(event.Id);
    this.formulario.controls.Seccional.setValue(event.Nombre);
  }
  SearchCedula() {

  }

  GetErrors(fieldName, errorName) {
    return this.dataService.GetErrors(this.formulario, fieldName, errorName)
  }

  ngAfterViewInit() {
    this.usuarioId$
      .pipe(
        delay(200)
      )
      .subscribe(usuarioId => {
        if (usuarioId) {
          console.log(usuarioId);
          const itemModel: ItemModel = {
            Id: this.formulario.controls.SeccionalId.value,
            Nombre: this.formulario.controls.Seccional.value
          }
          this.seccionalesComponent.SetSeccional(itemModel);
        }
      })

  }
}
