import { Component, Input, OnInit } from '@angular/core';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { DataService } from 'src/app/services/data.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-acciones',
  templateUrl: './acciones.component.html',
  styleUrls: ['./acciones.component.css']
})
export class AccionesComponent implements OnInit {

  @Input()
  tipoSolicitudAyuda:string;

  @Input()
  solicitudId:number;

  loading:boolean;

  constructor(private dataService:DataService) { }

  puedeGestionar:boolean;

  ngOnInit() {
    // console.log(this.tipoSolicitudAyuda);
    this.dataService.PuedeGestionarTipoSolicitud(this.tipoSolicitudAyuda).subscribe(response => {
      this.puedeGestionar = response.puedeGestionar      
    })
  }

  AprobarSoliciud(){

    Swal.fire('Confirmación', 'Esta Seguro que desea aprobar esta solicitud de Ayuda?', 'question')
    .then(alertResult => {
      /* //Necesitamos preconfirm  aqui para visualizar ajax
      if(alertResult.isConfirmed){
        this.dataService.AprobarSolicitud(this.solicitudId).subscribe(response => {
          Swal.fire('Aprobación de Solicitud', `Solicitud de Ayuda Numero ${this.solicitudId} Aprobada por usted`, 'success')
        });
      }
      
      */
    });

    
  }

}
