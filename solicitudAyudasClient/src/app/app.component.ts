import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';
import { UserData } from './model/UserData';
import { AppCookieService } from './services/app-cookie.service';
import { DataService } from './services/data.service';
import { LoginActions } from './store/app.actions.types';
import { AppState } from './store/store';
import { isLoggedIn } from './store/app.selectors';

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
        // this.showNav = false;
        // this.dataService.CerrarSesion();
        // this.router.navigate(['/login']);

        this.store.dispatch(LoginActions.logOut());
      }
      else{
        console.log('nope')
      }
    })
  }

  ngOnInit(){

    const usuario:UserData = JSON.parse(this.cookieService.get("usuario"));

    if(usuario){
      this.store.dispatch(LoginActions.pageReloadedLoggedIn({usuario}));
    }

    // this.usuario = JSON.parse(localStorage.getItem('usuario'));

    // this.router.events.subscribe(ev => {
    //   if(ev instanceof NavigationEnd){
    //     console.log(ev);
    //     this.activatedRoute = ev.url;
    //   }
    // })

    // this.dataService.showNav.subscribe(showOrNot => {
    //   this.showNav = showOrNot;
    // })

    this.loggedIn$ = this.store.pipe(
      select(isLoggedIn)
    )

  }
  
  GetActive(){
  
  }

  constructor(private router: Router, 
    private cookieService:AppCookieService, 
    private dataService:DataService,
    private store:Store<AppState>)
  {


  }
}
