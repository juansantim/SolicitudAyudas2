import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilsService {

  GetUnorderedList(list:Array<string>){
    if(list.length > 0){
      let ul = '<ul>';    
      ul += '</ul>'

      list.forEach(text => {
        ul += '<li>';
        ul += text
        ul += '</li>';
      });

      return ul;
    }
    return "";    
  }
  constructor() { }
}
