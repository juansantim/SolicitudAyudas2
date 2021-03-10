import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CreacionUsuarioDTO } from 'src/app/model/CreacionUsuarioDTO';
import { PermisoUsuarioDTO } from 'src/app/model/PermisoUsuarioDTO';
import { SeccionalDTO } from 'src/app/model/SeccionalDTO';
import { DataService } from 'src/app/services/data.service';
import { UtilsService } from 'src/app/services/utils.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-registrar-usuario',
  templateUrl: './registrar-usuario.component.html',
  styleUrls: ['./registrar-usuario.component.css']
})
export class RegistrarUsuarioComponent implements OnInit {

  formulario = new FormGroup({
    cedula: new FormControl(''),
    email: new FormControl('', Validators.email),
    nombreCompleto: new FormControl(''),
    seccional: new FormControl(''),
    fechaNacimiento: new FormControl(''),
    telefonoCelular: new FormControl(''),
    telefonoResidencia: new FormControl(''),
    telefonoLaboral: new FormControl(''),
    sexo: new FormControl(''),
    direccion: new FormControl(''),
    cargo: new FormControl('')
  });

  constructor(private dataService: DataService, 
    private utils: UtilsService, private router: Router, private activatedRoute: ActivatedRoute) { }

  seccional: any;
  cargando: boolean;  
  usuario: CreacionUsuarioDTO = new CreacionUsuarioDTO();

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.usuario.Id = parseInt(params['usuarioId']);
      
      this.cargando = true;
      this.dataService.GetDetalleUsuario(this.usuario.Id).subscribe(response => {
        let usr = response.data;

        this.formulario.get('cedula').setValue(usr.cedula);
        this.formulario.get('email').setValue(usr.email);
        this.formulario.get('nombreCompleto').setValue(usr.nombreCompleto);
        this.formulario.get('seccional').setValue(usr.seccionalId);
        this.formulario.get('fechaNacimiento').setValue(usr.fechaNacimiento);
        this.formulario.get('telefonoCelular').setValue(usr.telefonoCelular);
        this.formulario.get('telefonoResidencia').setValue(usr.telefonoResidencia);
        this.formulario.get('telefonoLaboral').setValue(usr.telefonoLaboral);
        this.formulario.get('sexo').setValue(usr.sexo);
        this.formulario.get('direccion').setValue(usr.direccion);
        this.formulario.get('cargo').setValue(usr.cargo);
        
        this.cargando = false;
        this.dataService.userUserLoaded.next(this.usuario.Id);
        let seccionalDto:SeccionalDTO = new SeccionalDTO();
        seccionalDto.seccionalId = usr.seccionalId;
        seccionalDto.seccional = usr.seccional;

        this.dataService.setSeccional.next(seccionalDto);

      }, error => {
        this.cargando = false;
      });
      
    })
  }
  
  onPermisosChange(event){
    this.usuario.PermisosUsuario = event;
  }

  onSubmit() {


    if (this.formulario.valid) {

      let { cedula, email, nombreCompleto, fechaNacimiento,
        telefonoCelular, telefonoResidencia, telefonoLaboral,
        sexo, direccion, cargo } = this.formulario.controls;

       
      //let usuario = new CreacionUsuarioDTO();

      this.usuario.Cedula = cedula.value;
      this.usuario.Email = email.value;
      this.usuario.NombreCompleto = nombreCompleto.value;
      this.usuario.SeccionalId = this.seccional;
      this.usuario.FechaNacimiento = fechaNacimiento.value;
      this.usuario.TelefonoCelular = telefonoCelular.value;
      this.usuario.TelefonoResidencial = telefonoResidencia.value;
      this.usuario.TelefonoLabora = telefonoLaboral.value;
      this.usuario.Sexo = sexo.value
      this.usuario.Direccion = direccion.value;
      this.usuario.Cargo = cargo.value;
      this.usuario.Host = `${location.protocol}//${location.host}`

      let  action = this.usuario.Id? "actualizado": "creado";

      this.dataService.CrearUsuario(this.usuario).subscribe(response => {
        if (response.success) {
          Swal.fire({
            title: `Usuario ${action} satisfactoriamente`,
            text: `se ha enviado un correo electrónico a ${email.value} para completar el registro`,
            icon: 'info',
            showConfirmButton: true,
            confirmButtonText: 'Crear Otro Usuario',
            showCancelButton: true,
            cancelButtonText: "Ir a Consulta"
          }).then(alertResult => {
            if(alertResult.isConfirmed){
              Object.keys(this.formulario.controls).forEach(controlName => {
                let control = this.formulario.get(controlName)
                control.setValue('');
                control.markAsPristine();
              });
            }
            else{
              this.router.navigate(['/consultausuarios'])
            }
          });
        }
        else {
          Swal.fire('Hubo un error al procesar solicitud', this.utils.GetUnorderedList(response.errors), 'error');
        }
      }, error => {
        Swal.fire('Hubo un error al procesar solicitud', error.message, 'error');
      });
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

  SetSeccional(event) {
    this.seccional = event;
  }
  SearchCedula() {

  }

  GetErrors(fieldName, errorName) {
    return this.dataService.GetErrors(this.formulario, fieldName, errorName)
  }



}
