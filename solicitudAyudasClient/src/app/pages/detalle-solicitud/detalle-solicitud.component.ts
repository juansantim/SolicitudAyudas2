import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-detalle-solicitud',
  templateUrl: './detalle-solicitud.component.html',
  styleUrls: ['./detalle-solicitud.component.css']
})
export class DetalleSolicitudComponent implements OnInit {

  solicitud: any = {};
  cargandoSolicitud = false;

  constructor(private route: ActivatedRoute, 
    private dataService: DataService) { }

  ngOnInit() {
    const routeParams = this.route.snapshot.paramMap;
    const solicitudId = Number(routeParams.get('solicitudId'));

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
    if(requisito.value == 'true'){
      return "SI"      
    }

    if(requisito.value == 'false'){
      return "NO"      
    }

    return requisito.value;


  }

}
