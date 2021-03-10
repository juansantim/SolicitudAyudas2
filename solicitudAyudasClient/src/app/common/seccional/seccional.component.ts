import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { DataService } from 'src/app/services/data.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-seccional',
  templateUrl: './seccional.component.html',
  styleUrls: ['./seccional.component.css']
})
export class SeccionalComponent implements OnInit {

  constructor(private dataService:DataService) { }
  seccionales: Array<any> = [];
  selectedSeccional:any;
  seccional:any;

  ngOnInit() {
    this.dataService.GetSeccionales().subscribe(data => {
      this.seccionales = data;      
    }, err => {      
      Swal.fire('Error', 'Hubo un error al cargar seccionales. Intente nuevamente mas tarde', 'error')
    })

    this.dataService.setSeccional.subscribe(data => {
      this.seccional = data.seccional;
      this.onSelect.next(data.seccionalId);
      this.selectedSeccional = data;
    })

  }

  @Output()
  onSelect = new EventEmitter<number>();

  @Output()
  onRemove = new EventEmitter<number>();

  typeaheadOnSelect(e: TypeaheadMatch): void {    
    this.selectedSeccional = e.item;
    this.onSelect.next(e.item.id);    
  }

  removerSeccional(){
    this.selectedSeccional = null;
    this.seccional= null;
    this.onRemove.next(null);    
  }

}
