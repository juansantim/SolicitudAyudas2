import { createReducer, on } from "@ngrx/store";
import { UserProfile } from "../model/UserProfile";
import { LoginActions } from "./app.actions.types";

export class AppAuthState{
  usuario: UserProfile;
  loginIn: boolean;
}


export const initialState: AppAuthState = {
  usuario: undefined,
  loginIn: false
}


const LogOut = (state, action) => {
  return {
    ...state,
    usuario: undefined,
    loginIn: false
  }
}

const Login = (state:AppAuthState, action) => {
  if (action?.usuario) {
    return {
      ...state,
      usuario: action.usuario,
      loginIn: false
    }
  }
  else{
    console.log('No Present', action)
    return state;
  }

};

export const AuthReducer = createReducer(
  initialState,
  on(LoginActions.loginStarted, (state, action) =>  
  {
    return {...state, loginIn: true}
  }),
  on(LoginActions.userLogedIn, Login),
  on(LoginActions.pageReloadedLoggedIn, Login),
  on(LoginActions.logOut, LogOut),
  on(LoginActions.pageReloadedLogedOutIn, LogOut),
  on(LoginActions.AuthGuardlogOut, LogOut),
  on(LoginActions.loginFail, (state, action) => {
    return {
      ...state,
      loginIn: false,
      usuario: undefined      
    } 
  })
)

