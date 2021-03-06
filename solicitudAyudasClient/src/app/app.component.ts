import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';
import { UserProfile } from './model/UserProfile';
import { AppCookieService } from './services/app-cookie.service';
import { DataService } from './services/data.service';
import { LoginActions } from './store/app.actions.types';
import { AppAuthState } from './store/app.auth.reducers';
import { isLoggedIn, userProfile } from './store/app.selectors';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'solicitudAyudasClient';
  showNav = true;
  usuario:any;
  activatedRoute:string;

  loggedIn$: Observable<boolean>;
  userProfile$: Observable<UserProfile>;

  cerrarSesion(){
    Swal.fire({
      title:'Cerrar sesión',
      text:'Seguro que desea cerrar sesión?',
      icon:'warning',
      showConfirmButton: true,
      confirmButtonText: 'Cerrar Sesión',
      confirmButtonColor:'red',
      showCancelButton: true,
      cancelButtonText: 'Cancelar'
    }).then(dialogResult => {
      if(dialogResult.isConfirmed){

        this.store.dispatch(LoginActions.logOut());
      }
      else{
        console.log('nope')
      }
    })
  }

  ngOnInit(){

    const usuario:UserProfile = JSON.parse(this.cookieService.get("usuario"));

    if(usuario){
      this.store.dispatch(LoginActions.userLogedIn({usuario}));
    }
    else{
      this.store.dispatch(LoginActions.logOut());
    }

    this.loggedIn$ = this.store.pipe(
      select(isLoggedIn)
    );

    this.userProfile$ = this.store.pipe(
      select(userProfile)
    );
    
  }

  GetActive(){

  }

  constructor(private router: Router,
    private cookieService:AppCookieService,
    private dataService:DataService,
    private store:Store<AppAuthState>)
  {


  }
}
