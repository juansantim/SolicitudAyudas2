import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { ConsultaActions } from "./consulta-solicitudes.actions.types";
import { map } from 'rxjs/operators';
import { SolicitudEntityService } from "src/app/services/StoreEntityServices/solicitud-entity.service";

@Injectable()
export class ConsultaEffects {
    ApplyFilter$ = createEffect(() => this.actions$.pipe(
        ofType(ConsultaActions.filterChanged),
        map(action => {
            this.entityService.clearCache();
            this.entityService.getWithQuery(JSON.stringify(action.filtro), {                
            })
        })
    ), { dispatch: false })

    // PaginationDataChaned$ = createEffect(() => this.actions$.pipe(
    //     ofType()
    // ))

    constructor(private actions$: Actions, 
        private entityService: SolicitudEntityService) {
    }
}