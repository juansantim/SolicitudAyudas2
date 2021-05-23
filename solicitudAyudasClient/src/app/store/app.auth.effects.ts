import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY } from 'rxjs';
import { map, mergeMap, catchError, tap } from 'rxjs/operators';
import { AppCookieService } from '../services/app-cookie.service';
import { LoginActions } from './app.actions.types';

@Injectable()
export class AuthEffects {

  SignOut$ = createEffect(() => this.actions$.pipe(
    ofType('[Main Menu] Page Realoaded LoggedOut', '[Main Menu] Cerrar Sesion'),
    map(() => {
      this.cookieService.remove("usuario");
      this.router.navigateByUrl("/login");
      return ({ type: 'NO_ACTION' })}),
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
