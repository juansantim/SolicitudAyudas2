import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SolicitudAyuda } from 'src/app/model/Solicitud/solicitudAyuda';
import { DataService } from 'src/app/services/data.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-detalle-solicitud',
  templateUrl: './detalle-solicitud.component.html',
  styleUrls: ['./detalle-solicitud.component.css']
})
export class DetalleSolicitudComponent implements OnInit {

  solicitud: SolicitudAyuda;
  cargandoSolicitud = false;

  constructor(private route: ActivatedRoute, 
    private dataService: DataService) { }

  ngOnInit() {
    const routeParams = this.route.snapshot.paramMap;
    const solicitudId = Number(routeParams.get('solicitudId'));
    this.cargarSolictud(solicitudId);

    this.dataService.ReloadSolicitud.subscribe(solicitudId => {
      this.cargarSolictud(solicitudId);
    }) 
  }

  cargarSolictud(solicitudId){
    if (solicitudId) {
      this.cargandoSolicitud = true;
      this.dataService.GetDetalleSolicitud(solicitudId).subscribe(data =>{
        this.solicitud = data;
        this.cargandoSolicitud = false;
      }, error => {
        this.cargandoSolicitud = false;
        Swal.fire('No se pudo procesar solicitud', 'Error al buscar detalles de solicitud', 'error');
      });

    }
    else {
      console.log('No value')
    }
  }

  getValorRequisito(requisito){
    if(requisito.Value == 'true'){
      return "SI"      
    }

    if(requisito.Value == 'false'){
      return "NO"      
    }

    return requisito.Value;
  }

}