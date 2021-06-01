import { Injectable } from '@angular/core';
import { HttpDataResponse } from '../model/HttpDataResponse';

@Injectable({
  providedIn: 'root'
})
export class UtilsService {

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
