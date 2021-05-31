import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { Observable, Subscriber } from 'rxjs';
import { filter, map, mergeMap, switchMap, tap } from 'rxjs/operators';
import { ItemModel } from 'src/app/model/itemModel';
import { DataService } from 'src/app/services/data.service';
import { loadSeccionales } from 'src/app/store/seccionales/app.seccionales.actions';
import { SeccionalesState } from 'src/app/store/seccionales/app.seccionales.reducer';
import { selectLoadingSeccionales, selectSeccionales } from 'src/app/store/seccionales/app.seccionales.selectors';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-seccional',
  templateUrl: './seccional.component.html',
  styleUrls: ['./seccional.component.css']
})
export class SeccionalComponent implements OnInit {

  constructor(private dataService: DataService,
    private store: Store<SeccionalesState>) {

  }
  
  seccionales$: Observable<ItemModel[]>;
  loadingSeccionales$: Observable<boolean>;

  seccionales: Array<any> = [];
  selectedSeccional: ItemModel;
  seccional: any;
  loadingSeccionales: boolean;

  @Input()
  enableField: boolean;

  ngOnInit() {

    this.seccionales$ = this.store.pipe(
      select(selectSeccionales),
      tap(seccionales => {
        if(!seccionales || seccionales.length == 0){
          this.store.dispatch(loadSeccionales())
        }
      })
    )

    this.loadingSeccionales$ = this.store.pipe(
      select(selectLoadingSeccionales)
    )
  }

  @Output()
  onSelect = new EventEmitter<ItemModel>();

  @Output()
  onRemove = new EventEmitter<number>();

  typeaheadOnSelect(e: TypeaheadMatch ): void {
    this.selectedSeccional = e.item;
    this.onSelect.next(this.selectedSeccional);
  }

  removerSeccional() {
    this.selectedSeccional = null;
    this.seccional = null;
    this.onRemove.next(null);
  }

}
