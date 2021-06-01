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
import { ActivacionUsuarioDTO } from '../model/ActivacionUsuarioDTO';
import { AppAuthState } from '../store/app.auth.reducers';
import { Store } from '@ngrx/store';
import { UserProfile } from '../model/UserProfile';
import { PaginatedResult } from '../model/ConsultaSolicitudes/PaginatedResult';
import { ItemModel } from '../model/itemModel';
import { LoginModel } from '../model/LoginModel';
import { SolicitudAyuda } from '../model/Solicitud/solicitudAyuda';
import { TipoSolicitud } from '../model/Solicitud/TipoSolicitud';
@Injectable({
  providedIn: 'root'
})
export class DataService {

  CheckToken() {
    const url = this.GetUrl('Account/heartbeat');
    return this.http.get(url);
  }

  GetUserCredentials(): UserProfile {
    return JSON.parse(this.cookieService.get("usuario"));
  }

  Anular(solicitudId: number) {
    let url = this.GetUrl(`Solicitud/Anular?solicitudId=${solicitudId}`);
    return this.http.post(url, solicitudId);
  }

  GetPuedeModificarSolicitud() {
    let url = this.GetUrl('account/TienePermiso?permisoId=9');
    return this.http.get(url);
  }

  GetPermisosYComisiones(): Observable<any> {
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

  GetDatosParaActivacion(id: string, code: string): Observable<any> {
    let url: string
    if (code) {
      url = this.GetUrl(`account/GetDatosResetPassword?usuarioId=${id}&changePasswordCode=${code}`);
    }
    else {
      url = this.GetUrl(`account/GetDatosActivacion?id=${id}`);
    }


    return this.http.get<any>(url);
  }

  GetBancos(): Observable<Array<ItemModel>> {
    let url = this.GetUrl('bancos');

    return this.http.get<Array<ItemModel>>(url);
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

  ConsultaSolicitudes(filtro: FiltroData): Observable<PaginatedResult<SolicitudAyuda>> {
    let url = this.GetUrl('Solicitud/paginada');

    return this.http.post<PaginatedResult<SolicitudAyuda>>(url, filtro);
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

  GetTiposSolicitudesConRequisitos(): Observable<TipoSolicitud[]> {
    return this.http.get<TipoSolicitud[]>(this.GetUrl('TipoSolicitud/ConRequisitos'));
  }

  GetSeccionales(): Observable<Array<ItemModel>> {
    var seccionales = this.localStorageService.GetSeccionales();

    return this.http.get<Array<ItemModel>>(this.GetUrl('seccionales'));
  }


  userSpace: string = 'usuario';

  Login(loginModel:LoginModel): Observable<UserProfile> {
    return this.http.post<UserProfile>(this.GetUrl('Account'), {
      Login: loginModel.usuario,
      Password: loginModel.password
    });
  }

  LogOut() {
    this.cookieService.remove(this.userSpace)
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
    private cookieService: AppCookieService,
    private store: Store<AppAuthState>) {

  }
}
