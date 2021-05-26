import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserProfile } from "../model/UserProfile";
import { AppState } from "./store";

export const selectAuthState= createFeatureSelector("auth");

export const isLoggedIn = createSelector(
    selectAuthState,
    (state:AppState) => !!state.usuario
)

export const userProfile = createSelector(
    selectAuthState,
    (auth: AppState) => auth.usuario
)
