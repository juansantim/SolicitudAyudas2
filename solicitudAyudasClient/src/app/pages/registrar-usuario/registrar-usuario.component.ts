import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreacionUsuarioDTO } from 'src/app/model/CreacionUsuarioDTO';
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

  constructor(private dataService: DataService, private utils: UtilsService) { }

  seccional: any;

  ngOnInit() {
  }

  onSubmit() {


    if (this.formulario.valid) {

      let { cedula, email, nombreCompleto, fechaNacimiento, 
        telefonoCelular, telefonoResidencia, telefonoLaboral,
        sexo, direccion, cargo} = this.formulario.controls;

        let usuario = new CreacionUsuarioDTO();

        usuario.Cedula = cedula.value;
        usuario.Email = email.value;
        usuario.NombreCompleto = nombreCompleto.value;
        usuario.SeccionalId = this.seccional;
        usuario.FechaNacimiento = fechaNacimiento.value;
        usuario.TelefonoCelular = telefonoCelular.value;
        usuario.TelefonoResidencial = telefonoResidencia.value;
        usuario.TelefonoLabora = telefonoLaboral.value;
        usuario.Sexo = sexo.value
        usuario.Direccion = direccion.value;
        usuario.Cargo = cargo.value;
        usuario.Host = `${location.protocol}//${location.host}`

        this.dataService.CrearUsuario(usuario).subscribe(response => {
          if(response.success){
            Swal.fire('Usuario Registrado Satisfactoriamente', `e ha enviado un correo electronico a ${email.value} para completrar el registro`, 'info');
            Object.keys(this.formulario.controls).forEach(controlName => {
              let control = this.formulario.get(controlName)
              control.setValue('');
              control.markAsPristine();
            });
          }
          else{
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
