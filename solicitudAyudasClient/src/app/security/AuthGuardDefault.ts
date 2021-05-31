// src/app/auth/auth-guard.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { catchError, map, mergeMap, tap } from 'rxjs/operators';
import { UserProfile } from '../model/UserProfile';
import { AppCookieService } from '../services/app-cookie.service';
import { DataService } from '../services/data.service';
import { LoginActions } from '../store/app.actions.types';
import { AppState } from '../store/store';

@Injectable()
export class AuthGuardDefault implements CanActivate {

  token: string;

  constructor(public router: Router,
    private cookieService: AppCookieService,
    private dataService: DataService,
    private store: Store<AppState>) {


  }

  canActivate(): Observable<boolean> {

    return this.dataService.CheckToken().pipe(
      map(response => true),
      catchError(err => of(false)),
      tap(isTokenValid => { 
        if (!isTokenValid) {
          this.store.dispatch(LoginActions.AuthGuardlogOut());          
        }         
      })
    )
  }

}
