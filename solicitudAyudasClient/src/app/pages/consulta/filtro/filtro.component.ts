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

defineLocale('es-do', esDoLocale);

@Component({
  selector: 'app-filtro',
  templateUrl: './filtro.component.html',
  styleUrls: ['./filtro.component.css']
})
export class FiltroComponent implements OnInit {

  filtrarPorCedula: boolean;
  filtrarPorSeccional: boolean;

  seccionales = [];

  today: Date;

  loading: boolean;

  constructor(private localeService: BsLocaleService, private dataService: DataService, private consultaService: ConsultaService) { }

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

  selectedSeccional: any;

  ngOnInit() {
    this.today = new Date();
    this.localeService.use('es-do');

    this.dataService.GetSeccionales().subscribe(data => {
      this.seccionales = data;

    }, err => {
      //this.solicitudAyudaForm.get('seccional').setErrors(Validators.)
      Swal.fire('Error', 'Hubo un error al cargar seccionales. Intente nuevamente mas tarde', 'error')
    })


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

  removerSeccional() {
    this.selectedSeccional = null;
    this.form.get('seccional').enable();
    this.form.get('seccional').setValue('')
  }
  SetDisabled(dataControlName) {
    let dataControl = this.form.get(dataControlName);
    dataControl.disable();

  }

  typeaheadOnSelect(e: TypeaheadMatch): void {
    this.selectedSeccional = e.item;
    this.form.get('seccional').setValue(e.item.nombre)
    //this.form.get('seccional').disable();        
  }

  getValueOrNull(value) {
    return value ? value : null;
  }

  onSubmit() {

    let raw = this.form.getRawValue();

    let filtro: FiltroData = {
      ItemsPerPage: 10,
      Page: 1,
      cedula: this.form.controls.cedulaChk.value ? this.getValueOrNull(raw.cedula) : null,
      seccionalId: this.form.controls.seccinalChk.value ? this.selectedSeccional.id : null,
      solicitudDesde: this.form.controls.solicitudDesdeChk.value ? this.getValueOrNull(raw.solicitudDesde) : null,
      solicitudHasta: this.form.controls.solicitudHastaChk.value ? this.getValueOrNull(raw.solicitudHasta) : null,
      aprobacionDesde: this.form.controls.aprobacionDesdeChk.value ? this.getValueOrNull(raw.aprobacionDesde) : null,
      aprobacionHasta: this.form.controls.aprobacionHastaChk.value ? this.getValueOrNull(raw.aprobacionHasta) : null
    };

    let collapses = $('#collapseOne');
    collapses.removeClass('show');
    collapses.addClass('hide');


    this.consultaService.aplicarFiltro(filtro);

  }


}
