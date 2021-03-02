import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-estado-solicitud',
  templateUrl: './estado-solicitud.component.html',
  styleUrls: ['./estado-solicitud.component.css']
})
export class EstadoSolicitudComponent implements OnInit {

  @Input()
  estadoId: number;

  @Input()
  nombre: string;

  constructor() { }

  ngOnInit() {
  }

  GetClass() {
    switch (this.estadoId) {
      case 1:
        return "badge badge-secondary";
      case 2:
        return "badge badge-primary";
      case 3:
         return "badge badge-success";
      case 4:
        return "badge badge-danger";
      case 5:
        return "badge badge-warning";      
      default:
        return "badge badge-secondary";  
    }
  }

}
