import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import Swal from 'sweetalert2';
import { UserData } from '../model/UserData';
import { AppCookieService } from '../services/app-cookie.service';
import { DataService } from '../services/data.service';
import { LoginActions } from '../store/app.actions.types';
import { AppState } from '../store/store';

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

  cargando: boolean = false;

  constructor(private router: Router,
    private dataService: DataService,
    private cookieService: AppCookieService,
    private store: Store<AppState>) {

  }

  ngOnInit() {

    if (this.cookieService.get('token')) {
      this.router.navigate(['/inicio']);
      this.dataService.showNav.next(true);
    }
  }



  login() {
    if (this.loginForm.valid) {

      let usuario = this.loginForm.get('usuario').value;
      let password = this.loginForm.get('password').value;

      this.cargando = true;

      this.dataService.Login(usuario, password).subscribe(response => {

        let bearer = response.token
        let usuario: UserData = response.usuario;
        usuario.token = bearer;

        this.cargando = false;

        this.cookieService.set('token', bearer);
        
        localStorage.setItem('usuario', JSON.stringify(usuario));
        this.cookieService.set('usuario', JSON.stringify( usuario));

        this.router.navigate(['/inicio']);

        this.dataService.showNav.next(true);
        this.dataService.userLogedIn.next(usuario);

        this.store.dispatch(LoginActions.login({usuario}))

      }, error => {
        this.cargando = false;
        let errorMessage = "";
        if (error.status == 401) {
          errorMessage = "Nombre de usuario y/o contraseña invalidos";
        }
        else {
          errorMessage = error.message;
        }
        Swal.fire('Hubo un error al procesar solicitud', errorMessage, 'error');
      })

    }
    else {

      Object.keys(this.loginForm.controls).forEach(key => {
        this.loginForm.get(key).markAsDirty();
      });
    }


  }

  onKey(event: KeyboardEvent) {
    if (event.key === "Enter") {
      this.login();
    }

  }

}
