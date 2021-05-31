import { createReducer, on } from "@ngrx/store";
import { UserProfile } from "../model/UserProfile";
import { LoginActions } from "./app.actions.types";

export class AppAuthState{
  usuario: UserProfile  
}


export const initialState: AppAuthState = {
  usuario: undefined,
}


const LogOut = (state, action) => {
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
  on(LoginActions.AuthGuardlogOut, LogOut),
  on(LoginActions.redirectToMainPage, (state, action) => {
    return {
      ...state,
      url: action.url
    }
  })

)

