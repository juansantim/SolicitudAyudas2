import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PermisoUsuarioDTO } from 'src/app/model/PermisoUsuarioDTO';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-permisos-usuario',
  templateUrl: './permisos-usuario.component.html',
  styleUrls: ['./permisos-usuario.component.css']
})
export class PermisosUsuarioComponent implements OnInit {

  cargando:boolean;  
  permisos:Array<PermisoUsuarioDTO> = []

  @Output() 
  onPermisosChanged: EventEmitter<Array<PermisoUsuarioDTO>> = new EventEmitter();

  change(){
    this.onPermisosChanged.emit(this.permisos);
  }

  constructor(private dataService:DataService) { }

  ngOnInit() {
    this.cargando= true;
    this.dataService.userUserLoaded.subscribe(userId => {
      this.dataService.GetPermisosUsuario(userId).subscribe(response => {
        this.permisos = response.data;
      })

      this.cargando= false;
    })
  }

}
