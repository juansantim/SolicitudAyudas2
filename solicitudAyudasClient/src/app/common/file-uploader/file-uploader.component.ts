import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { fromEvent, Observable } from 'rxjs';

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.css']
})
export class FileUploaderComponent implements OnInit {

  constructor() { }

  file: HTMLInputElement;
  FileChage$: Observable<any>;
  
  files = [];

  @Output() 
  FilesChage = new EventEmitter<File[]>();


  ngOnInit() {
    this.file = <HTMLInputElement>document.getElementById("fileuploader");
    this.FileChage$ = fromEvent(this.file, 'change');

    this.FileChage$.subscribe(event => {
      let file = event.srcElement.files[0];

      var existingFile = this.files.reduce((acc, current:File) => {
        if(current.name === file.name && current.size == file.size){
          return acc += 1;
        }
        else{
          return acc;
        }        
      }, 0)

      if(existingFile){
        alert('Archivo ya se encuentra en la lista');
        return;
      }

      if (file) {
        this.files.push(file);
        this.FilesChage.emit(this.files);
      }
    });
  }

  AgregarAdjunto() {
    this.file.value = null;
    this.file.click();
  }

  remove(index) {
    this.files.splice(index, 1);
    this.FilesChage.emit(this.files);
  }

  GetEspacioTotal() {
    let sum = this.files.reduce((acumulator, current) => {
      return acumulator += current.size;
    }, 0)

    return sum;
  }


}
