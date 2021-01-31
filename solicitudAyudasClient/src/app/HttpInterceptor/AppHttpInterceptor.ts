import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";


export class AppHttpInterceptor implements HttpInterceptor{
    
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        const token = 'Bearer 123456';
        let Authorization = token;

        return next.handle(req.clone({ setHeaders: { Authorization } }));
    }

}