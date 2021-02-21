import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { DataService } from 'src/app/services/data.service';
import { UtilsService } from 'src/app/services/utils.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-acciones',
  templateUrl: './acciones.component.html',
  styleUrls: ['./acciones.component.css']
})
export class AccionesComponent implements OnInit {

  @Input()
  tipoSolicitudAyuda: string;

  @Input()
  solicitudId: number;

  loading: boolean;

  constructor(private dataService: DataService, private router: Router, private util: UtilsService) { }

  puedeGestionar: boolean;

  ngOnInit() {
    // console.log(this.tipoSolicitudAyuda);
    this.dataService.PuedeGestionarTipoSolicitud(this.tipoSolicitudAyuda).subscribe(response => {
      this.puedeGestionar = response.puedeGestionar
    })
  }

  AprobarSoliciud() {

    Swal.fire({
      title: 'Confirmación',
      text: 'Esta Seguro que desea aprobar esta solicitud de Ayuda?',
      icon: 'question',
      showCancelButton: true,
      cancelButtonText: 'Cancelar',
      showConfirmButton: true,
      confirmButtonText: 'Aprobar Solicitud',
      showLoaderOnConfirm: true,
      allowOutsideClick: false,
      preConfirm: () => {
        return this.dataService.AprobarSolicitud(this.solicitudId)
          .then(response => {
            return response.json();
          })
          .then((result: any) => {
            if (result.success) {
              Swal.fire({
                title: `Aprobación solicitud`,
                text: 'Soliciud de ayuda aprobada correctamente'
              }).then(() => {
                this.router.navigate(['/detalle', this.solicitudId]);
              })
            }
            else {
              var erros = this.util.GetUnorderedList(result.errors)
              Swal.showValidationMessage(
                `Error al procesar solicitud: ${erros}`
              )
            }
          })
          .catch(error => {

          })
      }
    })


  }

}
