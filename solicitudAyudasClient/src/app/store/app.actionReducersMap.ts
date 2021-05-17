import { ActionReducerMap, MetaReducer } from "@ngrx/store";
import { environment } from "src/environments/environment";
import { AuthReducer } from "./app.auth.reducers";
import {AppState} from './store';

export const metaReducers: MetaReducer<AppState>[] = !environment.production ? [] : [];