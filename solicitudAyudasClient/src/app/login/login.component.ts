import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { EMPTY, Observable } from 'rxjs';
import { catchError, first, map, shareReplay, tap } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { LoginModel } from '../model/LoginModel';
import { UserProfile } from '../model/UserProfile';
import { AppCookieService } from '../services/app-cookie.service';
import { DataService } from '../services/data.service';
import { LoginActions } from '../store/app.actions.types';
import { AppAuthState } from '../store/app.auth.reducers';
import { iniciandoSesion } from '../store/app.selectors';

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

  cargando$: Observable<boolean>;

  constructor(private router: Router,
    private dataService: DataService,
    private cookieService: AppCookieService,
    private store: Store<AppAuthState>) {

  }

  ngOnInit() {

    this.store.pipe(
      tap(state => {
        if (state.usuario) {
          this.router.navigate(['/inicio']);
        }
      })
    )

    this.cargando$ = this.store.pipe(
      select(iniciandoSesion)
    )
  }

  login() {

    if (this.loginForm.valid) {

      const loginModel: LoginModel = this.loginForm.value;
      this.store.dispatch(LoginActions.loginStarted({ usuario: loginModel }))
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
