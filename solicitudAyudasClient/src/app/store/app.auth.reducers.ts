import { createReducer, on } from "@ngrx/store";
import { UserData } from "../model/UserData";
import { LoginActions } from "./app.actions.types";
import { AppState } from "./store";

export const initialState: AppState = {
    usuario:undefined
}

export const AuthReducer = createReducer(
    initialState,
    on(LoginActions.login, (state, action) => {
        return {
            usuario: action.usuario
        }   
    }),
    on(LoginActions.logOut, (state, action) => {
        return {
            usuario: undefined
        }
    }),
    on(LoginActions.pageReloadedLoggedIn, (state, action) => {
        return{
            usuario: action.usuario
        }
    })
)