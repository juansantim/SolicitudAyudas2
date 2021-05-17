import { createAction, props } from "@ngrx/store";
import { UserData } from "../model/UserData";

export const login = createAction("[Login Page] Iniciar Sesion", props<{usuario:UserData}>());

export const pageReloadedLoggedIn = createAction("[Main Page] Page Realoaded LoggedIn", props<{usuario:UserData}>());

export const logOut = createAction("[Main Menu] Cerrar Sesion");