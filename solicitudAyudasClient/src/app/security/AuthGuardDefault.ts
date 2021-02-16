// src/app/auth/auth-guard.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import { AppCookieService } from '../services/app-cookie.service';
import { DataService } from '../services/data.service';

@Injectable()
export class AuthGuardDefault implements CanActivate {
  constructor(public router: Router, 
    private cookieService: AppCookieService, 
    private httpClient:HttpClient,
    private dataService: DataService) { }
  
  canActivate():Observable<boolean> {
    let result = new Observable<boolean>(observer => {
      let token = this.cookieService.get('token');

      this.httpClient.get(this.dataService.GetUrl('Account/heartbeat'), {
        headers: {
          Authorization: `Bearer ${token}`
        }
      }).subscribe(response => {
        observer.next(true);
        observer.complete();
      }, error => {
        console.log(error);
        if(error.status == 401){
          observer.next(false);
          this.cookieService.remove('token');
          this.router.navigate(['login']);
        }
        if(error.status == 0){
          this.router.navigate(['servicionodisponible']);
        }
      })

    });


    
    return result;

  }
  
}