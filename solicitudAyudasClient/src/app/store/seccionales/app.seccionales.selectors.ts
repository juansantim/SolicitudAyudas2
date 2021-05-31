import { createFeatureSelector, createSelector } from "@ngrx/store";
import { SeccionalesState } from "./app.seccionales.reducer";

export const selectSeccionalesState = createFeatureSelector("seccionales");

export const selectSeccionales = createSelector(
    selectSeccionalesState,
    (state: SeccionalesState) => state.seccionales
)

export const selectLoadingSeccionales = createSelector(
    selectSeccionalesState,
    (state: SeccionalesState) => state.loadingSeccionales
)