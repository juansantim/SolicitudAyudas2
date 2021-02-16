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

defineLocale('es-do', esDoLocale);

@Component({
  selector: 'app-filtro',
  templateUrl: './filtro.component.html',
  styleUrls: ['./filtro.component.css']
})
export class FiltroComponent implements OnInit {

  filtrarPorCedula:boolean;
  filtrarPorSeccional:boolean;
  
  seccionales = [];

  today:Date;
  constructor(private localeService: BsLocaleService, private dataService:DataService,  private consultaService:ConsultaService) { }

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

  selectedSeccional:any;

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

  }


  SetToggle(chkControlName, dataControlName){

    let dataControl = this.form.get(dataControlName);

    this.form.get(chkControlName).valueChanges.subscribe(newValue => {      
      if(newValue){
        dataControl.enable();
      }
      else{
        dataControl.disable();
      }      
    })


  }
  
  removerSeccional(){
    this.selectedSeccional = null; 
    this.form.get('seccional').enable();
    this.form.get('seccional').setValue('')   
  }
  SetDisabled(dataControlName){
    let dataControl = this.form.get(dataControlName);
    dataControl.disable();

  }

  typeaheadOnSelect(e: TypeaheadMatch): void {
    this.selectedSeccional = e.item;
    this.form.get('seccional').disable();
  }

 
  onSubmit(){
    let filtro:FiltroData = new FiltroData();
    let raw = this.form.getRawValue();

    filtro.cedula = raw.cedula;
    filtro.seccionalId= this.selectedSeccional? this.selectedSeccional.id : 0;
    
    filtro.solicitudDesde  = raw.solicitudDesde;
    filtro.solicitudHasta = raw.solicitudHasta;
    
    filtro.aprobacionDesde= raw.aprobacionDesde;
    filtro.aprobacionHasta=raw.aprobacionHasta;

    this.consultaService.aplicarFiltro(filtro);

  }
  

}
