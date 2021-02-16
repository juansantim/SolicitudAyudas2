import { Component, Input, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {

  @Input()
  itemsPerPage:number;

  @Input()
  totalItems:number;

  constructor() { }

  ngOnInit() {
    
  }

  pageChanged(event){
    console.log(event);
  }

}
