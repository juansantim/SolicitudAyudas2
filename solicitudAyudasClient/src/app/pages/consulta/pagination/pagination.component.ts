import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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

  @Output() onPageChanged: EventEmitter<number> = new EventEmitter();
  
  constructor() { }

  ngOnInit() {
    
  }

  pageChanged(event){
    this.onPageChanged.emit(event);
  }

  totalPages(){
    if(this.totalItems > 0){
     return Math.ceil(this.totalItems / this.itemsPerPage)
    }
    else{
      return "N/A"
    }
  }

}
