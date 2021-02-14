// src/app/auth/auth-guard.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import { AppCookieService } from '../services/app-cookie.service';

@Injectable()
export class AuthGuardDefault implements CanActivate {
  constructor(public router: Router, 
    private cookieService: AppCookieService, 
    private httpClient:HttpClient) { }
  
  // canActivate(): boolean {
  //   let canView = false;
  //   var token = this.cookieService.get('token');

  //   if (token) {
  //     canView = true;
  //   }

  //   if (canView) {
  //     return true;
  //   }
    
  //   this.router.navigate(['login']);
    
  //   return false;
  // }

  canActivate():Observable<boolean> {
    let result = new Observable<boolean>(observer => {
      let token = this.cookieService.get('token');

      this.httpClient.get('/api/Account/heartbeat', {
        headers: {
          Authorization: `Bearer ${token}`
        }
      }).subscribe(response => {
        observer.next(true);
        observer.complete();
      }, error => {
        observer.next(false);
        this.router.navigate(['login']);
      })

    });


    
    return result;

  }
  
}