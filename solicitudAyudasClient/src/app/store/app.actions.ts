import { createAction, props } from "@ngrx/store";
import { LoginModel } from "../model/LoginModel";
import { UserProfile } from "../model/UserProfile";

export const loginStarted = createAction("[Login Page] Intento inicio Sesion", props<{usuario:LoginModel}>());

export const userLogedIn = createAction("[Login Page] Sesion Iniciada", props<{usuario:UserProfile}>());

export const logOut = createAction("[Main Menu] Cerrar Sesion");

export const AuthGuardlogOut = createAction("[Default Auth Guard] Cerrar Sesion");

export const pageReloadedLoggedIn = createAction("[Main Page] Page Realoaded LoggedIn", props<{usuario:UserProfile}>());

export const pageReloadedLogedOutIn = createAction("[Main Menu] Page Realoaded LoggedOut");

export const loginFail = createAction('[Auth Effect] Login')


