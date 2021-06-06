import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { FiltroData } from 'src/app/model/FiltroData';
import { SolicitudAyuda } from 'src/app/model/Solicitud/solicitudAyuda';
import { SolicitudEntityService } from 'src/app/services/StoreEntityServices/solicitud-entity.service';
import { ConsultaActions } from 'src/app/store/ConsultaSolicitudes/consulta-solicitudes.actions.types';
import { ConsultaSolicitudState } from 'src/app/store/ConsultaSolicitudes/consulta-solicitudes.reducers';
@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent implements OnInit {
  itemsPerPage: number = 10;
  page: number = 1;

  filtro: FiltroData;
  totalItems: number;
  data: Array<SolicitudAyuda> = [];
  data$: Observable<SolicitudAyuda[]>;

  loading: boolean;

  constructor(private store: Store<ConsultaSolicitudState>,
    solicitudEntityService: SolicitudEntityService) {
      
      this.data$ = solicitudEntityService.entities$.pipe(
        map(entities => entities)
      )
  }

  ngOnInit() {

    this.store.pipe(

    )

  }

  LoadData() {
    this.filtro.Page = this.page;

    this.store.dispatch(ConsultaActions.filterChanged({ filtro: this.filtro }))

  }

  pageChanged(pageData) {
    this.LoadData();
  }

}
