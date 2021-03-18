import { Component } from '@angular/core';
import { NavigationEnd, NavigationStart, Router, RouterEvent } from '@angular/router';
import Swal from 'sweetalert2';
import { AppCookieService } from './services/app-cookie.service';
import { DataService } from './services/data.service';

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
        this.showNav = false;
        this.dataService.CerrarSesion();
       
        this.router.navigate(['/login']);
      }
      else{
        console.log('nope')
      }
    })
  }

  ngOnInit(){
    this.usuario = JSON.parse(localStorage.getItem('usuario'));

    this.router.events.subscribe(ev => {
      if(ev instanceof NavigationEnd){
        console.log(ev);
        this.activatedRoute = ev.url;
      }
    })

    this.dataService.showNav.subscribe(showOrNot => {
      this.showNav = showOrNot;
    })

  }
  
  GetActive(){
  
  }

  constructor(private router: Router, 
    private cookieService:AppCookieService, private dataService:DataService)
  {

    dataService.userLogedIn.subscribe(user => {
      this.usuario = user;
    })

  }
}
