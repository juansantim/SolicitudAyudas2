import { MetaReducer } from "@ngrx/store";
import { environment } from "src/environments/environment";
import { AppAuthState } from "./app.auth.reducers";

export const metaReducers: MetaReducer<AppAuthState>[] = !environment.production ? [] : [];