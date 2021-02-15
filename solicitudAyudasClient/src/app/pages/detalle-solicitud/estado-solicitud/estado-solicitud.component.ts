import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-estado-solicitud',
  templateUrl: './estado-solicitud.component.html',
  styleUrls: ['./estado-solicitud.component.css']
})
export class EstadoSolicitudComponent implements OnInit {

  @Input()
  estadoId: any;

  @Input()
  nombre: string;

  constructor() { }

  ngOnInit() {
  }

  GetClass() {
    switch (this.estadoId) {
      case 1:
        return "badge badge-primary";
      case 2:
        return "badge badge-success";
      case 3:
        return "badge badge-danger";
      case 5:
        return "badge badge-secondary";      
      default:
        return "badge badge-secondary";  
    }
  }

}
