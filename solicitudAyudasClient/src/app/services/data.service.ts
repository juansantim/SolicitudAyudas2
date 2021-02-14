import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { AppLocalStorageService } from './app-local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  GetDetalleSolicitud(solicitudId):Observable<any> {
    return this.http.get(`/api/Solicitud/detalle?solicitudId=${solicitudId}`)
  }
  GetTiposSolicitudesConRequisitos():Observable<any> {
    return this.http.get('/api/TipoSolicitud/ConRequisitos');
  }
  
  

  GetSeccionales():Observable<any> {
    var seccionales = this.localStorageService.GetSeccionales();

    if(seccionales){
      return new Observable((observer) => {
        observer.next(seccionales);
        observer.complete();
      })
    }
    else{
      return this.UpdateAndGetSeccionales();
    }
    
  }
  
  UpdateAndGetSeccionales(): Observable<any>{
    var observable = new Observable(observer => {
      this.http.get('/api/seccionales').subscribe(response => {
        this.localStorageService.SaveSeccionales(response);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error)
      });      
    });


    return observable;
    
  }

  Login(usuario:string, password:string): Observable<any>{
    return this.http.post('/api/Account', {
      Login: usuario,
      Password: password
    });
  }


  constructor(private http:HttpClient, private localStorageService:AppLocalStorageService) { }
}
