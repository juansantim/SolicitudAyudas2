import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { InicioComponent } from './pages/inicio/inicio.component';
import { RegistroSolicitudComponent } from './pages/registro-solicitud/registro-solicitud.component';
import { AuthGuardDefault } from './security/AuthGuardDefault'
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppHttpInterceptor } from './HttpInterceptor/AppHttpInterceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import { HttpClientModule } from '@angular/common/http';
import { LoadingComponent } from './common/loading/loading.component';
import { EstadisticasComponent } from './pages/estadisticas/estadisticas.component';

import { NgxMaskModule, IConfig } from 'ngx-mask';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { FileUploaderComponent } from './common/file-uploader/file-uploader.component'

export const options: Partial<IConfig> | (() => Partial<IConfig>) = null;

import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { AlertModule } from 'ngx-bootstrap/alert';
import { ValidationErrorMessageComponent } from './common/validation-error-message/validation-error-message.component';
import { DetalleSolicitudComponent } from './pages/detalle-solicitud/detalle-solicitud.component';
import { EstadoSolicitudComponent } from './pages/detalle-solicitud/estado-solicitud/estado-solicitud.component';
import { UnavailableComponent } from './pages/unavailable/unavailable.component';
import { ConsultaComponent } from './pages/consulta/consulta.component';
import { DownloableFileComponent } from './common/downloable-file/downloable-file.component';
import { FiltroComponent } from './pages/consulta/filtro/filtro.component';
import { PaginationComponent } from './pages/consulta/pagination/pagination.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { SelectedFilterComponent } from './pages/consulta/filtro/selected-filter/selected-filter.component';
import { AccionesComponent } from './pages/detalle-solicitud/acciones/acciones.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { ResumenSolicitadoPorSucursalComponent } from './pages/estadisticas/resumen-solicitado-por-sucursal/resumen-solicitado-por-sucursal.component';
import { ResumenAprobadoPorSeccionalComponent } from './pages/estadisticas/resumen-aprobado-por-seccional/resumen-aprobado-por-seccional.component';
import { SeccionalComponent } from './common/seccional/seccional.component';
import { ProcesarSolicitudComponent } from './pages/detalle-solicitud/procesar-solicitud/procesar-solicitud.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { RegistrarUsuarioComponent } from './pages/registrar-usuario/registrar-usuario.component';
import { ConsultaUsuariosComponent } from './pages/consulta-usuarios/consulta-usuarios.component';
import { PermisosUsuarioComponent } from './pages/registrar-usuario/permisos-usuario/permisos-usuario.component';
import { ComisionesAprobacionUsuarioComponent } from './pages/registrar-usuario/comisiones-aprobacion-usuario/comisiones-aprobacion-usuario.component';
import { ActivarUsuarioComponent } from './pages/activar-usuario/activar-usuario.component';
import { EditarSolicitudComponent } from './pages/editar-solicitud/editar-solicitud.component';
import { UnAuthorizedComponent } from './pages/un-authorized/un-authorized.component';
import { StoreModule } from '@ngrx/store';
import { AuthReducer } from './store/app.auth.reducers';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { EffectsModule } from '@ngrx/effects';
import { AuthEffects } from './store/app.auth.effects';
import { SeccionalesReducer } from './store/seccionales/app.seccionales.reducer';
import { SeccionalesEffects } from './store/seccionales/app.seccionales.effects';
import { EntityDataModule, EntityDataService, EntityDefinitionService, EntityMetadataMap } from '@ngrx/data';
import { SolicitudDataService } from './services/StoreEntityServices/solicitud-data.service';
import { SolicitudEntityService } from './services/StoreEntityServices/solicitud-entity.service';
import { ConsultaReducer } from './store/ConsultaSolicitudes/consulta-solicitudes.reducers';
import { ConsultaEffects } from './store/ConsultaSolicitudes/consulta-solicitudes.effects';
import { SolicitudAyuda } from './model/Solicitud/solicitudAyuda';
import { SubTiposSolicitudesPipe } from './model/PipeFilters/SubTiposSolicitudesFilter';
//import { entityConfig } from './entity-metadata';

const entityMetaData: EntityMetadataMap = {
  Solicitud: {
    selectId: (solicitud:SolicitudAyuda) => solicitud.Id
  }
}


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    InicioComponent,
    RegistroSolicitudComponent,
    LoadingComponent,
    EstadisticasComponent,
    FileUploaderComponent,
    ValidationErrorMessageComponent,
    DetalleSolicitudComponent,
    EstadoSolicitudComponent,
    UnavailableComponent,
    ConsultaComponent,
    DownloableFileComponent,
    FiltroComponent,
    PaginationComponent,
    SelectedFilterComponent,
    AccionesComponent,
    ResumenSolicitadoPorSucursalComponent,
    ResumenAprobadoPorSeccionalComponent,
    SeccionalComponent,
    ProcesarSolicitudComponent,
    RegistrarUsuarioComponent,
    ConsultaUsuariosComponent,
    PermisosUsuarioComponent,
    ComisionesAprobacionUsuarioComponent,
    ActivarUsuarioComponent,
    EditarSolicitudComponent,
    UnAuthorizedComponent,
    SubTiposSolicitudesPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    TypeaheadModule.forRoot(),
    HttpClientModule,
    NgxMaskModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ReactiveFormsModule,
    AlertModule.forRoot(),
    PaginationModule.forRoot(),
    CollapseModule.forRoot(),
    AccordionModule.forRoot(),
    ModalModule.forRoot(),
    StoreModule.forRoot({ auth: AuthReducer, seccionales: SeccionalesReducer, consulta: ConsultaReducer }),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: environment.production }),
    EffectsModule.forRoot([AuthEffects, SeccionalesEffects, ConsultaEffects]),
    EntityDataModule.forRoot({ entityMetadata: entityMetaData }),
    //EntityDataModule.forRoot(entityConfig)
  ],
  entryComponents: [ProcesarSolicitudComponent],
  providers: [
    AuthGuardDefault,
    { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true },
    SolicitudEntityService,
    SolicitudDataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private eds: EntityDefinitionService, 
    private entityDataService:EntityDataService, 
    solicitudDataService:SolicitudDataService) {
      
      eds.registerMetadataMap(entityMetaData);
      entityDataService.registerService("Solicitud", solicitudDataService)
  }
 }
