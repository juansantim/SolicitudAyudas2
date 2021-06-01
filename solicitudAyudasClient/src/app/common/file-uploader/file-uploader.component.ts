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
      return acumulator += current.Size;
    }, 0)

    return sum;
  }

  eliminarArchivo(uploadedFile:UploadedFile, index){    
    Swal.fire({
      title: 'Elimar archivo adjunto',
      text:  `Seguro que desea eliminar el archivo -> ${uploadedFile.DisplayName}?`,
      icon: 'question',
      showConfirmButton: true,
      confirmButtonText: 'Eliminar',
      confirmButtonColor: 'red',
      showCancelButton: true,
      cancelButtonText: 'No',
      preConfirm: () => this.dataService.EliminarAdjunto(uploadedFile.Id) 
    }).then((alertResult:any) => {
      if(alertResult.isConfirmed){
        
        if(alertResult.value && alertResult.value.Success){
          Swal.fire({
            title: `Archivo Eliminado`,
            text: `${uploadedFile.DisplayName} eliminado correctamente`,
            icon: 'warning'
          })

          this.UploadedFiles.splice(index, 1);
        }
        else{
          Swal.fire({
            title: 'Error al eliminar archivo',
            html: `Error al procesar: ${this.utilsService.GetUnorderedList(alertResult.value.Errors)}`,
            icon:'error'
            }
          )
        }        
      }
    }).catch(error => {      
      Swal.showValidationMessage(            
        `Request failed: ${error}`
      )
    });
    
  }
}
