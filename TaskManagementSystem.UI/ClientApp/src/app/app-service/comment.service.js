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
exports.CommentService = void 0;
var core_1 = require("@angular/core");
var CommentService = /** @class */ (function () {
    function CommentService(http, baseUrl) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.postRoute = this.baseUrl + "comment";
        this._headers = { 'Content-Type': 'application/json' };
    }
    CommentService.prototype.create = function (_body) {
        return this.http.post(this.postRoute, _body, { headers: this._headers });
    };
    CommentService.prototype.update = function (_body) {
        return this.http.put(this.postRoute, _body, { headers: this._headers });
    };
    CommentService.prototype.delete = function (_params) {
        return this.http.delete(this.postRoute, { params: _params, headers: this._headers });
    };
    CommentService.prototype.get = function (_params) {
        return this.http.get(this.postRoute, { params: _params, headers: this._headers });
    };
    CommentService.prototype.getAll = function (_params) {
        return this.http.get(this.postRoute + "/all", { params: _params, headers: this._headers });
    };
    CommentService = __decorate([
        core_1.Injectable({
            providedIn: 'root',
        }),
        __param(1, core_1.Inject('BASE_URL'))
    ], CommentService);
    return CommentService;
}());
exports.CommentService = CommentService;
//# sourceMappingURL=comment.service.js.map