import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { Observable, Subscriber } from 'rxjs';
import { concatMap, debounceTime, delay, distinctUntilChanged, exhaustMap, filter, first, map, mergeMap, switchMap, tap } from 'rxjs/operators';
import { ItemModel } from 'src/app/model/itemModel';
import { DataService } from 'src/app/services/data.service';
import { loadSeccionales } from 'src/app/store/seccionales/app.seccionales.actions';
import { SeccionalesState } from 'src/app/store/seccionales/app.seccionales.reducer';
import { selectLoadingSeccionales, selectSeccionales } from 'src/app/store/seccionales/app.seccionales.selectors';

@Component({
  selector: 'app-seccional',
  templateUrl: './seccional.component.html',
  styleUrls: ['./seccional.component.css']
})
export class SeccionalComponent implements OnInit {
  
  @Input()
  enableField: boolean;
  
  @Output()
  onSelect = new EventEmitter<ItemModel>();

  @Output()
  onRemove = new EventEmitter<number>();

  seccionales$: Observable<ItemModel[]>;
  loadingSeccionales$: Observable<boolean>;

  selectedSeccional: ItemModel;
  seccional: string;
  loadingSeccionales: boolean;
 
  constructor(private store: Store<SeccionalesState>) {
    this.seccionales$ = new Observable(subscriber => {
      subscriber.next(this.seccional)
    }).pipe(
      debounceTime(400),      
      switchMap((token: string) => this.store.select(selectSeccionales).pipe(
        map(seccs => seccs.filter(s => s.Nombre?.toLowerCase().includes(token?.toLowerCase())))
      ))
    )
  }
  
  ngOnInit() {
    this.store.dispatch(loadSeccionales());    
    this.loadingSeccionales$ = this.store.pipe(
      select(selectLoadingSeccionales)
    )
  }
   
  SetSeccional(item: ItemModel) {
    this.selectedSeccional = item;
    this.seccional = item.Nombre;
    this.onSelect.next(this.selectedSeccional);
  }

  typeaheadOnSelect(e: TypeaheadMatch): void {
    this.SetSeccional(e.item)
  }

  removerSeccional() {
    this.selectedSeccional = null;
    this.seccional = null;
    this.onRemove.next(null);
  }
}
