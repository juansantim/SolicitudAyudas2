import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component'
import { InicioComponent } from './pages/inicio/inicio.component';
import { AuthGuardDefault } from './security/AuthGuardDefault'
import {RegistroSolicitudComponent} from './pages/registro-solicitud/registro-solicitud.component'
import { DetalleSolicitudComponent } from './pages/detalle-solicitud/detalle-solicitud.component';
import { UnavailableComponent } from './pages/unavailable/unavailable.component';
import { ConsultaComponent } from './pages/consulta/consulta.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'inicio', component: InicioComponent, canActivate: [AuthGuardDefault] },
  { path: 'registrarSolicitud', component: RegistroSolicitudComponent, canActivate: [AuthGuardDefault] },
  { path: 'detalle/:solicitudId', component: DetalleSolicitudComponent, canActivate: [AuthGuardDefault], },
  { path: 'servicionodisponible', component: UnavailableComponent }, 
  { path: 'consulta', component: ConsultaComponent, canActivate: [AuthGuardDefault] }, 
  { path: '', redirectTo: 'inicio', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
