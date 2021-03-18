import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ActivacionUsuarioDTO } from 'src/app/model/ActivacionUsuarioDTO';
import { DataService } from 'src/app/services/data.service';
import { UtilsService } from 'src/app/services/utils.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-activar-usuario',
  templateUrl: './activar-usuario.component.html',
  styleUrls: ['./activar-usuario.component.css']
})
export class ActivarUsuarioComponent implements OnInit {

  formulario = new FormGroup({
    nombreCompleto: new FormControl(""),
    email: new FormControl(""),
    seccional: new FormControl(""),
    password1: new FormControl(""),
    password2: new FormControl(""),
  });

  usuario: ActivacionUsuarioDTO;
  cargando: boolean = false;

  constructor(private dataService: DataService, 
    private activatedRoute: ActivatedRoute, private router:Router, private utils:UtilsService) { }

  disableInputs(){
    this.formulario.controls.password1.disable();
    this.formulario.controls.password2.disable();
  }

  activarUsuario() {
    this.disableInputs();
    this.usuario.password1 =  this.formulario.controls.password1.value;
    this.usuario.password2 =  this.formulario.controls.password2.value;

    this.cargando = true;
    this.dataService.ActivarUsuario(this.usuario).subscribe(response => {
      if(response.success){
        this.dataService.CerrarSesion();
        this.router.navigate(['/login']);
        //this.dataService.showNav.next(true);
        Swal.fire('Usuario Activado', `El usuario ${this.usuario.email} ha sido activado correctamente`, 'success');
      }
      else{
        let err = this.utils.GetUnorderedList(response.errors)
        Swal.showValidationMessage(`Request failed: ${err}`);
      }
      this.cargando = false;
    }, error => {
      Swal.showValidationMessage(`Request failed: ${error}`)
      this.cargando = false;
      console.log(error);
    })    
  }

  ngOnInit() {
    this.formulario.controls.nombreCompleto.disable();
    this.formulario.controls.email.disable();
    this.formulario.controls.seccional.disable();

    this.dataService.showNav.next(false);

    this.activatedRoute.params.subscribe(params => {
      let id = params['id'];

      this.cargando = true;
      this.dataService.GetDatosParaActivacion(id).subscribe(response => {
        if (response.success) {
          this.usuario = response.data;

          this.formulario.controls.nombreCompleto.setValue(this.usuario.nombreCompleto);
          this.formulario.controls.email.setValue(this.usuario.email);
          this.formulario.controls.seccional.setValue(this.usuario.seccional);

          console.log(this.usuario);
        }
        this.cargando = false;
      }, error => {
        this.cargando = false;
      })
    })
    //this.dataService.Get

  }

  IsValid(){
    return this.formulario.valid 
    && this.formulario.controls.password1.value == this.formulario.controls.password2.value;
  }
}


