import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY } from 'rxjs';
import { map, mergeMap, catchError, tap } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { AppCookieService } from '../services/app-cookie.service';
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

      return ({ type: 'NO_ACTION' })
    }),
  )
  );

  SignIn$ = createEffect(() => this.actions$.pipe(
    ofType(LoginActions.login),
    map((payload) => {
      this.cookieService.set("usuario", JSON.stringify(payload.usuario));
      this.router.navigateByUrl("/inicio");
      return ({ type: 'NO_ACTION' })
    }),
  )
  );

  constructor(
    private actions$: Actions,
    private cookieService: AppCookieService,
    private router: Router
  ) { }
}
