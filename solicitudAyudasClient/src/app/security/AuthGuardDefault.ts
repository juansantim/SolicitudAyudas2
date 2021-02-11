// src/app/auth/auth-guard.service.ts
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AppCookieService } from '../services/app-cookie.service';

@Injectable()
export class AuthGuardDefault implements CanActivate {
  constructor(public router: Router, private cookieService:AppCookieService) {}
  canActivate(): boolean {
      let canView = false;
      var token = this.cookieService.get('token');
      
      if(token){
        canView = true;
      }
    
    if (canView) {
        return true;
    }
    this.router.navigate(['login']);
   return false;
  }
}