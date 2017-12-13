var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX
var DoneItem = (function (_super) {
    __extends(DoneItem, _super);
    function DoneItem(props) {
        _super.call(this, props);
    }
    DoneItem.prototype.render = function () {
        return (React.createElement("div", {className: "col-md-6"}, React.createElement("div", {className: "todolist"}, React.createElement("h1", null, "Already Done"), React.createElement("ul", {id: "done-items", className: "list-unstyled"}, React.createElement("li", null, "Some item ", React.createElement("button", {className: "remove-item btn btn-default btn-xs pull-right"}, React.createElement("span", {className: "glyphicon glyphicon-remove"})))))));
    };
    return DoneItem;
}(React.Component));
