import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';
import { HttpDataResponse } from '../model/HttpDataResponse';

@Injectable({
  providedIn: 'root'
})
export class UtilsService {
  
  DefaultGeneralFail() {
    Swal.fire("Error", "Hubo un error al procesar la solicitud. Intente de nuevamente. Si el problema persiste favor contactar a soporte", "error");
  }

  GetUnorderedList(list:Array<string>){
    let ul = '';    
    if(list.length > 0){
      ul = '<ul>';          
      list.forEach(text => {
        ul += '<li>';
        ul += text
        ul += '</li>';
      });
      ul += '</ul>'
    }
    
    return ul;    
  }

  
  public GetUlList(httpDataResponse: HttpDataResponse<any>) {
    return this.GetUnorderedList(httpDataResponse.Errors);
  }
  
  constructor() { }
}
