import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AppCookieService } from "../services/app-cookie.service";


@Injectable()
export class AppHttpInterceptor implements HttpInterceptor{
    
    constructor(private cookieService:AppCookieService){
        
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        let bearer = this.cookieService.get('token');

        const token = `Bearer ${bearer}`;
        let Authorization = token;

        return next.handle(req.clone({ setHeaders: { Authorization } }));
    }

}