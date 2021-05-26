import { createReducer, on } from "@ngrx/store";
import { UserProfile } from "../model/UserProfile";
import { login } from "./app.actions";
import { LoginActions } from "./app.actions.types";
import { AppState } from "./store";

export const initialState: AppState = {
  usuario: undefined,
  url: undefined
}


const LogOut = (state, action) => {

  //this.cookieService.remove("usuario")

  return {
    ...state,
    usuario: undefined
  }
}

const Login = (state, action) => {
  if (action?.usuario) {
    return {
      ...state,
      usuario: action.usuario
    }
  }
  else{
    console.log('No Present', action)
    return state;
  }

};

export const AuthReducer = createReducer(
  initialState,
  on(LoginActions.login, Login),
  on(LoginActions.logOut, LogOut),
  on(LoginActions.pageReloadedLoggedIn, Login),
  on(LoginActions.pageReloadedLogedOutIn, LogOut),
  on(LoginActions.redirectToMainPage, (state, action) => {
    return {
      ...state,
      url: action.url
    }
  })

)

