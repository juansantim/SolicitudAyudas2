import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DefaultDataService, HttpUrlGenerator, QueryParams } from "@ngrx/data";
import { Store } from "@ngrx/store";
import { Observable } from "rxjs";
import { map, tap } from "rxjs/operators";
import { PaginatedResult } from "src/app/model/ConsultaSolicitudes/PaginatedResult";
import { FiltroData } from "src/app/model/FiltroData";
import { SolicitudAyuda } from "src/app/model/Solicitud/solicitudAyuda";
import { ConsultaActions } from "src/app/store/ConsultaSolicitudes/consulta-solicitudes.actions.types";
import { environment } from "src/environments/environment";

@Injectable()
export class SolicitudDataService extends DefaultDataService<SolicitudAyuda>{

    baseUrl: string;

    GetUrl(endPoint) {
        return `${this.baseUrl}/${endPoint}`
    }
    constructor(http: HttpClient, httpUrlGenerator: HttpUrlGenerator,
        private store: Store<SolicitudAyuda>) {
        super("Solicitud", http, httpUrlGenerator)

        this.baseUrl = environment.baseUrl;

    }

    getWithQuery(params: string | QueryParams): Observable<SolicitudAyuda[]> {

        let filtro: FiltroData;

        if (typeof (params) === "string") {
            filtro = JSON.parse(params) as FiltroData;
        }
        else {

            filtro =  {
                ItemsPerPage: parseInt(params["ItemsPerPage"].toString()),
                Page: parseInt(params["Page"].toString()),
                Cedula: params["Cedula"],
                SeccionalId: parseInt(params["SeccionalId"].toString()),
                AprobacionDesde: new Date(params["AprobacionDesde"].toString()),
                AprobacionHasta: new Date(params["AprobacionHasta"].toString()),
                SolicitudDesde: new Date(params["SolicitudDesde"].toString()),
                SolicitudHasta: new Date(params["SolicitudHasta"].toString())
            } as FiltroData
        }


        let url = this.GetUrl('Solicitud/paginada');

        return this.http.post<PaginatedResult<SolicitudAyuda>>(url, filtro).pipe(
            tap(result => this.store.dispatch(ConsultaActions.totalPagesChanged({totalItems: result.TotalItems}))),
            map(result => result.Data),
        )
    }
}