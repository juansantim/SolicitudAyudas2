import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  GetTiposSolicitudesConRequisitos():Observable<any> {
    return this.http.get('/api/TipoSolicitud/ConRequisitos');
  }
  GetSeccionales():Observable<any> {
    return this.http.get('/api/seccionales');
  }

  constructor(private http:HttpClient) { }
}
