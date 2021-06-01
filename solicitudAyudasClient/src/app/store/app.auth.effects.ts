import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common'
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { map, mergeMap, catchError, tap, switchMap } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { AppCookieService } from '../services/app-cookie.service';
import { DataService } from '../services/data.service';
import { LoginActions } from './app.actions.types';

@Injectable()
export class AuthEffects {

  SignOut$ = createEffect(() => this.actions$.pipe(
    ofType(LoginActions.pageReloadedLogedOutIn, LoginActions.logOut, LoginActions.AuthGuardlogOut),
    map(action => {
      this.cookieService.remove("usuario");
      this.router.navigateByUrl("/login");

      if (action.type === "[Default Auth Guard] Cerrar Sesion")
        Swal.fire("Tiempo de sesión agotado", "Tiempo de inicio de sesión agotado, favor iniciar sesión nuevamente", "warning");

      return ({ type: 'REDIRECT_TO_LOGIN' })
    }),
  ));

  StartLogin$ = createEffect(() => this.actions$.pipe(
    ofType(LoginActions.loginStarted),
    mergeMap(action => this.dataService.Login(action.usuario).pipe(
      catchError(err => of(null)),
      map(usuario => {
        if (usuario) {
          return LoginActions.userLogedIn({ usuario })
        }
        else {
          return LoginActions.loginFail()
        }
      }),

    ))
  ));

  SignIn$ = createEffect(() => this.actions$.pipe(
    ofType(LoginActions.userLogedIn),
    map((action) => {
      this.cookieService.set("usuario", JSON.stringify(action.usuario));

      if (window.location.href.endsWith("/login"))
        this.router.navigateByUrl("/inicio");
    }),
  ), { dispatch: false });

  LoginFailed$ = createEffect(() => this.actions$.pipe(
    ofType(LoginActions.loginFail),
    map((action) => {
      Swal.fire("Error al iniciar sesión", "Favor verificar nombre de usuario y/o contraseña.", "error")
    }),
  ), {
    dispatch: false
  });

  constructor(
    private actions$: Actions,
    private cookieService: AppCookieService,
    private router: Router,    
    private dataService: DataService
  ) { }
}
