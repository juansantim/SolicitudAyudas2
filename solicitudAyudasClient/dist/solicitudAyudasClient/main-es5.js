function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"], {
  /***/
  "./$$_lazy_route_resource lazy recursive":
  /*!******************************************************!*\
    !*** ./$$_lazy_route_resource lazy namespace object ***!
    \******************************************************/

  /*! no static exports found */

  /***/
  function $$_lazy_route_resourceLazyRecursive(module, exports) {
    function webpackEmptyAsyncContext(req) {
      // Here Promise.resolve().then() is used instead of new Promise() to prevent
      // uncaught exception popping up in devtools
      return Promise.resolve().then(function () {
        var e = new Error("Cannot find module '" + req + "'");
        e.code = 'MODULE_NOT_FOUND';
        throw e;
      });
    }

    webpackEmptyAsyncContext.keys = function () {
      return [];
    };

    webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
    module.exports = webpackEmptyAsyncContext;
    webpackEmptyAsyncContext.id = "./$$_lazy_route_resource lazy recursive";
    /***/
  },

  /***/
  "./node_modules/raw-loader/dist/cjs.js!./src/app/app.component.html":
  /*!**************************************************************************!*\
    !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/app.component.html ***!
    \**************************************************************************/

  /*! exports provided: default */

  /***/
  function node_modulesRawLoaderDistCjsJsSrcAppAppComponentHtml(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "<nav *ngIf=\"showNav\" class=\"navbar navbar-expand-lg navbar-dark bg-dark\">\r\n  <a class=\"navbar-brand\" routerLink=\"/\">Inicio</a>\r\n  <button class=\"navbar-toggler\" type=\"button\" data-toggle=\"collapse\" data-target=\"#navbarSupportedContent\"\r\n    aria-controls=\"navbarSupportedContent\" aria-expanded=\"false\" aria-label=\"Toggle navigation\">\r\n    <span class=\"navbar-toggler-icon\"></span>\r\n  </button>\r\n\r\n  <div class=\"collapse navbar-collapse\" id=\"navbarSupportedContent\">\r\n    <ul class=\"navbar-nav mr-auto\">\r\n      <li class=\"nav-item active\">\r\n        <a class=\"nav-link\" routerLink=\"/registrarSolicitud\">Solicitar Ayuda <span class=\"sr-only\">(current)</span></a>\r\n      </li>\r\n      <li class=\"nav-item \">\r\n        <a class=\"nav-link\" routerLink=\"/registrarSolicitud\">Historial de Solicitante <span class=\"sr-only\">(current)</span></a>\r\n      </li>\r\n      <li class=\"nav-item \">\r\n        <a class=\"nav-link\" routerLink=\"/registrarSolicitud\">Estadisticas <span class=\"sr-only\">(current)</span></a>\r\n      </li>\r\n      <li class=\"nav-item \">\r\n        <a class=\"nav-link\" routerLink=\"/registrarSolicitud\">Gestion de Usuarios <span class=\"sr-only\">(current)</span></a>\r\n      </li>\r\n      <li class=\"nav-item\">\r\n        <a class=\"nav-link\" href=\"#\">Link</a>\r\n      </li>\r\n      <!-- <li class=\"nav-item dropdown\">\r\n        <a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdown\" role=\"button\" data-toggle=\"dropdown\"\r\n          aria-haspopup=\"true\" aria-expanded=\"false\">\r\n          Dropdown\r\n        </a>\r\n        <div class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">\r\n          <a class=\"dropdown-item\" href=\"#\">Action</a>\r\n          <a class=\"dropdown-item\" href=\"#\">Another action</a>\r\n          <div class=\"dropdown-divider\"></div>\r\n          <a class=\"dropdown-item\" href=\"#\">Something else here</a>\r\n        </div>\r\n      </li> -->\r\n      <li class=\"nav-item\">\r\n        <a class=\"nav-link disabled\" href=\"#\">Disabled</a>\r\n      </li>\r\n    </ul>\r\n    <form class=\"form-inline my-2 my-lg-0\">\r\n      <input class=\"form-control mr-sm-2\" type=\"search\" placeholder=\"Search\" aria-label=\"Search\">\r\n      <button class=\"btn btn-outline-success my-2 my-sm-0\" type=\"submit\">Search</button>\r\n    </form>\r\n  </div>\r\n</nav>\r\n<main class=\"container\">\r\n  <router-outlet></router-outlet>\r\n\r\n  <script>\r\n    $(document).ready(function () {\r\n      alert('jquery is here')\r\n    });\r\n  </script>\r\n</main>\r\n\r\n\r\n<!-- Optional JavaScript -->\r\n<!-- jQuery first, then Popper.js, then Bootstrap JS -->";
    /***/
  },

  /***/
  "./node_modules/raw-loader/dist/cjs.js!./src/app/common/file-uploader/file-uploader.component.html":
  /*!*********************************************************************************************************!*\
    !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/common/file-uploader/file-uploader.component.html ***!
    \*********************************************************************************************************/

  /*! exports provided: default */

  /***/
  function node_modulesRawLoaderDistCjsJsSrcAppCommonFileUploaderFileUploaderComponentHtml(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "<input type=\"file\" class=\"form-control\"  style=\"visibility: hidden;\" id=\"fileuploader\" accept=\".jpeg, .pdf\">\n<ul *ngIf=\"files.length > 0\">\n    <li *ngFor=\"let file of files\">{{file.name}}</li> \n    <button class=\"btn btn-danger\"> <i class=\"fas fa-trash\"></i></button>    \n</ul>\n<button class=\"btn btn-primary\" (click)=\"AgregarAdjunto()\" ><i class=\"fas fa-plus-circle\"></i></button>";
    /***/
  },

  /***/
  "./node_modules/raw-loader/dist/cjs.js!./src/app/common/loading/loading.component.html":
  /*!*********************************************************************************************!*\
    !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/common/loading/loading.component.html ***!
    \*********************************************************************************************/

  /*! exports provided: default */

  /***/
  function node_modulesRawLoaderDistCjsJsSrcAppCommonLoadingLoadingComponentHtml(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "<div class=\"row\">\n    <div class=\"col-md-12\" *ngIf=\"show\">\n        <label>Un moment porfavor...</label>\n        <img src=\"assets/img/loading.gif\" width=\"100\" height=\"60\">\n    </div>\n</div>";
    /***/
  },

  /***/
  "./node_modules/raw-loader/dist/cjs.js!./src/app/common/validation-error-message/validation-error-message.component.html":
  /*!*******************************************************************************************************************************!*\
    !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/common/validation-error-message/validation-error-message.component.html ***!
    \*******************************************************************************************************************************/

  /*! exports provided: default */

  /***/
  function node_modulesRawLoaderDistCjsJsSrcAppCommonValidationErrorMessageValidationErrorMessageComponentHtml(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "<div>\r\n    \r\n    <label style=\"color: red;font-weight: bold;\">{{textMessage}}</label>\r\n</div>\r\n";
    /***/
  },

  /***/
  "./node_modules/raw-loader/dist/cjs.js!./src/app/login/login.component.html":
  /*!**********************************************************************************!*\
    !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/login/login.component.html ***!
    \**********************************************************************************/

  /*! exports provided: default */

  /***/
  function node_modulesRawLoaderDistCjsJsSrcAppLoginLoginComponentHtml(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "<body class=\"text-center\">\r\n    \r\n    <main class=\"form-signin\">\r\n      <form>\r\n        <img class=\"mb-4\" src=\"assets/img/LOGO_ADP-01.png\" alt=\"\" width=\"200\" height=\"100\">\r\n        <h1 class=\"h3 mb-3 fw-normal\">Sistema unificado de Registro de Ayudas</h1>\r\n        <label for=\"inputEmail\" class=\"visually-hidden\">Correo Electrónico</label>\r\n        <input type=\"email\" id=\"inputEmail\" class=\"form-control\" placeholder=\"Direccion de Correo Electrónico\" required=\"\" autofocus=\"\">\r\n        <label for=\"inputPassword\" class=\"visually-hidden\">Contraseña</label>\r\n        <input type=\"password\" id=\"inputPassword\" class=\"form-control\" placeholder=\"Contraseña\" required=\"\">\r\n        <button class=\"w-100 btn btn-lg btn-primary\" type=\"submit\" (click)=\"login()\">Iniciar Sesion</button>\r\n        <p>\r\n            <br>\r\n            <a href=\"#\">He olvidado mi Contraseña</a>\r\n        </p>\r\n        <p class=\"mt-5 mb-3 text-muted\">© 2021</p>\r\n      </form>\r\n    </main>\r\n    \r\n    \r\n        \r\n      \r\n    \r\n    </body>";
    /***/
  },

  /***/
  "./node_modules/raw-loader/dist/cjs.js!./src/app/pages/estadisticas/estadisticas.component.html":
  /*!******************************************************************************************************!*\
    !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/pages/estadisticas/estadisticas.component.html ***!
    \******************************************************************************************************/

  /*! exports provided: default */

  /***/
  function node_modulesRawLoaderDistCjsJsSrcAppPagesEstadisticasEstadisticasComponentHtml(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "<p>estadisticas works!</p>\r\n";
    /***/
  },

  /***/
  "./node_modules/raw-loader/dist/cjs.js!./src/app/pages/inicio/inicio.component.html":
  /*!******************************************************************************************!*\
    !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/pages/inicio/inicio.component.html ***!
    \******************************************************************************************/

  /*! exports provided: default */

  /***/
  function node_modulesRawLoaderDistCjsJsSrcAppPagesInicioInicioComponentHtml(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "<div class=\"jumbotron\">\r\n    <h1 class=\"display-4\">Sistema de Registro de Ayudas</h1>\r\n    <p class=\"lead\">This is a simple hero unit, a simple jumbotron-style component for calling extra attention to featured content or information.</p>\r\n    <hr class=\"my-4\">\r\n    <p>It uses utility classes for typography and spacing to space content out within the larger container.</p>\r\n    <p class=\"lead\">\r\n      <a class=\"btn btn-primary btn-lg\" [routerLink]=\"['/registrarSolicitud']\" role=\"routbutton\">Registrar Solicitud de Ayuda</a>\r\n    </p>\r\n  </div>";
    /***/
  },

  /***/
  "./node_modules/raw-loader/dist/cjs.js!./src/app/pages/registro-solicitud/registro-solicitud.component.html":
  /*!******************************************************************************************************************!*\
    !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/pages/registro-solicitud/registro-solicitud.component.html ***!
    \******************************************************************************************************************/

  /*! exports provided: default */

  /***/
  function node_modulesRawLoaderDistCjsJsSrcAppPagesRegistroSolicitudRegistroSolicitudComponentHtml(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "<ng-template #customItemTemplate let-model=\"item\" let-index=\"index\">\r\n    <label>{{model.nombre}}</label>\r\n</ng-template>\r\n\r\nvalues: {{solicitudAyudaForm.value | json}} <br/>\r\nstatus: {{solicitudAyudaForm.value.status}} <br/>\r\n\r\n<form [formGroup]=\"solicitudAyudaForm\" (ngSubmit)=\"onSubmit()\">\r\n    <app-loading [show]=\"isLoading()\"></app-loading>\r\n    \r\n    <fieldset>\r\n        <legend>Datos del solicitante</legend>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-4\">\r\n                <label>Cedula Solicitante</label>\r\n                <input type=\"text\" class=\"form-control\" mask=\"000-0000000-0\" formControlName=\"cedula\" required minlength=\"11\">\r\n                \r\n                <app-validation-error-message *ngIf=\"GetErrors('cedula', 'required')\" textMessage = \"La cedula es requerida\"></app-validation-error-message>\r\n                <app-validation-error-message *ngIf=\"GetErrors('cedula', 'minlength')\" textMessage = \"La cedula debe contener 11 digitos\"></app-validation-error-message>\r\n                \r\n            </div>\r\n            <div class=\"col-md-4\">\r\n                <label>Nombre Completo</label>\r\n                <input type=\"text\" class=\"form-control\" formControlName=\"nombreCompleto\"  minlength=\"5\" required>\r\n                <app-validation-error-message *ngIf=\"GetErrors('nombreCompleto', 'minlength')\" textMessage = \"El nombre debe contener al menos 5 letras\"></app-validation-error-message>\r\n                <app-validation-error-message *ngIf=\"GetErrors('nombreCompleto', 'required')\" textMessage = \"El nombre es obligatorio\"></app-validation-error-message>\r\n            </div>\r\n            <div class=\"col-md-2\">\r\n                <label>Fecha Nacimiento</label>\r\n                <input class=\"form-control\" bsDatepicker formControlName=\"fechaNacimiento\" required>\r\n                <app-validation-error-message *ngIf=\"GetErrors('fechaNacimiento', 'required')\" textMessage = \"La fecha de nacimiento es obligatoria\"></app-validation-error-message>\r\n            </div>\r\n            <div class=\"col-md-2\">\r\n                <label>Sexo</label>\r\n                <select class=\"form-control\" formControlName=\"sexo\" required>\r\n                    <option [ngValue] = \"null\">--SELECCIONE--</option>\r\n                    <option value=\"F\">Femenino</option>\r\n                    <option value=\"M\">Masculino</option>\r\n                </select>\r\n                <app-validation-error-message *ngIf=\"GetErrors('sexo', 'required')\" textMessage = \"El sexo es obligatorio\"></app-validation-error-message>\r\n                {{solicitudAyudaForm.get('sexo').value}}\r\n            </div>\r\n    \r\n        \r\n      \r\n        </div>\r\n    </fieldset>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <label>Seccional</label>        \r\n            <div>\r\n                <input class=\"form-control\" \r\n                formControlName=\"seccional\"\r\n                [typeahead]=\"seccionales\" \r\n                [adaptivePosition]=\"true\"\r\n                [typeaheadItemTemplate]=\"customItemTemplate\" \r\n                typeaheadOptionField=\"nombre\"\r\n                (typeaheadOnSelect)=\"typeaheadOnSelect($event)\" \r\n                [disabled]=\"selectedSeccional\"\r\n                placeholder=\"Empiece a escribir y seleccione uno de la lista desplegada\"\r\n                required\r\n                >\r\n    \r\n                <button class=\"btn btn-danger\" *ngIf=\"selectedSeccional\" (click)=\"removerSeccional()\">Remover</button>\r\n\r\n                <app-validation-error-message *ngIf=\"GetErrors('seccional', 'required')\" textMessage = \"la seccional es obligatoria\"></app-validation-error-message>\r\n            </div>\r\n    \r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-6\">\r\n            <label>Tipo de Ayuda</label>\r\n            <select class=\"form-control\" formControlName=\"tipoDeAyuda\" (change) = \"onChangeTipoSolicitud($event.target.value)\" required>\r\n                <option  [ngValue] = \"null\">--SELECCIONE--</option>\r\n                <option *ngFor=\"let s of tiposSolicitudes\" value=\"{{s.id}}\">{{s.nombre}}</option>\r\n            </select>\r\n            <app-validation-error-message *ngIf=\"GetErrors('tipoDeAyuda', 'required')\" textMessage = \"Tipo de Ayuda es obligatorio\"></app-validation-error-message>\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <label>Monto De la Ayuda</label>\r\n            <input style=\"color: blue;font-weight: bold;\" type=\"text\" class=\"form-control\" mask=\"separator.2\"\r\n                thousandSeparator=\",\" formControlName=\"montoAyuda\" required>\r\n                <app-validation-error-message *ngIf=\"GetErrors('montoAyuda', 'required')\" textMessage = \"Monto de Ayuda es obligatorio\"></app-validation-error-message>\r\n        </div>\r\n    </div>\r\n    \r\n    <fieldset>\r\n        <legend>Datos de Contacto</legend>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-2\">\r\n                <label>Telefono Celular</label>\r\n                <input type=\"text\" class=\"form-control\" mask=\"000-000-0000\" formControlName = \"telefonoCelular\">\r\n                <app-validation-error-message *ngIf=\"GetErrors('telefonoCelular', 'required')\" textMessage = \"Celular es requerido\"></app-validation-error-message>\r\n            </div>\r\n            <div class=\"col-md-2\">\r\n                <label>Telefono Residencial</label>\r\n                <input type=\"text\" class=\"form-control\" mask=\"000-000-0000\" formControlName = \"telefonoResidencia\">\r\n            </div>\r\n            <div class=\"col-md-2\">\r\n                <label>Telefono Laboral</label>\r\n                <input type=\"text\" class=\"form-control\" mask=\"000-000-0000\" formControlName=\"telefonoLaboral\" required>\r\n                <app-validation-error-message *ngIf=\"GetErrors('telefonoLaboral', 'required')\" textMessage = \"Telefono laboral es requerido\"></app-validation-error-message>\r\n            </div>\r\n            <div class=\"col-md-4\">\r\n                <label>Correo Electrónico</label>\r\n                <input type=\"email\" class=\"form-control\" formControlName=\"email\">\r\n                <app-validation-error-message *ngIf=\"GetErrors('email', 'email')\" textMessage = \"El email es inválido, favor corregir\"></app-validation-error-message>\r\n\r\n                {{solicitudAyudaForm.get('email').errors}}\r\n            </div>   \r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <label>Direccion</label>\r\n                <textarea class=\"form-control\" cols=\"2\" required formControlName=\"direccion\" required></textarea>\r\n                <app-validation-error-message *ngIf=\"GetErrors('direccion', 'required')\" textMessage = \"La direccion es requerida\"></app-validation-error-message>\r\n            </div>\r\n      \r\n        </div>\r\n    </fieldset>\r\n    \r\n    \r\n    <div class=\"row\">\r\n      \r\n    </div>\r\n    \r\n    <div class=\"row\">\r\n        <div class=\"col-md-6\">\r\n    \r\n            <fieldset>\r\n                <legend>Requisitos</legend>\r\n    \r\n               <div class=\"row\" *ngFor=\"let r of RequisitosSolicitud\">\r\n                   <div class=\"col-md-12\" *ngIf=\"r.values.length == 0\">\r\n                    <label>\r\n                        <input type=\"checkbox\" [formControlName]=\"r.formName\" required >\r\n                        {{r.descripcion}}\r\n                    </label>\r\n                    <app-validation-error-message *ngIf=\"GetErrors(r.formName, 'required')\" textMessage = \"La verificación es obligatoria\"></app-validation-error-message>\r\n                   </div>\r\n    \r\n                   <div class=\"col-md-12\" *ngIf=\"r.values.length > 0\" >\r\n                    <label>\r\n                        <label>{{r.nombre}}</label>\r\n                        <select class=\"form-control\" [formControlName]=\"r.formName\" required>\r\n                            <option  [ngValue] = \"null\">--SELECCIONE--</option>\r\n                            <option  *ngFor=\"let o of r.values\" value=\"{{o}}\">{{o}}</option>\r\n                        </select>\r\n                        <app-validation-error-message *ngIf=\"GetErrors(r.formName, 'required')\" textMessage = \"Este dato es obligatorio\"></app-validation-error-message>\r\n                    </label>\r\n                   </div>\r\n             \r\n                <br>\r\n               </div>\r\n    \r\n                <div class=\"row\">\r\n                    <div class=\"col-md-12\">\r\n                        <label>Quien recibira ayuda?</label>\r\n                        <select class=\"form-control\" formControlName=\"quienRecibeAyuda\" required>\r\n                            <option  [ngValue] = \"null\">--SELECCIONE--</option>\r\n                            <option value=\"1\">El Solicitante</option>\r\n                            <option value=\"2\">Hijo/Hija</option>\r\n                            <option value=\"3\">Padre/Madre</option>\r\n                            <option value=\"4\">Conyuge o Esposa/Esposo</option>\r\n                        </select>\r\n\r\n                        <app-validation-error-message *ngIf=\"GetErrors('quienRecibeAyuda', 'required')\" textMessage = \"Este dato es obligatorio\"></app-validation-error-message>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\" *ngIf=\"Solicitud.ayudapara == 2\">\r\n                    <div class=\"col-md-12\">\r\n                        <label>\r\n                            <input type=\"checkbox\">\r\n                            Acta de Nacimiento de Hijo/Hija\r\n                        </label>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\" *ngIf=\"Solicitud.ayudapara == 3\">\r\n                    <div class=\"col-md-12\">\r\n                        <label>\r\n                            <input type=\"checkbox\">\r\n                            Copia cedula de padra/madre\r\n                        </label>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\" *ngIf=\"Solicitud.ayudapara == 4\">\r\n                    <div class=\"col-md-12\">\r\n                        <label>\r\n                            <input type=\"checkbox\">\r\n                            Acta de matrimonio/union libre\r\n                        </label>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-12\">\r\n                        <label>\r\n                            Solicitante es jubilado de Inabima?\r\n                        </label>\r\n                        <br>\r\n                        <label>\r\n                            Si\r\n                            <input type=\"radio\" value=\"true\" name=\"inabima\" >\r\n                        </label>\r\n                        &nbsp;\r\n                        <label>\r\n                            No\r\n                            <input type=\"radio\" value=\"false\" name=\"inabima\">\r\n                        </label>\r\n    \r\n    \r\n                    </div>\r\n                </div>\r\n    \r\n                <div class=\"row\" *ngIf=\"esJubiladoInabima()\">\r\n                    <div class=\"col-md-12\">\r\n                        <label>\r\n                            <input type=\"checkbox\">\r\n                            Estado de cuenta Jubilado de Inabima-Hacienda\r\n                        </label>\r\n                    </div>\r\n                </div>\r\n            </fieldset>\r\n    \r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <fieldset>\r\n                <legend>Archivos Adjuntos</legend>\r\n                <ul>\r\n                    <li *ngFor=\"let file of Solicitud.adjuntos\"></li>\r\n                </ul>\r\n               <app-file-uploader></app-file-uploader>\r\n            </fieldset>\r\n        </div>\r\n    </div>\r\n    \r\n    \r\n    <fieldset>\r\n        <legend>Motivo de la Solicitud</legend>\r\n        <textarea class=\"form-control\" rows=\"4\"></textarea>\r\n        <br>\r\n    </fieldset>\r\n    \r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\" pull-right\">\r\n                <input type=\"button\" class=\"btn btn-success\" value=\"Registrar Solicitud\" (click)=\"registrarSolicitud()\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n</form>\r\n\r\n\r\n";
    /***/
  },

  /***/
  "./node_modules/tslib/tslib.es6.js":
  /*!*****************************************!*\
    !*** ./node_modules/tslib/tslib.es6.js ***!
    \*****************************************/

  /*! exports provided: __extends, __assign, __rest, __decorate, __param, __metadata, __awaiter, __generator, __createBinding, __exportStar, __values, __read, __spread, __spreadArrays, __await, __asyncGenerator, __asyncDelegator, __asyncValues, __makeTemplateObject, __importStar, __importDefault, __classPrivateFieldGet, __classPrivateFieldSet */

  /***/
  function node_modulesTslibTslibEs6Js(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__extends", function () {
      return __extends;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__assign", function () {
      return _assign;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__rest", function () {
      return __rest;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__decorate", function () {
      return __decorate;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__param", function () {
      return __param;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__metadata", function () {
      return __metadata;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__awaiter", function () {
      return __awaiter;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__generator", function () {
      return __generator;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__createBinding", function () {
      return __createBinding;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__exportStar", function () {
      return __exportStar;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__values", function () {
      return __values;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__read", function () {
      return __read;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__spread", function () {
      return __spread;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__spreadArrays", function () {
      return __spreadArrays;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__await", function () {
      return __await;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__asyncGenerator", function () {
      return __asyncGenerator;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__asyncDelegator", function () {
      return __asyncDelegator;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__asyncValues", function () {
      return __asyncValues;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__makeTemplateObject", function () {
      return __makeTemplateObject;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__importStar", function () {
      return __importStar;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__importDefault", function () {
      return __importDefault;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__classPrivateFieldGet", function () {
      return __classPrivateFieldGet;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "__classPrivateFieldSet", function () {
      return __classPrivateFieldSet;
    });
    /*! *****************************************************************************
    Copyright (c) Microsoft Corporation.
    
    Permission to use, copy, modify, and/or distribute this software for any
    purpose with or without fee is hereby granted.
    
    THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH
    REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY
    AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT,
    INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM
    LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR
    OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR
    PERFORMANCE OF THIS SOFTWARE.
    ***************************************************************************** */

    /* global Reflect, Promise */


    var _extendStatics = function extendStatics(d, b) {
      _extendStatics = Object.setPrototypeOf || {
        __proto__: []
      } instanceof Array && function (d, b) {
        d.__proto__ = b;
      } || function (d, b) {
        for (var p in b) {
          if (b.hasOwnProperty(p)) d[p] = b[p];
        }
      };

      return _extendStatics(d, b);
    };

    function __extends(d, b) {
      _extendStatics(d, b);

      function __() {
        this.constructor = d;
      }

      d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    }

    var _assign = function __assign() {
      _assign = Object.assign || function __assign(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
          s = arguments[i];

          for (var p in s) {
            if (Object.prototype.hasOwnProperty.call(s, p)) t[p] = s[p];
          }
        }

        return t;
      };

      return _assign.apply(this, arguments);
    };

    function __rest(s, e) {
      var t = {};

      for (var p in s) {
        if (Object.prototype.hasOwnProperty.call(s, p) && e.indexOf(p) < 0) t[p] = s[p];
      }

      if (s != null && typeof Object.getOwnPropertySymbols === "function") for (var i = 0, p = Object.getOwnPropertySymbols(s); i < p.length; i++) {
        if (e.indexOf(p[i]) < 0 && Object.prototype.propertyIsEnumerable.call(s, p[i])) t[p[i]] = s[p[i]];
      }
      return t;
    }

    function __decorate(decorators, target, key, desc) {
      var c = arguments.length,
          r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
          d;
      if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
        if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
      }
      return c > 3 && r && Object.defineProperty(target, key, r), r;
    }

    function __param(paramIndex, decorator) {
      return function (target, key) {
        decorator(target, key, paramIndex);
      };
    }

    function __metadata(metadataKey, metadataValue) {
      if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(metadataKey, metadataValue);
    }

    function __awaiter(thisArg, _arguments, P, generator) {
      function adopt(value) {
        return value instanceof P ? value : new P(function (resolve) {
          resolve(value);
        });
      }

      return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) {
          try {
            step(generator.next(value));
          } catch (e) {
            reject(e);
          }
        }

        function rejected(value) {
          try {
            step(generator["throw"](value));
          } catch (e) {
            reject(e);
          }
        }

        function step(result) {
          result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected);
        }

        step((generator = generator.apply(thisArg, _arguments || [])).next());
      });
    }

    function __generator(thisArg, body) {
      var _ = {
        label: 0,
        sent: function sent() {
          if (t[0] & 1) throw t[1];
          return t[1];
        },
        trys: [],
        ops: []
      },
          f,
          y,
          t,
          g;
      return g = {
        next: verb(0),
        "throw": verb(1),
        "return": verb(2)
      }, typeof Symbol === "function" && (g[Symbol.iterator] = function () {
        return this;
      }), g;

      function verb(n) {
        return function (v) {
          return step([n, v]);
        };
      }

      function step(op) {
        if (f) throw new TypeError("Generator is already executing.");

        while (_) {
          try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];

            switch (op[0]) {
              case 0:
              case 1:
                t = op;
                break;

              case 4:
                _.label++;
                return {
                  value: op[1],
                  done: false
                };

              case 5:
                _.label++;
                y = op[1];
                op = [0];
                continue;

              case 7:
                op = _.ops.pop();

                _.trys.pop();

                continue;

              default:
                if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) {
                  _ = 0;
                  continue;
                }

                if (op[0] === 3 && (!t || op[1] > t[0] && op[1] < t[3])) {
                  _.label = op[1];
                  break;
                }

                if (op[0] === 6 && _.label < t[1]) {
                  _.label = t[1];
                  t = op;
                  break;
                }

                if (t && _.label < t[2]) {
                  _.label = t[2];

                  _.ops.push(op);

                  break;
                }

                if (t[2]) _.ops.pop();

                _.trys.pop();

                continue;
            }

            op = body.call(thisArg, _);
          } catch (e) {
            op = [6, e];
            y = 0;
          } finally {
            f = t = 0;
          }
        }

        if (op[0] & 5) throw op[1];
        return {
          value: op[0] ? op[1] : void 0,
          done: true
        };
      }
    }

    function __createBinding(o, m, k, k2) {
      if (k2 === undefined) k2 = k;
      o[k2] = m[k];
    }

    function __exportStar(m, exports) {
      for (var p in m) {
        if (p !== "default" && !exports.hasOwnProperty(p)) exports[p] = m[p];
      }
    }

    function __values(o) {
      var s = typeof Symbol === "function" && Symbol.iterator,
          m = s && o[s],
          i = 0;
      if (m) return m.call(o);
      if (o && typeof o.length === "number") return {
        next: function next() {
          if (o && i >= o.length) o = void 0;
          return {
            value: o && o[i++],
            done: !o
          };
        }
      };
      throw new TypeError(s ? "Object is not iterable." : "Symbol.iterator is not defined.");
    }

    function __read(o, n) {
      var m = typeof Symbol === "function" && o[Symbol.iterator];
      if (!m) return o;
      var i = m.call(o),
          r,
          ar = [],
          e;

      try {
        while ((n === void 0 || n-- > 0) && !(r = i.next()).done) {
          ar.push(r.value);
        }
      } catch (error) {
        e = {
          error: error
        };
      } finally {
        try {
          if (r && !r.done && (m = i["return"])) m.call(i);
        } finally {
          if (e) throw e.error;
        }
      }

      return ar;
    }

    function __spread() {
      for (var ar = [], i = 0; i < arguments.length; i++) {
        ar = ar.concat(__read(arguments[i]));
      }

      return ar;
    }

    function __spreadArrays() {
      for (var s = 0, i = 0, il = arguments.length; i < il; i++) {
        s += arguments[i].length;
      }

      for (var r = Array(s), k = 0, i = 0; i < il; i++) {
        for (var a = arguments[i], j = 0, jl = a.length; j < jl; j++, k++) {
          r[k] = a[j];
        }
      }

      return r;
    }

    ;

    function __await(v) {
      return this instanceof __await ? (this.v = v, this) : new __await(v);
    }

    function __asyncGenerator(thisArg, _arguments, generator) {
      if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
      var g = generator.apply(thisArg, _arguments || []),
          i,
          q = [];
      return i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () {
        return this;
      }, i;

      function verb(n) {
        if (g[n]) i[n] = function (v) {
          return new Promise(function (a, b) {
            q.push([n, v, a, b]) > 1 || resume(n, v);
          });
        };
      }

      function resume(n, v) {
        try {
          step(g[n](v));
        } catch (e) {
          settle(q[0][3], e);
        }
      }

      function step(r) {
        r.value instanceof __await ? Promise.resolve(r.value.v).then(fulfill, reject) : settle(q[0][2], r);
      }

      function fulfill(value) {
        resume("next", value);
      }

      function reject(value) {
        resume("throw", value);
      }

      function settle(f, v) {
        if (f(v), q.shift(), q.length) resume(q[0][0], q[0][1]);
      }
    }

    function __asyncDelegator(o) {
      var i, p;
      return i = {}, verb("next"), verb("throw", function (e) {
        throw e;
      }), verb("return"), i[Symbol.iterator] = function () {
        return this;
      }, i;

      function verb(n, f) {
        i[n] = o[n] ? function (v) {
          return (p = !p) ? {
            value: __await(o[n](v)),
            done: n === "return"
          } : f ? f(v) : v;
        } : f;
      }
    }

    function __asyncValues(o) {
      if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
      var m = o[Symbol.asyncIterator],
          i;
      return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () {
        return this;
      }, i);

      function verb(n) {
        i[n] = o[n] && function (v) {
          return new Promise(function (resolve, reject) {
            v = o[n](v), settle(resolve, reject, v.done, v.value);
          });
        };
      }

      function settle(resolve, reject, d, v) {
        Promise.resolve(v).then(function (v) {
          resolve({
            value: v,
            done: d
          });
        }, reject);
      }
    }

    function __makeTemplateObject(cooked, raw) {
      if (Object.defineProperty) {
        Object.defineProperty(cooked, "raw", {
          value: raw
        });
      } else {
        cooked.raw = raw;
      }

      return cooked;
    }

    ;

    function __importStar(mod) {
      if (mod && mod.__esModule) return mod;
      var result = {};
      if (mod != null) for (var k in mod) {
        if (Object.hasOwnProperty.call(mod, k)) result[k] = mod[k];
      }
      result["default"] = mod;
      return result;
    }

    function __importDefault(mod) {
      return mod && mod.__esModule ? mod : {
        "default": mod
      };
    }

    function __classPrivateFieldGet(receiver, privateMap) {
      if (!privateMap.has(receiver)) {
        throw new TypeError("attempted to get private field on non-instance");
      }

      return privateMap.get(receiver);
    }

    function __classPrivateFieldSet(receiver, privateMap, value) {
      if (!privateMap.has(receiver)) {
        throw new TypeError("attempted to set private field on non-instance");
      }

      privateMap.set(receiver, value);
      return value;
    }
    /***/

  },

  /***/
  "./src/app/HttpInterceptor/AppHttpInterceptor.ts":
  /*!*******************************************************!*\
    !*** ./src/app/HttpInterceptor/AppHttpInterceptor.ts ***!
    \*******************************************************/

  /*! exports provided: AppHttpInterceptor */

  /***/
  function srcAppHttpInterceptorAppHttpInterceptorTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AppHttpInterceptor", function () {
      return AppHttpInterceptor;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");

    var AppHttpInterceptor = /*#__PURE__*/function () {
      function AppHttpInterceptor() {
        _classCallCheck(this, AppHttpInterceptor);
      }

      _createClass(AppHttpInterceptor, [{
        key: "intercept",
        value: function intercept(req, next) {
          var token = 'Bearer 123456';
          var Authorization = token;
          return next.handle(req.clone({
            setHeaders: {
              Authorization: Authorization
            }
          }));
        }
      }]);

      return AppHttpInterceptor;
    }();
    /***/

  },

  /***/
  "./src/app/app-routing.module.ts":
  /*!***************************************!*\
    !*** ./src/app/app-routing.module.ts ***!
    \***************************************/

  /*! exports provided: AppRoutingModule */

  /***/
  function srcAppAppRoutingModuleTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function () {
      return AppRoutingModule;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/fesm2015/router.js");
    /* harmony import */


    var _login_login_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! ./login/login.component */
    "./src/app/login/login.component.ts");
    /* harmony import */


    var _pages_inicio_inicio_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! ./pages/inicio/inicio.component */
    "./src/app/pages/inicio/inicio.component.ts");
    /* harmony import */


    var _security_AuthGuardDefault__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! ./security/AuthGuardDefault */
    "./src/app/security/AuthGuardDefault.ts");
    /* harmony import */


    var _pages_registro_solicitud_registro_solicitud_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! ./pages/registro-solicitud/registro-solicitud.component */
    "./src/app/pages/registro-solicitud/registro-solicitud.component.ts");

    var routes = [{
      path: 'login',
      component: _login_login_component__WEBPACK_IMPORTED_MODULE_3__["LoginComponent"]
    }, {
      path: 'inicio',
      component: _pages_inicio_inicio_component__WEBPACK_IMPORTED_MODULE_4__["InicioComponent"],
      canActivate: [_security_AuthGuardDefault__WEBPACK_IMPORTED_MODULE_5__["AuthGuardDefault"]]
    }, {
      path: 'registrarSolicitud',
      component: _pages_registro_solicitud_registro_solicitud_component__WEBPACK_IMPORTED_MODULE_6__["RegistroSolicitudComponent"],
      canActivate: [_security_AuthGuardDefault__WEBPACK_IMPORTED_MODULE_5__["AuthGuardDefault"]]
    }, {
      path: '',
      redirectTo: 'inicio',
      pathMatch: 'full'
    }];

    var AppRoutingModule = function AppRoutingModule() {
      _classCallCheck(this, AppRoutingModule);
    };

    AppRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
      imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forRoot(routes)],
      exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
    })], AppRoutingModule);
    /***/
  },

  /***/
  "./src/app/app.component.css":
  /*!***********************************!*\
    !*** ./src/app/app.component.css ***!
    \***********************************/

  /*! exports provided: default */

  /***/
  function srcAppAppComponentCss(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FwcC5jb21wb25lbnQuY3NzIn0= */";
    /***/
  },

  /***/
  "./src/app/app.component.ts":
  /*!**********************************!*\
    !*** ./src/app/app.component.ts ***!
    \**********************************/

  /*! exports provided: AppComponent */

  /***/
  function srcAppAppComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AppComponent", function () {
      return AppComponent;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/fesm2015/router.js");

    var AppComponent = function AppComponent(router) {
      var _this = this;

      _classCallCheck(this, AppComponent);

      this.router = router;
      this.title = 'solicitudAyudasClient';
      this.showNav = false;
      this.router.events.subscribe(function (routerEvent) {
        if (routerEvent instanceof _angular_router__WEBPACK_IMPORTED_MODULE_2__["NavigationEnd"] && _this.router.url !== '/login') {
          _this.showNav = true;
        }
      });
    };

    AppComponent.ctorParameters = function () {
      return [{
        type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]
      }];
    };

    AppComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
      selector: 'app-root',
      template: tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! raw-loader!./app.component.html */
      "./node_modules/raw-loader/dist/cjs.js!./src/app/app.component.html"))["default"],
      styles: [tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! ./app.component.css */
      "./src/app/app.component.css"))["default"]]
    })], AppComponent);
    /***/
  },

  /***/
  "./src/app/app.module.ts":
  /*!*******************************!*\
    !*** ./src/app/app.module.ts ***!
    \*******************************/

  /*! exports provided: options, AppModule */

  /***/
  function srcAppAppModuleTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "options", function () {
      return options;
    });
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AppModule", function () {
      return AppModule;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/platform-browser */
    "./node_modules/@angular/platform-browser/fesm2015/platform-browser.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");
    /* harmony import */


    var _app_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! ./app-routing.module */
    "./src/app/app-routing.module.ts");
    /* harmony import */


    var _app_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! ./app.component */
    "./src/app/app.component.ts");
    /* harmony import */


    var _login_login_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! ./login/login.component */
    "./src/app/login/login.component.ts");
    /* harmony import */


    var _pages_inicio_inicio_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
    /*! ./pages/inicio/inicio.component */
    "./src/app/pages/inicio/inicio.component.ts");
    /* harmony import */


    var _pages_registro_solicitud_registro_solicitud_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(
    /*! ./pages/registro-solicitud/registro-solicitud.component */
    "./src/app/pages/registro-solicitud/registro-solicitud.component.ts");
    /* harmony import */


    var _security_AuthGuardDefault__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(
    /*! ./security/AuthGuardDefault */
    "./src/app/security/AuthGuardDefault.ts");
    /* harmony import */


    var _angular_common_http__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/fesm2015/http.js");
    /* harmony import */


    var _HttpInterceptor_AppHttpInterceptor__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(
    /*! ./HttpInterceptor/AppHttpInterceptor */
    "./src/app/HttpInterceptor/AppHttpInterceptor.ts");
    /* harmony import */


    var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(
    /*! @angular/platform-browser/animations */
    "./node_modules/@angular/platform-browser/fesm2015/animations.js");
    /* harmony import */


    var ngx_bootstrap_typeahead__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(
    /*! ngx-bootstrap/typeahead */
    "./node_modules/ngx-bootstrap/typeahead/fesm2015/ngx-bootstrap-typeahead.js");
    /* harmony import */


    var _common_loading_loading_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(
    /*! ./common/loading/loading.component */
    "./src/app/common/loading/loading.component.ts");
    /* harmony import */


    var _pages_estadisticas_estadisticas_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(
    /*! ./pages/estadisticas/estadisticas.component */
    "./src/app/pages/estadisticas/estadisticas.component.ts");
    /* harmony import */


    var ngx_mask__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(
    /*! ngx-mask */
    "./node_modules/ngx-mask/fesm2015/ngx-mask.js");
    /* harmony import */


    var ngx_bootstrap_datepicker__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(
    /*! ngx-bootstrap/datepicker */
    "./node_modules/ngx-bootstrap/datepicker/fesm2015/ngx-bootstrap-datepicker.js");
    /* harmony import */


    var _common_file_uploader_file_uploader_component__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(
    /*! ./common/file-uploader/file-uploader.component */
    "./src/app/common/file-uploader/file-uploader.component.ts");
    /* harmony import */


    var _angular_forms__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/fesm2015/forms.js");
    /* harmony import */


    var ngx_bootstrap_alert__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(
    /*! ngx-bootstrap/alert */
    "./node_modules/ngx-bootstrap/alert/fesm2015/ngx-bootstrap-alert.js");
    /* harmony import */


    var _common_validation_error_message_validation_error_message_component__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(
    /*! ./common/validation-error-message/validation-error-message.component */
    "./src/app/common/validation-error-message/validation-error-message.component.ts");

    var options = null;

    var AppModule = function AppModule() {
      _classCallCheck(this, AppModule);
    };

    AppModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["NgModule"])({
      declarations: [_app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"], _login_login_component__WEBPACK_IMPORTED_MODULE_5__["LoginComponent"], _pages_inicio_inicio_component__WEBPACK_IMPORTED_MODULE_6__["InicioComponent"], _pages_registro_solicitud_registro_solicitud_component__WEBPACK_IMPORTED_MODULE_7__["RegistroSolicitudComponent"], _common_loading_loading_component__WEBPACK_IMPORTED_MODULE_13__["LoadingComponent"], _pages_estadisticas_estadisticas_component__WEBPACK_IMPORTED_MODULE_14__["EstadisticasComponent"], _common_file_uploader_file_uploader_component__WEBPACK_IMPORTED_MODULE_17__["FileUploaderComponent"], _common_validation_error_message_validation_error_message_component__WEBPACK_IMPORTED_MODULE_20__["ValidationErrorMessageComponent"]],
      imports: [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__["BrowserModule"], _app_routing_module__WEBPACK_IMPORTED_MODULE_3__["AppRoutingModule"], _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_11__["BrowserAnimationsModule"], _angular_forms__WEBPACK_IMPORTED_MODULE_18__["FormsModule"], ngx_bootstrap_typeahead__WEBPACK_IMPORTED_MODULE_12__["TypeaheadModule"].forRoot(), _angular_common_http__WEBPACK_IMPORTED_MODULE_9__["HttpClientModule"], ngx_mask__WEBPACK_IMPORTED_MODULE_15__["NgxMaskModule"].forRoot(), ngx_bootstrap_datepicker__WEBPACK_IMPORTED_MODULE_16__["BsDatepickerModule"].forRoot(), _angular_forms__WEBPACK_IMPORTED_MODULE_18__["ReactiveFormsModule"], ngx_bootstrap_alert__WEBPACK_IMPORTED_MODULE_19__["AlertModule"].forRoot()],
      providers: [_security_AuthGuardDefault__WEBPACK_IMPORTED_MODULE_8__["AuthGuardDefault"], {
        provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_9__["HTTP_INTERCEPTORS"],
        useClass: _HttpInterceptor_AppHttpInterceptor__WEBPACK_IMPORTED_MODULE_10__["AppHttpInterceptor"],
        multi: true
      }],
      bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"]]
    })], AppModule);
    /***/
  },

  /***/
  "./src/app/common/file-uploader/file-uploader.component.css":
  /*!******************************************************************!*\
    !*** ./src/app/common/file-uploader/file-uploader.component.css ***!
    \******************************************************************/

  /*! exports provided: default */

  /***/
  function srcAppCommonFileUploaderFileUploaderComponentCss(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbW1vbi9maWxlLXVwbG9hZGVyL2ZpbGUtdXBsb2FkZXIuY29tcG9uZW50LmNzcyJ9 */";
    /***/
  },

  /***/
  "./src/app/common/file-uploader/file-uploader.component.ts":
  /*!*****************************************************************!*\
    !*** ./src/app/common/file-uploader/file-uploader.component.ts ***!
    \*****************************************************************/

  /*! exports provided: FileUploaderComponent */

  /***/
  function srcAppCommonFileUploaderFileUploaderComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "FileUploaderComponent", function () {
      return FileUploaderComponent;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");
    /* harmony import */


    var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! rxjs */
    "./node_modules/rxjs/_esm2015/index.js");

    var FileUploaderComponent = /*#__PURE__*/function () {
      function FileUploaderComponent() {
        _classCallCheck(this, FileUploaderComponent);

        this.files = [];
      }

      _createClass(FileUploaderComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          var _this2 = this;

          this.file = document.getElementById("fileuploader");
          this.FileChage$ = Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["fromEvent"])(this.file, 'change');
          this.FileChage$.subscribe(function (event) {
            var file = event.srcElement.files[0];

            _this2.files.push(file);
          });
        }
      }, {
        key: "AgregarAdjunto",
        value: function AgregarAdjunto() {
          this.file.click();
        }
      }]);

      return FileUploaderComponent;
    }();

    FileUploaderComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
      selector: 'app-file-uploader',
      template: tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! raw-loader!./file-uploader.component.html */
      "./node_modules/raw-loader/dist/cjs.js!./src/app/common/file-uploader/file-uploader.component.html"))["default"],
      styles: [tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! ./file-uploader.component.css */
      "./src/app/common/file-uploader/file-uploader.component.css"))["default"]]
    })], FileUploaderComponent);
    /***/
  },

  /***/
  "./src/app/common/loading/loading.component.css":
  /*!******************************************************!*\
    !*** ./src/app/common/loading/loading.component.css ***!
    \******************************************************/

  /*! exports provided: default */

  /***/
  function srcAppCommonLoadingLoadingComponentCss(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbW1vbi9sb2FkaW5nL2xvYWRpbmcuY29tcG9uZW50LmNzcyJ9 */";
    /***/
  },

  /***/
  "./src/app/common/loading/loading.component.ts":
  /*!*****************************************************!*\
    !*** ./src/app/common/loading/loading.component.ts ***!
    \*****************************************************/

  /*! exports provided: LoadingComponent */

  /***/
  function srcAppCommonLoadingLoadingComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "LoadingComponent", function () {
      return LoadingComponent;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");

    var LoadingComponent = /*#__PURE__*/function () {
      function LoadingComponent() {
        _classCallCheck(this, LoadingComponent);
      }

      _createClass(LoadingComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }]);

      return LoadingComponent;
    }();

    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])()], LoadingComponent.prototype, "show", void 0);
    LoadingComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
      selector: 'app-loading',
      template: tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! raw-loader!./loading.component.html */
      "./node_modules/raw-loader/dist/cjs.js!./src/app/common/loading/loading.component.html"))["default"],
      styles: [tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! ./loading.component.css */
      "./src/app/common/loading/loading.component.css"))["default"]]
    })], LoadingComponent);
    /***/
  },

  /***/
  "./src/app/common/validation-error-message/validation-error-message.component.css":
  /*!****************************************************************************************!*\
    !*** ./src/app/common/validation-error-message/validation-error-message.component.css ***!
    \****************************************************************************************/

  /*! exports provided: default */

  /***/
  function srcAppCommonValidationErrorMessageValidationErrorMessageComponentCss(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbW1vbi92YWxpZGF0aW9uLWVycm9yLW1lc3NhZ2UvdmFsaWRhdGlvbi1lcnJvci1tZXNzYWdlLmNvbXBvbmVudC5jc3MifQ== */";
    /***/
  },

  /***/
  "./src/app/common/validation-error-message/validation-error-message.component.ts":
  /*!***************************************************************************************!*\
    !*** ./src/app/common/validation-error-message/validation-error-message.component.ts ***!
    \***************************************************************************************/

  /*! exports provided: ValidationErrorMessageComponent */

  /***/
  function srcAppCommonValidationErrorMessageValidationErrorMessageComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "ValidationErrorMessageComponent", function () {
      return ValidationErrorMessageComponent;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");

    var ValidationErrorMessageComponent = /*#__PURE__*/function () {
      function ValidationErrorMessageComponent() {
        _classCallCheck(this, ValidationErrorMessageComponent);
      }

      _createClass(ValidationErrorMessageComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }]);

      return ValidationErrorMessageComponent;
    }();

    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])()], ValidationErrorMessageComponent.prototype, "textMessage", void 0);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])()], ValidationErrorMessageComponent.prototype, "formControl", void 0);
    ValidationErrorMessageComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
      selector: 'app-validation-error-message',
      template: tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! raw-loader!./validation-error-message.component.html */
      "./node_modules/raw-loader/dist/cjs.js!./src/app/common/validation-error-message/validation-error-message.component.html"))["default"],
      styles: [tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! ./validation-error-message.component.css */
      "./src/app/common/validation-error-message/validation-error-message.component.css"))["default"]]
    })], ValidationErrorMessageComponent);
    /***/
  },

  /***/
  "./src/app/login/login.component.css":
  /*!*******************************************!*\
    !*** ./src/app/login/login.component.css ***!
    \*******************************************/

  /*! exports provided: default */

  /***/
  function srcAppLoginLoginComponentCss(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "html,\r\nbody {\r\n  height: 100%;\r\n}\r\n\r\nbody {\r\n  display: flex;\r\n  align-items: center;\r\n  padding-top: 40px;\r\n  padding-bottom: 40px;\r\n  background-color: #f5f5f5;\r\n}\r\n\r\n.form-signin {\r\n  width: 100%;\r\n  max-width: 330px;\r\n  padding: 15px;\r\n  margin: auto;\r\n}\r\n\r\n.form-signin .checkbox {\r\n  font-weight: 400;\r\n}\r\n\r\n.form-signin .form-control {\r\n  position: relative;\r\n  box-sizing: border-box;\r\n  height: auto;\r\n  padding: 10px;\r\n  font-size: 16px;\r\n}\r\n\r\n.form-signin .form-control:focus {\r\n  z-index: 2;\r\n}\r\n\r\n.form-signin input[type=\"email\"] {\r\n  margin-bottom: -1px;\r\n  border-bottom-right-radius: 0;\r\n  border-bottom-left-radius: 0;\r\n}\r\n\r\n.form-signin input[type=\"password\"] {\r\n  margin-bottom: 10px;\r\n  border-top-left-radius: 0;\r\n  border-top-right-radius: 0;\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbG9naW4vbG9naW4uY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTs7RUFFRSxZQUFZO0FBQ2Q7O0FBRUE7RUFDRSxhQUFhO0VBQ2IsbUJBQW1CO0VBQ25CLGlCQUFpQjtFQUNqQixvQkFBb0I7RUFDcEIseUJBQXlCO0FBQzNCOztBQUVBO0VBQ0UsV0FBVztFQUNYLGdCQUFnQjtFQUNoQixhQUFhO0VBQ2IsWUFBWTtBQUNkOztBQUNBO0VBQ0UsZ0JBQWdCO0FBQ2xCOztBQUNBO0VBQ0Usa0JBQWtCO0VBQ2xCLHNCQUFzQjtFQUN0QixZQUFZO0VBQ1osYUFBYTtFQUNiLGVBQWU7QUFDakI7O0FBQ0E7RUFDRSxVQUFVO0FBQ1o7O0FBQ0E7RUFDRSxtQkFBbUI7RUFDbkIsNkJBQTZCO0VBQzdCLDRCQUE0QjtBQUM5Qjs7QUFDQTtFQUNFLG1CQUFtQjtFQUNuQix5QkFBeUI7RUFDekIsMEJBQTBCO0FBQzVCIiwiZmlsZSI6InNyYy9hcHAvbG9naW4vbG9naW4uY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbImh0bWwsXHJcbmJvZHkge1xyXG4gIGhlaWdodDogMTAwJTtcclxufVxyXG5cclxuYm9keSB7XHJcbiAgZGlzcGxheTogZmxleDtcclxuICBhbGlnbi1pdGVtczogY2VudGVyO1xyXG4gIHBhZGRpbmctdG9wOiA0MHB4O1xyXG4gIHBhZGRpbmctYm90dG9tOiA0MHB4O1xyXG4gIGJhY2tncm91bmQtY29sb3I6ICNmNWY1ZjU7XHJcbn1cclxuXHJcbi5mb3JtLXNpZ25pbiB7XHJcbiAgd2lkdGg6IDEwMCU7XHJcbiAgbWF4LXdpZHRoOiAzMzBweDtcclxuICBwYWRkaW5nOiAxNXB4O1xyXG4gIG1hcmdpbjogYXV0bztcclxufVxyXG4uZm9ybS1zaWduaW4gLmNoZWNrYm94IHtcclxuICBmb250LXdlaWdodDogNDAwO1xyXG59XHJcbi5mb3JtLXNpZ25pbiAuZm9ybS1jb250cm9sIHtcclxuICBwb3NpdGlvbjogcmVsYXRpdmU7XHJcbiAgYm94LXNpemluZzogYm9yZGVyLWJveDtcclxuICBoZWlnaHQ6IGF1dG87XHJcbiAgcGFkZGluZzogMTBweDtcclxuICBmb250LXNpemU6IDE2cHg7XHJcbn1cclxuLmZvcm0tc2lnbmluIC5mb3JtLWNvbnRyb2w6Zm9jdXMge1xyXG4gIHotaW5kZXg6IDI7XHJcbn1cclxuLmZvcm0tc2lnbmluIGlucHV0W3R5cGU9XCJlbWFpbFwiXSB7XHJcbiAgbWFyZ2luLWJvdHRvbTogLTFweDtcclxuICBib3JkZXItYm90dG9tLXJpZ2h0LXJhZGl1czogMDtcclxuICBib3JkZXItYm90dG9tLWxlZnQtcmFkaXVzOiAwO1xyXG59XHJcbi5mb3JtLXNpZ25pbiBpbnB1dFt0eXBlPVwicGFzc3dvcmRcIl0ge1xyXG4gIG1hcmdpbi1ib3R0b206IDEwcHg7XHJcbiAgYm9yZGVyLXRvcC1sZWZ0LXJhZGl1czogMDtcclxuICBib3JkZXItdG9wLXJpZ2h0LXJhZGl1czogMDtcclxufVxyXG4iXX0= */";
    /***/
  },

  /***/
  "./src/app/login/login.component.ts":
  /*!******************************************!*\
    !*** ./src/app/login/login.component.ts ***!
    \******************************************/

  /*! exports provided: LoginComponent */

  /***/
  function srcAppLoginLoginComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "LoginComponent", function () {
      return LoginComponent;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/fesm2015/router.js");

    var LoginComponent = /*#__PURE__*/function () {
      function LoginComponent(router) {
        _classCallCheck(this, LoginComponent);

        this.router = router;
      }

      _createClass(LoginComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }, {
        key: "login",
        value: function login() {
          this.router.navigate(['/inicio']);
        }
      }]);

      return LoginComponent;
    }();

    LoginComponent.ctorParameters = function () {
      return [{
        type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]
      }];
    };

    LoginComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
      selector: 'app-login',
      template: tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! raw-loader!./login.component.html */
      "./node_modules/raw-loader/dist/cjs.js!./src/app/login/login.component.html"))["default"],
      styles: [tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! ./login.component.css */
      "./src/app/login/login.component.css"))["default"]]
    })], LoginComponent);
    /***/
  },

  /***/
  "./src/app/model/SolicitudAyuda.ts":
  /*!*****************************************!*\
    !*** ./src/app/model/SolicitudAyuda.ts ***!
    \*****************************************/

  /*! exports provided: SolicitudAyuda */

  /***/
  function srcAppModelSolicitudAyudaTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "SolicitudAyuda", function () {
      return SolicitudAyuda;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");

    var SolicitudAyuda = function SolicitudAyuda() {
      _classCallCheck(this, SolicitudAyuda);

      this.adjuntos = [];
    };
    /***/

  },

  /***/
  "./src/app/pages/estadisticas/estadisticas.component.css":
  /*!***************************************************************!*\
    !*** ./src/app/pages/estadisticas/estadisticas.component.css ***!
    \***************************************************************/

  /*! exports provided: default */

  /***/
  function srcAppPagesEstadisticasEstadisticasComponentCss(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL2VzdGFkaXN0aWNhcy9lc3RhZGlzdGljYXMuY29tcG9uZW50LmNzcyJ9 */";
    /***/
  },

  /***/
  "./src/app/pages/estadisticas/estadisticas.component.ts":
  /*!**************************************************************!*\
    !*** ./src/app/pages/estadisticas/estadisticas.component.ts ***!
    \**************************************************************/

  /*! exports provided: EstadisticasComponent */

  /***/
  function srcAppPagesEstadisticasEstadisticasComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "EstadisticasComponent", function () {
      return EstadisticasComponent;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");

    var EstadisticasComponent = /*#__PURE__*/function () {
      function EstadisticasComponent() {
        _classCallCheck(this, EstadisticasComponent);
      }

      _createClass(EstadisticasComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }]);

      return EstadisticasComponent;
    }();

    EstadisticasComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
      selector: 'app-estadisticas',
      template: tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! raw-loader!./estadisticas.component.html */
      "./node_modules/raw-loader/dist/cjs.js!./src/app/pages/estadisticas/estadisticas.component.html"))["default"],
      styles: [tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! ./estadisticas.component.css */
      "./src/app/pages/estadisticas/estadisticas.component.css"))["default"]]
    })], EstadisticasComponent);
    /***/
  },

  /***/
  "./src/app/pages/inicio/inicio.component.css":
  /*!***************************************************!*\
    !*** ./src/app/pages/inicio/inicio.component.css ***!
    \***************************************************/

  /*! exports provided: default */

  /***/
  function srcAppPagesInicioInicioComponentCss(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL2luaWNpby9pbmljaW8uY29tcG9uZW50LmNzcyJ9 */";
    /***/
  },

  /***/
  "./src/app/pages/inicio/inicio.component.ts":
  /*!**************************************************!*\
    !*** ./src/app/pages/inicio/inicio.component.ts ***!
    \**************************************************/

  /*! exports provided: InicioComponent */

  /***/
  function srcAppPagesInicioInicioComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "InicioComponent", function () {
      return InicioComponent;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");

    var InicioComponent = /*#__PURE__*/function () {
      function InicioComponent() {
        _classCallCheck(this, InicioComponent);
      }

      _createClass(InicioComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {}
      }]);

      return InicioComponent;
    }();

    InicioComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
      selector: 'app-inicio',
      template: tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! raw-loader!./inicio.component.html */
      "./node_modules/raw-loader/dist/cjs.js!./src/app/pages/inicio/inicio.component.html"))["default"],
      styles: [tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! ./inicio.component.css */
      "./src/app/pages/inicio/inicio.component.css"))["default"]]
    })], InicioComponent);
    /***/
  },

  /***/
  "./src/app/pages/registro-solicitud/registro-solicitud.component.css":
  /*!***************************************************************************!*\
    !*** ./src/app/pages/registro-solicitud/registro-solicitud.component.css ***!
    \***************************************************************************/

  /*! exports provided: default */

  /***/
  function srcAppPagesRegistroSolicitudRegistroSolicitudComponentCss(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony default export */


    __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL3JlZ2lzdHJvLXNvbGljaXR1ZC9yZWdpc3Ryby1zb2xpY2l0dWQuY29tcG9uZW50LmNzcyJ9 */";
    /***/
  },

  /***/
  "./src/app/pages/registro-solicitud/registro-solicitud.component.ts":
  /*!**************************************************************************!*\
    !*** ./src/app/pages/registro-solicitud/registro-solicitud.component.ts ***!
    \**************************************************************************/

  /*! exports provided: RegistroSolicitudComponent */

  /***/
  function srcAppPagesRegistroSolicitudRegistroSolicitudComponentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "RegistroSolicitudComponent", function () {
      return RegistroSolicitudComponent;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");
    /* harmony import */


    var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/fesm2015/forms.js");
    /* harmony import */


    var src_app_model_SolicitudAyuda__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! src/app/model/SolicitudAyuda */
    "./src/app/model/SolicitudAyuda.ts");
    /* harmony import */


    var src_app_services_data_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! src/app/services/data.service */
    "./src/app/services/data.service.ts");
    /* harmony import */


    var sweetalert2__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
    /*! sweetalert2 */
    "./node_modules/sweetalert2/dist/sweetalert2.all.js");
    /* harmony import */


    var sweetalert2__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_5__);

    var RegistroSolicitudComponent = /*#__PURE__*/function () {
      //end of form controls
      function RegistroSolicitudComponent(dataService, fb) {
        _classCallCheck(this, RegistroSolicitudComponent);

        this.dataService = dataService;
        this.fb = fb; //form controls:

        this.solicitudAyudaForm = new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormGroup"]({
          cedula: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          seccional: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          tipoDeAyuda: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          nombreCompleto: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          fechaNacimiento: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          quienRecibeAyuda: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          telefonoCelular: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          telefonoResidencia: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          telefonoLaboral: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          email: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          sexo: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          direccion: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"](''),
          montoAyuda: new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"]('')
        }); //this.fb
      }

      _createClass(RegistroSolicitudComponent, [{
        key: "isLoading",
        value: function isLoading() {
          return this.cargandoSeccionales;
        }
      }, {
        key: "typeaheadOnSelect",
        value: function typeaheadOnSelect(e) {
          this.selectedSeccional = e.item;
        }
      }, {
        key: "ngOnInit",
        value: function ngOnInit() {
          var _this3 = this;

          this.cargandoSeccionales = true;
          this.Solicitud = new src_app_model_SolicitudAyuda__WEBPACK_IMPORTED_MODULE_3__["SolicitudAyuda"](); // this.dataService.GetSeccionales().subscribe(data => {
          //   this.seccionales = data;
          //   this.cargandoSeccionales = false;
          // }, err => {
          //   this.cargandoSeccionales = false;
          // })

          this.dataService.GetTiposSolicitudesConRequisitos().subscribe(function (data) {
            _this3.tiposSolicitudes = data;
          }, function (err) {
            console.log(err);
          });
          this.cargandoSeccionales = false;
          this.seccionales = [{
            nombre: "Municipio Azua"
          }, {
            nombre: "Municipio Guayabal"
          }, {
            nombre: "Municipio Las Yayas"
          }, {
            nombre: "Municipio Padre las casas"
          }];
        }
      }, {
        key: "removerSeccional",
        value: function removerSeccional() {
          this.selectedSeccional = null;
          this.selected = null;
        }
      }, {
        key: "esJubiladoInabima",
        value: function esJubiladoInabima() {
          return this.Solicitud.esjubiladoinabima === 'true';
        }
      }, {
        key: "registrarSolicitud",
        value: function registrarSolicitud() {
          sweetalert2__WEBPACK_IMPORTED_MODULE_5___default.a.fire({
            title: 'Aviso',
            text: 'Solicitud de ayuda Nro# 2134 registrara satisfactoriamente',
            icon: 'info',
            showConfirmButton: true,
            showCloseButton: true,
            showCancelButton: true,
            confirmButtonText: 'Imprimir'
          });
        }
      }, {
        key: "AgregarAdjunto",
        value: function AgregarAdjunto() {
          this.Solicitud.adjuntos.push({});
        }
      }, {
        key: "onChangeTipoSolicitud",
        value: function onChangeTipoSolicitud(tipoSolicitud) {
          var _this4 = this;

          var tipoSolictud = this.tiposSolicitudes.filter(function (tipo) {
            return tipo.id == tipoSolicitud;
          })[0];
          console.log(tipoSolictud);
          var keys = [];
          Object.keys(this.solicitudAyudaForm.controls).forEach(function (key) {
            keys.push(key);
          });
          keys.filter(function (k) {
            k.startsWith("rd");
          }).forEach(function (key) {
            _this4.solicitudAyudaForm.removeControl(key);
          });

          if (tipoSolictud.requisitos.length > 0) {
            tipoSolictud.requisitos.forEach(function (element) {
              _this4.solicitudAyudaForm.addControl(element.formName, new _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormControl"]());
            });
          }

          console.log(this.solicitudAyudaForm.controls);
          this.RequisitosSolicitud = tipoSolictud.requisitos;
        }
      }, {
        key: "GetErrors",
        value: function GetErrors(fieldName, errorName) {
          var control = this.solicitudAyudaForm.get(fieldName);

          if (control.pristine || !control.errors) {
            return false;
          } else {
            return control.errors[errorName];
          }
        }
      }, {
        key: "onSubmit",
        value: function onSubmit() {
          console.log('form submitted');
        }
      }]);

      return RegistroSolicitudComponent;
    }();

    RegistroSolicitudComponent.ctorParameters = function () {
      return [{
        type: src_app_services_data_service__WEBPACK_IMPORTED_MODULE_4__["DataService"]
      }, {
        type: _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormBuilder"]
      }];
    };

    RegistroSolicitudComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
      selector: 'app-registro-solicitud',
      template: tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! raw-loader!./registro-solicitud.component.html */
      "./node_modules/raw-loader/dist/cjs.js!./src/app/pages/registro-solicitud/registro-solicitud.component.html"))["default"],
      styles: [tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(
      /*! ./registro-solicitud.component.css */
      "./src/app/pages/registro-solicitud/registro-solicitud.component.css"))["default"]]
    })], RegistroSolicitudComponent); //Mask plugin documentation
    //https://www.npmjs.com/package/ngx-mask

    /***/
  },

  /***/
  "./src/app/security/AuthGuardDefault.ts":
  /*!**********************************************!*\
    !*** ./src/app/security/AuthGuardDefault.ts ***!
    \**********************************************/

  /*! exports provided: AuthGuardDefault */

  /***/
  function srcAppSecurityAuthGuardDefaultTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "AuthGuardDefault", function () {
      return AuthGuardDefault;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");
    /* harmony import */


    var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/fesm2015/router.js"); // src/app/auth/auth-guard.service.ts


    var AuthGuardDefault = /*#__PURE__*/function () {
      function AuthGuardDefault(router) {
        _classCallCheck(this, AuthGuardDefault);

        this.router = router;
      }

      _createClass(AuthGuardDefault, [{
        key: "canActivate",
        value: function canActivate() {
          var canView = true;

          if (canView) {
            return true;
          }

          this.router.navigate(['login']);
          return false;
        }
      }]);

      return AuthGuardDefault;
    }();

    AuthGuardDefault.ctorParameters = function () {
      return [{
        type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]
      }];
    };

    AuthGuardDefault = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])()], AuthGuardDefault);
    /***/
  },

  /***/
  "./src/app/services/data.service.ts":
  /*!******************************************!*\
    !*** ./src/app/services/data.service.ts ***!
    \******************************************/

  /*! exports provided: DataService */

  /***/
  function srcAppServicesDataServiceTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "DataService", function () {
      return DataService;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");
    /* harmony import */


    var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/fesm2015/http.js");

    var DataService = /*#__PURE__*/function () {
      function DataService(http) {
        _classCallCheck(this, DataService);

        this.http = http;
      }

      _createClass(DataService, [{
        key: "GetTiposSolicitudesConRequisitos",
        value: function GetTiposSolicitudesConRequisitos() {
          return this.http.get('/api/TipoSolicitud/ConRequisitos');
        }
      }, {
        key: "GetSeccionales",
        value: function GetSeccionales() {
          return this.http.get('/api/seccionales');
        }
      }]);

      return DataService;
    }();

    DataService.ctorParameters = function () {
      return [{
        type: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"]
      }];
    };

    DataService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
      providedIn: 'root'
    })], DataService);
    /***/
  },

  /***/
  "./src/environments/environment.ts":
  /*!*****************************************!*\
    !*** ./src/environments/environment.ts ***!
    \*****************************************/

  /*! exports provided: environment */

  /***/
  function srcEnvironmentsEnvironmentTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony export (binding) */


    __webpack_require__.d(__webpack_exports__, "environment", function () {
      return environment;
    });
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js"); // This file can be replaced during build by using the `fileReplacements` array.
    // `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
    // The list of file replacements can be found in `angular.json`.


    var environment = {
      production: false
    };
    /*
     * For easier debugging in development mode, you can import the following file
     * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
     *
     * This import should be commented out in production mode because it will have a negative impact
     * on performance if an error is thrown.
     */
    // import 'zone.js/dist/zone-error';  // Included with Angular CLI.

    /***/
  },

  /***/
  "./src/main.ts":
  /*!*********************!*\
    !*** ./src/main.ts ***!
    \*********************/

  /*! no exports provided */

  /***/
  function srcMainTs(module, __webpack_exports__, __webpack_require__) {
    "use strict";

    __webpack_require__.r(__webpack_exports__);
    /* harmony import */


    var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
    /*! tslib */
    "./node_modules/tslib/tslib.es6.js");
    /* harmony import */


    var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/fesm2015/core.js");
    /* harmony import */


    var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
    /*! @angular/platform-browser-dynamic */
    "./node_modules/@angular/platform-browser-dynamic/fesm2015/platform-browser-dynamic.js");
    /* harmony import */


    var _app_app_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
    /*! ./app/app.module */
    "./src/app/app.module.ts");
    /* harmony import */


    var _environments_environment__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
    /*! ./environments/environment */
    "./src/environments/environment.ts");

    if (_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].production) {
      Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["enableProdMode"])();
    }

    Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_2__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_3__["AppModule"])["catch"](function (err) {
      return console.error(err);
    });
    /***/
  },

  /***/
  0:
  /*!***************************!*\
    !*** multi ./src/main.ts ***!
    \***************************/

  /*! no static exports found */

  /***/
  function _(module, exports, __webpack_require__) {
    module.exports = __webpack_require__(
    /*! C:\workspace\adp\solicitudAyudasClient\src\main.ts */
    "./src/main.ts");
    /***/
  }
}, [[0, "runtime", "vendor"]]]);
//# sourceMappingURL=main-es5.js.map