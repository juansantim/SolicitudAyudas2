import { Injectable } from "@angular/core";
import { EntityActionOptions, EntityCollectionServiceBase, EntityCollectionServiceElementsFactory, QueryParams } from "@ngrx/data";
import { SolicitudAyuda } from "src/app/model/Solicitud/solicitudAyuda";

@Injectable()
export class SolicitudEntityService extends EntityCollectionServiceBase<SolicitudAyuda> {

    constructor(serviceElementFactory: EntityCollectionServiceElementsFactory) {
        super("Solicitud", serviceElementFactory)
    }


}
