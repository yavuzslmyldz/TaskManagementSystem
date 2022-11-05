"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.TaskService = void 0;
var core_1 = require("@angular/core");
var TaskService = /** @class */ (function () {
    function TaskService(http, baseUrl) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.postRoute = this.baseUrl + "task";
        this._headers = { 'Content-Type': 'application/json' };
    }
    TaskService.prototype.create = function (_body) {
        return this.http.post(this.postRoute, _body, { headers: this._headers });
    };
    TaskService.prototype.update = function (_body) {
        return this.http.post(this.postRoute, _body, { headers: this._headers });
    };
    TaskService.prototype.delete = function (_params) {
        return this.http.delete(this.postRoute, { params: _params, headers: this._headers });
    };
    TaskService.prototype.get = function (_params) {
        return this.http.get(this.postRoute, { params: _params, headers: this._headers });
    };
    TaskService.prototype.getAll = function () {
        return this.http.get(this.postRoute + "/all", { headers: this._headers });
    };
    TaskService = __decorate([
        core_1.Injectable({
            providedIn: 'root',
        }),
        __param(1, core_1.Inject('BASE_URL'))
    ], TaskService);
    return TaskService;
}());
exports.TaskService = TaskService;
//# sourceMappingURL=task.service.js.map