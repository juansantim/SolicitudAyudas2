import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { FiltroData } from 'src/app/model/FiltroData';

@Injectable({
  providedIn: 'root'
})
export class ConsultaService {

  aplicarFiltroEvent: Subject<FiltroData> = new Subject<FiltroData>();
  SetLoading: Subject<boolean> = new Subject<boolean>();
  
  constructor() { }

  aplicarFiltro(filtro: FiltroData){
    this.aplicarFiltroEvent.next(filtro)
  }
}
