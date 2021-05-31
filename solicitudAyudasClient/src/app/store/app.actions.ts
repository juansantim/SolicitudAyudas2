import { createAction, props } from "@ngrx/store";
import { UserProfile } from "../model/UserProfile";

export const login = createAction("[Login Page] Iniciar Sesion", props<{usuario:UserProfile}>());

export const logOut = createAction("[Main Menu] Cerrar Sesion");

export const AuthGuardlogOut = createAction("[Default Auth Guard] Cerrar Sesion");

export const pageReloadedLoggedIn = createAction("[Main Page] Page Realoaded LoggedIn", props<{usuario:UserProfile}>());

export const pageReloadedLogedOutIn = createAction("[Main Menu] Page Realoaded LoggedOut");

export const redirectToMainPage = createAction("[Login Page] RedirectToMainPage", props<{url:string}>());

