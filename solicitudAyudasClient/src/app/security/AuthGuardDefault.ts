// src/app/auth/auth-guard.service.ts
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

@Injectable()
export class AuthGuardDefault implements CanActivate {
  constructor(public router: Router) {}
  canActivate(): boolean {
      let canView = true;

    if (canView) {
        return true;
    }
    this.router.navigate(['login']);
   return false;
  }
}