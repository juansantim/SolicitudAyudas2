import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ComisionAprobacionUsuarioDTO } from 'src/app/model/ComisionAprobacionUsuarioDTO';

@Component({
  selector: 'app-comisiones-aprobacion-usuario',
  templateUrl: './comisiones-aprobacion-usuario.component.html',
  styleUrls: ['./comisiones-aprobacion-usuario.component.css']
})
export class ComisionesAprobacionUsuarioComponent implements OnInit {

  @Input()
  comisionesAprobacion:Array<ComisionAprobacionUsuarioDTO>;

  
  @Output() 
  onChanged: EventEmitter<Array<ComisionAprobacionUsuarioDTO>> = new EventEmitter();

  change(){
    this.onChanged.emit(this.comisionesAprobacion);
  }


  constructor() { }

  ngOnInit() {
  }

}
