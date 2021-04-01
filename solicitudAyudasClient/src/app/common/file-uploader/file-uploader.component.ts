import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { fromEvent, Observable } from 'rxjs';
import { UploadedFile } from 'src/app/model/UploadedFile';
import { AppCookieService } from 'src/app/services/app-cookie.service';
import { DataService } from 'src/app/services/data.service';
import { UtilsService } from 'src/app/services/utils.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.css']
})
export class FileUploaderComponent implements OnInit {

  constructor(private dataService:DataService,
    private cookieService:AppCookieService,
    private utilsService:UtilsService) { }

  file: HTMLInputElement;
  FileChage$: Observable<any>;
  
  files = [];

  @Output() 
  FilesChage = new EventEmitter<File[]>();

  @Input()
  UploadedFiles:Array<UploadedFile> = [];


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

  eliminarArchivo(uploadedFile:UploadedFile, index){
    Swal.fire({
      title: 'Elimar archivo adjunto',
      text:  `Seguro que desea eliminar el archivo -> ${uploadedFile.displayName}?`,
      icon: 'question',
      showConfirmButton: true,
      confirmButtonText: 'Eliminar',
      confirmButtonColor: 'red',
      showCancelButton: true,
      cancelButtonText: 'No',
      preConfirm: () => {
        let url = this.dataService.GetUrl(`files/delete?id=${uploadedFile.id}`);
        
        return fetch(url, {
          method: 'POST', // *GET, POST, PUT, DELETE, etc.
          mode: 'cors', // no-cors, *cors, same-origin
          cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
          credentials: 'same-origin', // include, *same-origin, omit
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${this.cookieService.get('token')}`     
          },                    
          body: "" // body data type must match "Content-Type" header
        }).then(response => {
          if (!response.ok) {
            throw new Error(response.statusText)
          }          
          return response.json();

        }).catch(error => {
          console.log(error);
          Swal.showValidationMessage(            
            `Request failed: ${error}`
          )
        });
      }
    }).then((result) => {
      if(result.isConfirmed){
        if(result.value.success){
          Swal.fire({
            title: `Archivo Eliminado`,
            text: `${uploadedFile.displayName} eliminado correctamente`,
            icon: 'warning'
          })

          this.UploadedFiles.splice(index, 1);
        }
        else{
          Swal.fire({
            title: 'Error al eliminar archivo',
            html: `Error al procesar: ${this.utilsService.GetUnorderedList(result.value.errors)}`,
            icon:'error'
            }
          )
        }        
      }
    })
  }


}
