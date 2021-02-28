import { Injectable } from '@angular/core';
import { HttpClient, JsonpClientBackend } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { AppLocalStorageService } from './app-local-storage.service';
import { environment } from '../../environments/environment';
import { FiltroData } from '../model/FiltroData';
import { AppCookieService } from './app-cookie.service';
import { FormatWidth } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  GetMaestro(cedula: any):Observable<any> {
    let url = this.GetUrl(`Maestros/porcedula?cedula=${cedula}`)
    
    return this.http.get(url);
  }
  
  ResumenSolicitudesAprobadoPorSucursal(desde: Date, hasta: Date, seccionalId:number) {
    this.cargandoReporte.next(true);
    let url = this.GetUrl('reportes/ResumenSolicitudesAprobadasPorSeccional')
    
    this.http.post(url, {desde, hasta, seccionalId}, {responseType: 'arraybuffer'}).subscribe(file => {
      this.downLoadFile(file, 'application/pdf');
      this.cargandoReporte.next(false);
    }, error => {
      this.cargandoReporte.next(false);
    })
  }
  
  cargandoReporte = new Subject<boolean>();

  ResumenSolicitudesPorSucursal(desde: Date, hasta: Date) {

    this.cargandoReporte.next(true);
    let url = this.GetUrl('reportes/ResumenSolicitudesPorSeccional')
    
    this.http.post(url, {desde, hasta}, {responseType: 'arraybuffer'}).subscribe(file => {
      this.downLoadFile(file, 'application/pdf');
      this.cargandoReporte.next(false);
    }, error => {
      this.cargandoReporte.next(false);
    })
  }

  downLoadFile(data: any, type: string) {
    let blob = new Blob([data], { type: type });
    let url = window.URL.createObjectURL(blob);
    let pwa = window.open(url);
    if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
      alert('Please disable your Pop-up blocker and try again.');
    }
  }
  
  GetHeadersForGetch(){
    return { 'Authorization': `Bearer ${this.cookieService.get('token')}`, 
    'Access-Control-Allow-Origin': '*'}
  }

  EjecutarAccionSolicitud(solicitudId: number, estadoId:number, comentario:string) {
    let headers = this.GetHeadersForGetch();

    let form = new FormData();
    form.append('solicitudId', solicitudId.toString());
    form.append('estadoId', estadoId.toString());
    form.append('comentario', comentario);

    let url = this.GetUrl(`Solicitud/AprobarSolicitud`);
    
    return fetch(url, {
      method:'POST',
      headers: headers,
      body: form,
    });

  }

  PuedeGestionarTipoSolicitud(tipoSolicitudId):Observable<any> {
    let url = this.GetUrl(`Account/GetPuedeGestionarTipoSolicitud?tipoSolicitudId=${tipoSolicitudId}`);
    return this.http.get(url);
  }



  ConsultaSolicitudes(filtro: FiltroData):Observable<any> {
    let url = this.GetUrl('Solicitud/paginada');
    return this.http.post(url, filtro);
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


  constructor(private http: HttpClient, 
    private localStorageService: AppLocalStorageService,
    private cookieService:AppCookieService) { }
}
