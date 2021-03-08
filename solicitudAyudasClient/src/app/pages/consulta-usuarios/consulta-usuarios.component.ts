import { Component, OnInit } from '@angular/core';
import { FiltroDataUsuario } from 'src/app/model/FiltroDataUsuarios';
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

  usuarios:Array<any> = [];

  ngOnInit() {
    this.filtro.Page = 1;
    this.filtro.ItemsPerPage = 20;
    this.filtro.SearchText = '';
    this.Search();

  }

  Search(){
    this.cargando = true;
    this.dataService.GetUsuariosConsulta(this.filtro).subscribe(response => {
      this.filtro.TotalItems = response.data.totalItems
      this.usuarios = response.data.data;
      this.cargando = false
    }, error => {
      Swal.fire('Error', 'Hubo un error al procesar solicitud', 'error');
      this.cargando = false;
    })
  }

  GetUl(list){
    return this.utils.GetUnorderedList(list);
  }

}
