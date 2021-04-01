import { Injectable } from '@angular/core';
import { HttpClient, JsonpClientBackend } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { AppLocalStorageService } from './app-local-storage.service';
import { environment } from '../../environments/environment';
import { FiltroData } from '../model/FiltroData';
import { AppCookieService } from './app-cookie.service';
import { FormatWidth } from '@angular/common';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AbstractControl, FormGroup } from '@angular/forms';
import { CreacionUsuarioDTO } from '../model/CreacionUsuarioDTO';
import { FiltroDataUsuario } from '../model/FiltroDataUsuarios';
import { SeccionalDTO } from '../model/SeccionalDTO';
import { BancoForSelectDTO } from '../model/BancoSelectDTO';
import { ActivacionUsuarioDTO } from '../model/ActivacionUsuarioDTO';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  Anular(solicitudId: number) {
    let url = this.GetUrl(`Solicitud/Anular?solicitudId=${solicitudId}`);
    return this.http.post(url, solicitudId);
  }
  GetPuedeModificarSolicitud() {
    let url = this.GetUrl('account/TienePermiso?permisoId=9');
    return this.http.get(url);
  }
  GetPermisosYComisiones():Observable<any> {
    let url = this.GetUrl('account/getPermisosYComisiones');    
    return this.http.get(url);
  }
  CerrarSesion() {
    this.cookieService.remove('token');
    localStorage.removeItem('usuario');
  }
  ActivarUsuario(usuario: ActivacionUsuarioDTO): Observable<any> {
    var url = this.GetUrl('account/ActivarUsuario');
    return this.http.post(url, usuario);
  }

  GetDatosParaActivacion(id: string, code:string): Observable<any> {
    let url:string
    if(code){
      url = this.GetUrl(`account/GetDatosResetPassword?usuarioId=${id}&changePasswordCode=${code}`);
    }
    else{
      url = this.GetUrl(`account/GetDatosActivacion?id=${id}`);  
    }
    

    return this.http.get<any>(url);
  }

  GetBancos(): Observable<Array<BancoForSelectDTO>> {
    let url = this.GetUrl('bancos');

    return this.http.get<Array<BancoForSelectDTO>>(url);
  }

  GetDetalleUsuario(usuarioId: any): Observable<any> {
    let url = this.GetUrl(`account/GetDetalleUsuario?usuarioId=${usuarioId}`);

    return this.http.get(url);
  }

  GetUsuariosConsulta(filtro: FiltroDataUsuario): Observable<any> {
    let url = this.GetUrl('account/consultaUsuarios');
    return this.http.post(url, filtro);
  }

  CrearUsuario(usuario: CreacionUsuarioDTO): Observable<any> {
    var url = this.GetUrl('account/CrearUsuario');
    return this.http.post(url, usuario);
  }
  GetUsuarioPorEmail(email: AbstractControl): Observable<any> {
    var url = this.GetUrl(`account/getUsuarioPorEmail?email=${email}`);
    return this.http.get(url);
  }

  ReloadSolicitud = new Subject<number>();
  cargandoReporte = new Subject<boolean>();
  userLogedIn = new Subject<any>();
  userUserLoaded = new Subject<number>();
  setSeccional = new Subject<SeccionalDTO>();
  showNav = new Subject<boolean>();

  ProcesarSolicitud(solicitudId: number, estadoId: number, comentario: string): Observable<any> {
    var url = this.GetUrl('solicitud/ProcesarSolicitud');

    let datosProcesamiento = {
      solicitudId, estadoId, comentario
    };
    return this.http.post(url, datosProcesamiento);
  }
  GetMaestro(cedula: any): Observable<any> {
    let url = this.GetUrl(`Maestros/porcedula?cedula=${cedula}`)

    return this.http.get(url);
  }

  ResumenSolicitudesAprobadoPorSucursal(desde: Date, hasta: Date, seccionalId: number) {
    this.cargandoReporte.next(true);
    let url = this.GetUrl('reportes/ResumenSolicitudesAprobadasPorSeccional')

    this.http.post(url, { desde, hasta, seccionalId }, { responseType: 'arraybuffer' }).subscribe(file => {
      this.downLoadFile(file, 'application/pdf');
      this.cargandoReporte.next(false);
    }, error => {
      this.cargandoReporte.next(false);
    })
  }

  ResumenSolicitudesPorSucursal(desde: Date, hasta: Date) {

    this.cargandoReporte.next(true);
    let url = this.GetUrl('reportes/ResumenSolicitudesPorSeccional')

    this.http.post(url, { desde, hasta }, { responseType: 'arraybuffer' }).subscribe(file => {
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

  GetHeadersForGetch() {
    return {
      'Authorization': `Bearer ${this.cookieService.get('token')}`,
      'Access-Control-Allow-Origin': '*'
    }
  }

  PuedeGestionarTipoSolicitud(tipoSolicitudId): Observable<any> {
    let url = this.GetUrl(`Account/GetPuedeGestionarTipoSolicitud?tipoSolicitudId=${tipoSolicitudId}`);
    return this.http.get(url);
  }

  ConsultaSolicitudes(filtro: FiltroData): Observable<any> {
    let url = this.GetUrl('Solicitud/paginada');
    return this.http.post(url, filtro);
  }

  Download(fileId: number): Observable<any> {
    let url = `${environment.baseUrl}/files/download?id=${fileId}`;
    return this.http.get(url, { responseType: 'arraybuffer' });
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

  GetErrors(formulario: FormGroup, fieldName: string, errorName: string) {
    var control = formulario.get(fieldName);

    if (control.pristine || !control.errors) {
      return false;
    }
    else {
      return control.errors[errorName];
    }

  }

  bsModalRef: BsModalRef;

  constructor(private http: HttpClient,
    private localStorageService: AppLocalStorageService,
    private cookieService: AppCookieService) { }
}
