import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserData } from "../model/UserData";
import { AppState } from "./store";

export const selectAuthState= createFeatureSelector("auth");

export const isLoggedIn = createSelector(
    selectAuthState,
    (usuario) => !!usuario
)

export const userProfile = createSelector(
    selectAuthState, 
    (auth) => auth["usuario"]
)