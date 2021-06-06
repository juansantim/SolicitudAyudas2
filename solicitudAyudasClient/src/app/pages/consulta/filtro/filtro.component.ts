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

import * as $ from 'jquery';
import { ItemModel } from 'src/app/model/itemModel';
import { ConsultaSolicitudState } from 'src/app/store/ConsultaSolicitudes/consulta-solicitudes.reducers';
import { Store } from '@ngrx/store';
import { ConsultaActions } from 'src/app/store/ConsultaSolicitudes/consulta-solicitudes.actions.types';

defineLocale('es-do', esDoLocale);

@Component({
  selector: 'app-filtro',
  templateUrl: './filtro.component.html',
  styleUrls: ['./filtro.component.css']
})
export class FiltroComponent implements OnInit {

  filtrarPorCedula: boolean;
  filtrarPorSeccional: boolean;

  today: Date;

  loading: boolean;

  constructor(private localeService: BsLocaleService,     
    private consultaService: ConsultaService, 
    private store:Store<ConsultaSolicitudState>) { }

  form = new FormGroup({
    cedulaChk: new FormControl(false),
    seccinalChk: new FormControl(false),
    solicitudDesdeChk: new FormControl(false),
    solicitudHastaChk: new FormControl(false),
    aprobacionDesdeChk: new FormControl(false),
    aprobacionHastaChk: new FormControl(false),

    cedula: new FormControl(''),
    seccional: new FormControl(''),
    solicitudDesde: new FormControl(''),
    solicitudHasta: new FormControl(''),
    aprobacionDesde: new FormControl(''),
    aprobacionHasta: new FormControl(''),
  })

  selectedSeccional: ItemModel;

  ngOnInit() {
    this.today = new Date();
    this.localeService.use('es-do');

    this.SetToggle('cedulaChk', 'cedula');
    this.SetToggle('seccinalChk', 'seccional');
    this.SetToggle('solicitudDesdeChk', 'solicitudDesde');
    this.SetToggle('solicitudHastaChk', 'solicitudHasta');
    this.SetToggle('aprobacionDesdeChk', 'aprobacionDesde');
    this.SetToggle('aprobacionHastaChk', 'aprobacionHasta');

    this.SetDisabled('cedula');
    this.SetDisabled('seccional');
    this.SetDisabled('solicitudDesde');
    this.SetDisabled('solicitudHasta');
    this.SetDisabled('aprobacionDesde');
    this.SetDisabled('aprobacionHasta');

    this.consultaService.SetLoading.subscribe(loading => {
      this.loading = loading;
    })

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
      Cedula: this.form.controls.cedulaChk.value ? this.getValueOrNull(raw.cedula) : null,
      SeccionalId: this.form.controls.seccinalChk.value ? this.selectedSeccional.Id : null,
      SolicitudDesde: this.form.controls.solicitudDesdeChk.value ? this.getValueOrNull(raw.solicitudDesde) : null,
      SolicitudHasta: this.form.controls.solicitudHastaChk.value ? this.getValueOrNull(raw.solicitudHasta) : null,
      AprobacionDesde: this.form.controls.aprobacionDesdeChk.value ? this.getValueOrNull(raw.aprobacionDesde) : null,
      AprobacionHasta: this.form.controls.aprobacionHastaChk.value ? this.getValueOrNull(raw.aprobacionHasta) : null
    };

    let collapses = $('#collapseOne');
    collapses.removeClass('show');
    collapses.addClass('hide');

    this.store.dispatch(ConsultaActions.filterChanged({filtro}))
    
  }


}
