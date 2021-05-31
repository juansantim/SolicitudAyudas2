import { createAction, props } from "@ngrx/store";
import { ItemModel } from "src/app/model/itemModel";


export const loadSeccionales = createAction("[Seccionales Component] Load Seccionales");

export const SeccionalesLoaded = createAction("[Seccionales Effects] Seccionales Loaded", props<{seccionales:ItemModel[]}>());
