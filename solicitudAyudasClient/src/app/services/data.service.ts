import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { AppLocalStorageService } from './app-local-storage.service';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  downLoadFile(data: any, type: string) {
    let blob = new Blob([data], { type: type });
    let url = window.URL.createObjectURL(blob);
    let pwa = window.open(url);
    if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
      alert('Please disable your Pop-up blocker and try again.');
    }
  }

  Download(fileId: number): Observable<any> {
    let url = `${environment.baseUrl}/files/download?id=${fileId}`;
    return this.http.get(url, {responseType: 'arraybuffer'});
  }
  CrearSolicitud(formData): Observable<any> {
    return this.http.post(this.GetUrl('Solicitud/post'), formData)
  }

  baseUrl = environment.baseUrl;

  GetUrl(endPoint) {
    return `${this.baseUrl}/${endPoint}`
  }

  GetDetalleSolicitud(solicitudId): Observable<any> {
    let url = this.GetUrl(`Solicitud/detalle?solicitudId=${solicitudId}`);
    return this.http.get(url);
  }

  GetTiposSolicitudesConRequisitos(): Observable<any> {
    return this.http.get(this.GetUrl('TipoSolicitud/ConRequisitos'));
  }

  GetSeccionales(): Observable<any> {
    var seccionales = this.localStorageService.GetSeccionales();

    if (seccionales) {
      return new Observable((observer) => {
        observer.next(seccionales);
        observer.complete();
      })
    }
    else {
      return this.UpdateAndGetSeccionales();
    }

  }

  UpdateAndGetSeccionales(): Observable<any> {
    var observable = new Observable(observer => {
      this.http.get(this.GetUrl('seccionales')).subscribe(response => {
        this.localStorageService.SaveSeccionales(response);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error)
      });
    });


    return observable;

  }

  Login(usuario: string, password: string): Observable<any> {
    return this.http.post(this.GetUrl('Account'), {
      Login: usuario,
      Password: password
    });
  }


  constructor(private http: HttpClient, private localStorageService: AppLocalStorageService) { }
}
