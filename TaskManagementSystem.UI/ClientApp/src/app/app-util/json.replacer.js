"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.JsonReplacer = void 0;
var JsonReplacer = /** @class */ (function () {
    function JsonReplacer() {
    }
    JsonReplacer.prototype.replacer = function (key, value) {
        if (typeof value === "string") {
            if (value == "")
                return undefined;
        }
        return value;
    };
    return JsonReplacer;
}());
exports.JsonReplacer = JsonReplacer;
//# sourceMappingURL=json.replacer.js.map