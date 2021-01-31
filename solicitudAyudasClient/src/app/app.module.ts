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
import { FormsModule } from '@angular/forms';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import {HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    InicioComponent,
    RegistroSolicitudComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,    
    BrowserAnimationsModule,
    FormsModule,
    TypeaheadModule.forRoot(),
    HttpClientModule
  ],
  providers: [
    AuthGuardDefault,
    { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
