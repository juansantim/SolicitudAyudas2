import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AppCookieService } from "../services/app-cookie.service";
import { DataService } from "../services/data.service";


@Injectable()
export class AppHttpInterceptor implements HttpInterceptor{

    constructor(private cookieService:AppCookieService, private dataService:DataService){

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const userCredentias = this.dataService.GetUserCredentials()
        let Authorization = `Bearer ${userCredentias?.Token}`;

        return next.handle(req.clone({ setHeaders: { Authorization } }));
    }

}
