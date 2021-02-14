import { JsonpClientBackend } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppLocalStorageService {

  seccionalesStore:string = 'seccionales'

  SaveSeccionales(seccionales){
    localStorage.setItem(this.seccionalesStore, JSON.stringify(seccionales));
  }

  GetValueFromStore(storeName){
    return  localStorage.getItem(storeName);
  }

  GetSeccionales(){
    let str = this.GetValueFromStore(this.seccionalesStore);
    if(str){
      return JSON.parse(str);
    }
    return null
  }

  constructor() { }
}
