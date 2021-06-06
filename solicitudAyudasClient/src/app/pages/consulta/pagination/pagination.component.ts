import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { FiltroData } from 'src/app/model/FiltroData';
import { DataService } from 'src/app/services/data.service';
import { ConsultaActions } from 'src/app/store/ConsultaSolicitudes/consulta-solicitudes.actions.types';
import { ConsultaSolicitudState } from 'src/app/store/ConsultaSolicitudes/consulta-solicitudes.reducers';
import { filtroOfStore, totalItemsOfStore } from 'src/app/store/ConsultaSolicitudes/consulta-solicitudes.selectors';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {

  @Input()
  itemsPerPage:number;

  totalItems$:Observable<number>;

  @Output() onPageChanged: EventEmitter<number> = new EventEmitter();

  filtro:FiltroData;
  
  currentPage:number = 1;

  constructor(private store:Store<ConsultaSolicitudState>) { }

  ngOnInit() {
    
    this.store.pipe(
      select(filtroOfStore),
      tap(filter => {
        this.filtro = {...filter}
        this.currentPage = filter.Page;
      })
    ).subscribe();

    this.totalItems$ = this.store.pipe(
      select(totalItemsOfStore)
    )

  }

  pageChanged(event:any){
    this.filtro.Page = event.page;    
    this.store.dispatch(ConsultaActions.filterChanged({filtro: this.filtro}))
  }

  // totalPages(){
  //   if(this.totalItems > 0){
  //    return Math.ceil(this.totalItems / this.itemsPerPage)
  //   }
  //   else{
  //     return "N/A"
  //   }
  // }

}
