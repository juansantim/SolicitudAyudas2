import { Component, OnInit } from '@angular/core';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-registro-solicitud',
  templateUrl: './registro-solicitud.component.html',
  styleUrls: ['./registro-solicitud.component.css']
})
export class RegistroSolicitudComponent implements OnInit {

  constructor(private dataService:DataService) 
  {

   }

  seccionales:Array<any>;
  selectedSeccional:any;
  cargandoSeccionales: boolean;

  isLoading(){
    return this.cargandoSeccionales;
  }

  typeaheadOnSelect(e: TypeaheadMatch): void {
    this.selectedSeccional = e.item;
  }

  ngOnInit() {
    this.cargandoSeccionales = true;

    this.dataService.GetSeccionales().subscribe(data => {
      this.seccionales = data;
      this.cargandoSeccionales = false;
    }, err => {
      this.cargandoSeccionales = false;
    })
  }

  removerSeccional(){
    this.selectedSeccional=null;
    this.selected = null;
  }

  selected: any;
}
