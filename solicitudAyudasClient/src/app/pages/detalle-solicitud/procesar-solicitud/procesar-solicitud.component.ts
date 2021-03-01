import { Component, OnInit } from '@angular/core';
import { BsModalService, BsModalRef  } from 'ngx-bootstrap/modal';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-procesar-solicitud',
  templateUrl: './procesar-solicitud.component.html',
  styleUrls: ['./procesar-solicitud.component.css']
})
export class ProcesarSolicitudComponent implements OnInit {

  accion:any;
  comentario:string;  
  modalRef:BsModalRef;

  constructor(private modalService: BsModalService, private dataService:DataService) { }

  ngOnInit() {
  }

  cerrar(){
    this.dataService.bsModalRef.hide();
  }

}
