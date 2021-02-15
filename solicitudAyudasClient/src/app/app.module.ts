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
import {HttpClientModule } from '@angular/common/http';
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
    EstadoSolicitudComponent
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
    AlertModule.forRoot()
  ],
  providers: [
    
    AuthGuardDefault,
    { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
