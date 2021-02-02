import { Component, OnInit } from '@angular/core';
import { fromEvent, Observable } from 'rxjs';

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.css']
})
export class FileUploaderComponent implements OnInit {

  constructor() { }

  file:HTMLElement;
  FileChage$: Observable<any>;
  files = [];

  ngOnInit() {
   this.file = document.getElementById("fileuploader"); 
   this.FileChage$ = fromEvent(this.file, 'change');

   this.FileChage$.subscribe(event => {
    let file = event.srcElement.files[0]
    this.files.push(file);
   });
  }

  AgregarAdjunto(){        
    this.file.click();        
  }

  

}
