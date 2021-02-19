import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AppCookieService } from '../services/app-cookie.service';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    usuario: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  })

  cargando:boolean = false;

  constructor(private router: Router, private dataService: DataService, private cookieService:AppCookieService) { }

  ngOnInit() {
    
    if(this.cookieService.get('token')){
      this.router.navigate(['/inicio']);
    }
  }

  login() {

    if (this.loginForm.valid) {

      let usuario = this.loginForm.get('usuario').value;
      let password = this.loginForm.get('password').value;

      this.cargando = true;
      this.dataService.Login(usuario, password).subscribe(response => {        
        
        let bearer = response.token
        let usuario = response.usuario;

        this.cargando = false;
        
        this.cookieService.set('token', bearer);        
        localStorage.setItem('usuario', JSON.stringify(usuario));
        console.log(usuario);
        
        this.router.navigate(['/inicio']);
      }, error => {
        this.cargando = false;
        let errorMessage = "";
        if(error.status == 401){
          errorMessage ="Nombre de usuario y/o contraseña invalidos";
        }
        else{
          errorMessage = error.message;
        }
        Swal.fire('Hubo un error al procesar solicitud', errorMessage, 'error');
      })

    }
    else{

      Object.keys(this.loginForm.controls).forEach(key => {
        this.loginForm.get(key).markAsDirty();
      });
    }



  }

}
