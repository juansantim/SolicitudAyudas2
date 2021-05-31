import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserProfile } from "../model/UserProfile";
import { AppAuthState } from "./app.auth.reducers";

export const selectAuthState= createFeatureSelector("auth");

export const isLoggedIn = createSelector(
    selectAuthState,
    (state:AppAuthState) => !!state.usuario
)

export const userProfile = createSelector(
    selectAuthState,
    (auth: AppAuthState) => auth.usuario
)
