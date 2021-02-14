import { Component } from '@angular/core';
import { NavigationEnd, NavigationStart, Router, RouterEvent } from '@angular/router';
import Swal from 'sweetalert2';
import { AppCookieService } from './services/app-cookie.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'solicitudAyudasClient';
  showNav = false;

  cerrarSesion(){
    Swal.fire({
      title:'Cerrar sesión', 
      text:'Seguro que desea cerrar sesión?', 
      icon:'warning',
      showConfirmButton: true,
      confirmButtonText: 'Cerrar Sesión',
      showCancelButton: true,
      cancelButtonText: 'Cancelar'
    }).then(dialogResult => {
      if(dialogResult.isConfirmed){
        this.cookieService.remove('token');
        this.showNav = false;
        this.router.navigate(['/login']);
      }
      else{
        console.log('nope')
      }
    })
  }

  constructor(private router: Router, private cookieService:AppCookieService)
  {
    this.router.events.subscribe(routerEvent => {
      if(routerEvent instanceof NavigationEnd && this.router.url !== '/login'){
        this.showNav = true;
      }
    })
  }
}
