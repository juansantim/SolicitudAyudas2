import { createAction, props } from "@ngrx/store";
import { FiltroData } from "src/app/model/FiltroData";

export const filterChanged = createAction('[Solicitud Data Service] Change Filter Data', props<{filtro:FiltroData}>())

export const totalPagesChanged = createAction('[Effect Consulta] Pagination Data Changed', props<{totalItems:number}>())