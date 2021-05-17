import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppState } from "./store";

export const selectAuthState = createFeatureSelector("auth");

export const isLoggedIn = createSelector(
    selectAuthState,
    (usuario) => !!usuario
)