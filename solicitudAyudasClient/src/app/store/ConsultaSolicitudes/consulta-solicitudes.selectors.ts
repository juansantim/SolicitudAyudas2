import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ConsultaSolicitudState } from "./consulta-solicitudes.reducers";

export const selectConsultaState = createFeatureSelector("consulta")

export const filtroOfStore = createSelector(
    selectConsultaState,
    (state: ConsultaSolicitudState) => state.filtro
)

export const totalItemsOfStore = createSelector(
    selectConsultaState,
    (state:ConsultaSolicitudState) => state.totalItems
)