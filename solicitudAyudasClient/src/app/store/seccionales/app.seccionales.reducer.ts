import { state } from "@angular/animations";
import { createReducer, on } from "@ngrx/store";
import { ItemModel } from "src/app/model/itemModel";
import { loadSeccionales, SeccionalesLoaded } from "./app.seccionales.actions";

export interface SeccionalesState {
    loadingSeccionales: boolean;
    seccionales: ItemModel[]
}

export const initialState: SeccionalesState = {
    loadingSeccionales: false,
    seccionales: []
} 

export const SeccionalesReducer = createReducer(
    initialState,
    on(loadSeccionales, (state, action) => {
        return {...state, loadingSeccionales: true}
    }),
    on(SeccionalesLoaded, (state, action) => {
        return { ...state, seccionales: action.seccionales, loadingSeccionales: false }
    }))

