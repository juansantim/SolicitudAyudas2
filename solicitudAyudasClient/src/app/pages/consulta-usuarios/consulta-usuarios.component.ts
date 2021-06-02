import { Component, OnInit } from '@angular/core';
import { FiltroDataUsuario } from 'src/app/model/FiltroDataUsuarios';
import { UsuarioForConsulta } from 'src/app/model/Usuarios/UsuarioForConsulta';
import { DataService } from 'src/app/services/data.service';
import { UtilsService } from 'src/app/services/utils.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-consulta-usuarios',
  templateUrl: './consulta-usuarios.component.html',
  styleUrls: ['./consulta-usuarios.component.css']
})
export class ConsultaUsuariosComponent implements OnInit {

  filtro:FiltroDataUsuario = new FiltroDataUsuario();
  constructor(private dataService:DataService, private utils:UtilsService) { }

  cargando: boolean;

  usuarios:UsuarioForConsulta[];

  ngOnInit() {
    this.filtro.Page = 1;
    this.filtro.ItemsPerPage = 20;
    this.filtro.SearchText = '';
    this.Search();

  }

  Search(){
    this.cargando = true;
    this.dataService.GetUsuariosConsulta(this.filtro).subscribe(response => {
      if(response.Success){
        this.usuarios = [];

        this.filtro.TotalItems = response.Data.TotalItems
        this.usuarios = response.Data.Data;
        this.cargando = false;
      
      }else{
        Swal.fire('Error', this.utils.GetUlList(response), 'error');  
      }
      
    }, error => {
      Swal.fire('Error', 'Hubo un error al procesar solicitud', 'error');
      this.cargando = false;
    })
  }

  GetUl(list){
    return this.utils.GetUnorderedList(list);
  }

}
