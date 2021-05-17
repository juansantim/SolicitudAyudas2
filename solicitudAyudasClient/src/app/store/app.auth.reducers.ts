import { createReducer, on } from "@ngrx/store";
import { UserData } from "../model/UserData";
import { login } from "./app.actions";
import { LoginActions } from "./app.actions.types";
import { AppState } from "./store";

export const initialState: AppState = {
    usuario:undefined
}

const LogOut = (state, action) => {
    return {
        ...state,
        usuario: undefined
    }
}

const Login = (state, action) => {
    return {
        ...state,
        usuario: action.usuario
    }   
};

export const AuthReducer = createReducer(
    initialState,
    on(LoginActions.login, Login),
    on(LoginActions.logOut, LogOut),
    on(LoginActions.pageReloadedLoggedIn, Login),
    on(LoginActions.pageReloadedLogedOutIn, LogOut),
 
)

