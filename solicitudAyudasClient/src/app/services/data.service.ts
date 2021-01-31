import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  GetSeccionales():Observable<any> {
    return this.http.get('/api/seccionales');
  }

  constructor(private http:HttpClient) { }
}
