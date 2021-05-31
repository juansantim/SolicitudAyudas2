import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { EMPTY } from 'rxjs';
import { catchError, first, map, shareReplay, tap } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { LoginModel } from '../model/LoginModel';
import { UserProfile } from '../model/UserProfile';
import { AppCookieService } from '../services/app-cookie.service';
import { DataService } from '../services/data.service';
import { LoginActions } from '../store/app.actions.types';
import { AppAuthState } from '../store/app.auth.reducers';

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
    private store: Store<AppAuthState>) {

  }

  ngOnInit() {

    if (this.cookieService.get('token')) {
      this.router.navigate(['/inicio']);
      this.dataService.showNav.next(true);
    }
  }

  login() {

    if (this.loginForm.valid) {

      let { usuario, password } = this.loginForm.value;

      this.cargando = true;

      this.dataService.Login(usuario, password).pipe(
        map(response => {
          const user = {
            email: response.email,
            token: response.token,
            nombreCompleto: response.nombreCompleto,
            seccional: response.seccional
          } as UserProfile
          return user;
        }),
        first(),
        catchError(err => {
          Swal.fire("Error al iniciar sesion", "Nombre de usuario o clave incorrectas", 'error');
          this.cargando = false;
          return EMPTY
        }),
        map(usr => this.store.dispatch(LoginActions.login({ usuario: usr }))),
        tap(() => this.cargando = false),
      ).subscribe();

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
