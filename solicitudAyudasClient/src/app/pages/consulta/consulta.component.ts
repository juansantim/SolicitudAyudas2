import { Component, OnInit } from '@angular/core';
import { FiltroData } from 'src/app/model/FiltroData';
import { DataService } from 'src/app/services/data.service';
import { ConsultaService } from './consulta.service';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent implements OnInit {
  itemsPerPage: number = 10;
  page: number = 1;
  filtro: FiltroData;
  totalItems: number;
  data = [];

  loading: boolean;

  constructor(private consultaService: ConsultaService,
    private dataService: DataService) { }


  ngOnInit() {
    this.consultaService.aplicarFiltroEvent.subscribe(filtro => {
      this.filtro = filtro;

      filtro.ItemsPerPage = this.itemsPerPage;
      filtro.Page = this.page;

      this.LoadData();

    });

    this.consultaService.SetLoading.subscribe(value => {
      this.loading = value;
    })

  }

  LoadData(){
    this.filtro.Page = this.page;
    this.consultaService.SetLoading.next(true);
    this.dataService.ConsultaSolicitudes(this.filtro).subscribe(data => {      
      this.totalItems = data.totalItems;
      this.data = data.data;

      this.consultaService.SetLoading.next(false);
    });
  }

  pageChanged(pageData) {
    let page = pageData.page
    this.page = page;

    this.LoadData();
  }

}
