import { createReducer, on } from "@ngrx/store";
import { FiltroData } from "src/app/model/FiltroData";
import { ConsultaActions } from './consulta-solicitudes.actions.types';

export interface ConsultaSolicitudState {
    filtro: FiltroData,
    totalItems: number
}

export const initialState: ConsultaSolicitudState = {
    filtro: {
        ItemsPerPage: 10,
        Page: 1,
        Cedula: null,
        AprobacionDesde: null,
        AprobacionHasta: null,
        SeccionalId: null,
        SolicitudDesde: null,
        SolicitudHasta: null
    },
    totalItems: 0
}

export const ConsultaReducer = createReducer(
    initialState,
    on(ConsultaActions.filterChanged, (state, action) => {
        return { ...state, filtro: action.filtro }
    }),
    on(ConsultaActions.totalPagesChanged, (state, action) => {
        return {...state, totalItems: action.totalItems}
    })
)