import { Component, Input, OnInit } from '@angular/core';
import { BsModalService, BsModalRef  } from 'ngx-bootstrap/modal';
import { error } from 'protractor';
import { DataService } from 'src/app/services/data.service';
import { UtilsService } from 'src/app/services/utils.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-procesar-solicitud',
  templateUrl: './procesar-solicitud.component.html',
  styleUrls: ['./procesar-solicitud.component.css']
})
export class ProcesarSolicitudComponent implements OnInit {

  accion:number;
  comentario:string;  
  modalRef:BsModalRef;

  @Input()
  solicitudId:number;

  procesando:boolean;
  constructor(private modalService: BsModalService, 
    private dataService:DataService,
    private util: UtilsService) { }

  ngOnInit() {
  }

  cerrar(){
    this.dataService.bsModalRef.hide();
  }

  procesarSolicitud(estadoId){
    let act = "";
    let icon = "info";

    if(estadoId == 3){
      act = "aprobar";
      
    }
    else if(estadoId == 4){
      act = "rechazar";
    }


    Swal.fire({
      title: 'Aviso',
      text: `Seguro que desea ${act } esta solicitud?`,
      icon: 'info',
      showConfirmButton: true,
      confirmButtonText: act,
      showCancelButton: true,
      cancelButtonText: "Cancelar"
    }).then(alertResult => {
      if(alertResult.isConfirmed){
        Swal.close();

        this.procesando = true;
        estadoId = parseInt(estadoId);
        this.dataService.ProcesarSolicitud(this.solicitudId, estadoId, this.comentario).subscribe(response => {
          if(response.success){
            Swal.fire('Aviso', `Solicitud ${act} correctamente.`, 'success')    
            this.dataService.ReloadSolicitud.next(this.solicitudId);
            this.dataService.bsModalRef.hide();
            
          }
          else{
            var ul = this.util.GetUnorderedList(response.errors);
            Swal.fire('Error', ul,'error');
          }
          this.procesando = false;
        }, error => {
          Swal.fire('Error', 'Hubo un error al procesar solicitud', 'error');
          this.procesando = false;
        })

      }
    });


  }

}
