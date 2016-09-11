var Actions = require("./actions.js");
class CounterStore extends Reflux.Store {
    constructor() {
        this.listenables = Actions;
    }

    onAddItem() {
        alert("haha");
    }
}