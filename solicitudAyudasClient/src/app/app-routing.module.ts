import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component'
import { InicioComponent } from './pages/inicio/inicio.component';
import { AuthGuardDefault } from './security/AuthGuardDefault'
import {RegistroSolicitudComponent} from './pages/registro-solicitud/registro-solicitud.component'
import { DetalleSolicitudComponent } from './pages/detalle-solicitud/detalle-solicitud.component';
import { UnavailableComponent } from './pages/unavailable/unavailable.component';
import { ConsultaComponent } from './pages/consulta/consulta.component';
import { EstadisticasComponent } from './pages/estadisticas/estadisticas.component';
import { RegistrarUsuarioComponent } from './pages/registrar-usuario/registrar-usuario.component';
import { ConsultaUsuariosComponent } from './pages/consulta-usuarios/consulta-usuarios.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'inicio', component: InicioComponent, canActivate: [AuthGuardDefault] },
  { path: 'registrarSolicitud', component: RegistroSolicitudComponent, canActivate: [AuthGuardDefault] },
  { path: 'detalle/:solicitudId', component: DetalleSolicitudComponent, canActivate: [AuthGuardDefault], },
  { path: 'servicionodisponible', component: UnavailableComponent }, 
  { path: 'consulta', component: ConsultaComponent, canActivate: [AuthGuardDefault] }, 
  { path: 'estadisticas', component: EstadisticasComponent, canActivate: [AuthGuardDefault] },
  { path: 'modificarusuario/:usuarioId', component: RegistrarUsuarioComponent, canActivate: [AuthGuardDefault] },
  { path: 'registrarusuario', component: RegistrarUsuarioComponent, canActivate: [AuthGuardDefault] },
  { path: 'consultausuarios', component: ConsultaUsuariosComponent, canActivate: [AuthGuardDefault] },
  { path: '', redirectTo: 'inicio', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
