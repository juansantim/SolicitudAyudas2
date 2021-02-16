import { Component, OnInit } from '@angular/core';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { esDoLocale } from 'ngx-bootstrap/locale';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { DataService } from 'src/app/services/data.service';
import Swal from 'sweetalert2';

defineLocale('es-do', esDoLocale);

@Component({
  selector: 'app-filtro',
  templateUrl: './filtro.component.html',
  styleUrls: ['./filtro.component.css']
})
export class FiltroComponent implements OnInit {

  filtrarPorCedula:boolean;
  filtrarPorSeccional:boolean;
  
  cedula:string;
  seccional:string;
  selectedSeccional:any;

  seccionales = [];

  today:Date;
  constructor(private localeService: BsLocaleService, private dataService:DataService) { }

  ngOnInit() {
    this.today = new Date();
    this.localeService.use('es-do');

    
    this.dataService.GetSeccionales().subscribe(data => {
      this.seccionales = data;    
    
    }, err => {
      //this.solicitudAyudaForm.get('seccional').setErrors(Validators.)
      Swal.fire('Error', 'Hubo un error al cargar seccionales. Intente nuevamente mas tarde', 'error')
    })
  }

  typeaheadOnSelect(e: TypeaheadMatch): void {
    this.selectedSeccional = e.item;
  }
  

}
