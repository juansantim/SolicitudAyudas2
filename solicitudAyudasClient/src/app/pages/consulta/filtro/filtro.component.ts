import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { esDoLocale } from 'ngx-bootstrap/locale';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { FiltroData } from 'src/app/model/FiltroData';
import { DataService } from 'src/app/services/data.service';
import Swal from 'sweetalert2';
import { ConsultaService } from '../consulta.service';

import {tap} from 'rxjs/operators'

import * as $ from 'jquery';
import { ItemModel } from 'src/app/model/itemModel';
import { ConsultaSolicitudState } from 'src/app/store/ConsultaSolicitudes/consulta-solicitudes.reducers';
import { select, Store } from '@ngrx/store';
import { ConsultaActions } from 'src/app/store/ConsultaSolicitudes/consulta-solicitudes.actions.types';
import { filtroOfStore } from 'src/app/store/ConsultaSolicitudes/consulta-solicitudes.selectors';

defineLocale('es-do', esDoLocale);

@Component({
  selector: 'app-filtro',
  templateUrl: './filtro.component.html',
  styleUrls: ['./filtro.component.css']
})
export class FiltroComponent implements OnInit {

  today: Date;

  loading: boolean;

  constructor(private localeService: BsLocaleService,     
    private consultaService: ConsultaService, 
    private store:Store<ConsultaSolicitudState>) { }

  form = new FormGroup({
    CedulaChk: new FormControl(false),
    SeccinalChk: new FormControl(false),
    SolicitudDesdeChk: new FormControl(false),
    SolicitudHastaChk: new FormControl(false),
    AprobacionDesdeChk: new FormControl(false),
    AprobacionHastaChk: new FormControl(false),

    Cedula: new FormControl(''),
    Seccional: new FormControl(''),
    SolicitudDesde: new FormControl(''),
    SolicitudHasta: new FormControl(''),
    AprobacionDesde: new FormControl(''),
    AprobacionHasta: new FormControl(''),
  })

  selectedSeccional: ItemModel;

  ngOnInit() {
    this.today = new Date();
    this.localeService.use('es-do');

    this.SetToggle('CedulaChk', 'Cedula');
    this.SetToggle('SeccinalChk', 'Seccional');
    this.SetToggle('SolicitudDesdeChk', 'SolicitudDesde');
    this.SetToggle('SolicitudHastaChk', 'SolicitudHasta');
    this.SetToggle('AprobacionDesdeChk', 'AprobacionDesde');
    this.SetToggle('AprobacionHastaChk', 'AprobacionHasta');

    this.SetDisabled('Cedula');
    this.SetDisabled('Seccional');
    this.SetDisabled('SolicitudDesde');
    this.SetDisabled('SolicitudHasta');
    this.SetDisabled('AprobacionDesde');
    this.SetDisabled('AprobacionHasta');

    this.consultaService.SetLoading.subscribe(loading => {
      this.loading = loading;
    })

    this.store.pipe(
      select(filtroOfStore),
      tap(filtro => {
        this.form.setValue(filtro)
      })
    ).subscribe();

  }


  SetToggle(chkControlName, dataControlName) {

    let dataControl = this.form.get(dataControlName);

    this.form.get(chkControlName).valueChanges.subscribe(newValue => {
      if (newValue) {
        dataControl.enable();
      }
      else {
        dataControl.disable();
      }
    })


  }
  SetDisabled(dataControlName) {
    let dataControl = this.form.get(dataControlName);
    dataControl.disable();

  }

  removerSeccional() {
    this.selectedSeccional = null;
    this.form.get('seccional').enable();
    this.form.get('seccional').setValue('')
  }

  onSeccionalSelected(e: ItemModel): void {
    this.selectedSeccional = e;
    this.form.get('seccional').setValue(e.Nombre)    
  }

  getValueOrNull(value) {
    return value ? value : null;
  }

  onSubmit() {

    let raw = this.form.getRawValue();

    let filtro: FiltroData = {
      ItemsPerPage: 10,
      Page: 1,
      Cedula: this.form.controls.CedulaChk.value ? this.getValueOrNull(raw.Cedula) : null,
      SeccionalId: this.form.controls.SeccinalChk.value ? this.selectedSeccional.Id : null,
      SolicitudDesde: this.form.controls.SolicitudDesdeChk.value ? this.getValueOrNull(raw.SolicitudDesde) : null,
      SolicitudHasta: this.form.controls.SolicitudHastaChk.value ? this.getValueOrNull(raw.SolicitudHasta) : null,
      AprobacionDesde: this.form.controls.AprobacionDesdeChk.value ? this.getValueOrNull(raw.AprobacionDesde) : null,
      AprobacionHasta: this.form.controls.AprobacionHastaChk.value ? this.getValueOrNull(raw.AprobacionHasta) : null
    };

    let collapses = $('#collapseOne');
    collapses.removeClass('show');
    collapses.addClass('hide');

    this.store.dispatch(ConsultaActions.filterChanged({filtro}))
    
  }


}
