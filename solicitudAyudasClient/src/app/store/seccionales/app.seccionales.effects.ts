import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { first, map, switchMap } from "rxjs/operators";
import { DataService } from "src/app/services/data.service";
import { loadSeccionales, SeccionalesLoaded } from "./app.seccionales.actions";
import { SeccionalesState } from "./app.seccionales.reducer";


@Injectable()
export class SeccionalesEffects {

    loadSeccionales$ = createEffect(() => this.actions$.pipe(
        ofType(loadSeccionales),
        switchMap(action =>
            this.dataService.GetSeccionales()
                .pipe(
                    map(seccionales => {
                        return SeccionalesLoaded({ seccionales });
                    })
                )
        ),
    ));

    constructor(private actions$: Actions,
        private dataService: DataService) {

    }

}