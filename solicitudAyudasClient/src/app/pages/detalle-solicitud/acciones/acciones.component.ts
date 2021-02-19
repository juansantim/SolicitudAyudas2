import { Component, OnInit } from '@angular/core';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-acciones',
  templateUrl: './acciones.component.html',
  styleUrls: ['./acciones.component.css']
})
export class AccionesComponent implements OnInit {


  loading:boolean;
  constructor(private dataService:DataService) { }

  permisos:Array<any> = [];
  ngOnInit() {
    this.dataService.GetPermisos().subscribe(permisos => {
      this.permisos = permisos;
      console.log(permisos)
    })
  }

  Show(permisoId){
    return this.permisos.indexOf(permisoId) > -1    
  }

}
