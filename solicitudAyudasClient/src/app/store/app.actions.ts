import { createAction, props } from "@ngrx/store";
import { UserData } from "../model/UserData";

export const login = createAction("[Login Page] Iniciar Sesion", props<{usuario:UserData}>());

export const logOut = createAction("[Main Menu] Cerrar Sesion");

export const pageReloadedLoggedIn = createAction("[Main Page] Page Realoaded LoggedIn", props<{usuario:UserData}>());

export const pageReloadedLogedOutIn = createAction("[Main Menu] Page Realoaded LoggedOut");

export const redirectToMainPage = createAction("[Login Page] RedirectToMainPage", props<{url:string}>());

