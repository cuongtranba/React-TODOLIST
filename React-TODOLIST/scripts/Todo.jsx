var ToDoListSkeleton = React.createClass({
    handleItemSubmit: function (item) {
        var todolist = this.state.data;
        var seft = this;
        $.post(this.props.addTodoUrl, { Description: item },
            function (data) {
                if (data.success) {
                    var newitems = todolist.concat(data.data);
                    seft.setState({ data: newitems });
                }
            });
    },

    handleItemAllDone: function () {
        var seft = this;
        $.post(this.props.markAllDoneUrl, function (data) {
            if (data.success) {
                var newDoneItems = seft.state.doneItem.concat(seft.state.data)
                seft.setState({ doneItem: newDoneItems, data: [] });
            }
        });
    },

    handleDoneItem: function (todoId) {
        var itemDone = this.state.data.filter(c=>c.Id == todoId);
        var newData = this.state.data.filter(c=>c.Id !== todoId);
        $.post(this.props.markItemDone, { id: todoId }, function (data) {
            if (data.success) {
                var newDoneItems = this.state.doneItem.concat(itemDone);
                this.setState({ data: newData, doneItem: newDoneItems });
            }
        }.bind(this));
    },

    handleDeleteItem: function (todoId) {
        $.post(this.props.deleteItemUrl, { id: todoId }, function (data) {
            if (data.success) {
                this.setState({ doneItem: this.state.doneItem.filter(c=>c.Id != todoId) });
            }
        }.bind(this))
    },

    getInitialState: function () {
        return {
            data: this.props.initialData.filter(c=>c.IsActive),
            doneItem: this.props.initialData.filter(c=>c.IsActive == false)
        };
    },
    render: function () {
        return (
          <div className="row">
            <div className="col-md-6 todolist not-done">
              <AddToDo onItemSubmit={this.handleItemSubmit}></AddToDo>
              <MaskAllDone onItemDoneAll={this.handleItemAllDone}></MaskAllDone>
              <ListItem onItemDone={this.handleDoneItem} data={this.state.data}></ListItem>
              <ItemsLeft data={this.state.data.length}></ItemsLeft>
            </div>
            <AlreadyDone onItemDelete={this.handleDeleteItem} data={this.state.doneItem}></AlreadyDone>
          </div>
      );
    }
});


var DoneItem = React.createClass({
    render: function () {
        return (
          <div className="col-md-6">
            <div className="todolist">
              <h1>Already Done</h1>
              <ul id="done-items" className="list-unstyled">
                <li>Some item <button className="remove-item btn btn-default btn-xs pull-right"><span className="glyphicon glyphicon-remove" /></button></li>
              </ul>
            </div>
          </div>
      );
    }
});


var AddToDo = React.createClass({
    handleAddItem: function (event) {
        if (event.key === "Enter") {
            this.props.onItemSubmit(this.refs.Description.value.trim());
            this.refs.Description.value = "";
        }
    },
    render: function () {
        return (
      <div>
        <h1>Todos</h1>
        <input type="text" ref="Description" onKeyPress={this.handleAddItem} className="form-control add-todo" placeholder="Add todo" />
      </div>
    );
    }
});

var MaskAllDone = React.createClass({
    HandleDoneAllItem: function () {
        this.props.onItemDoneAll();
    },
    render: function () {
        return (
            <button id="checkAll" onClick={this.HandleDoneAllItem} className="btn btn-success">Mark all as done</button>
    );
    }
});

var ListItem = React.createClass({
    handleDoneItem: function (event) {
        var itemId = event.target.getAttribute('data-id');
        this.props.onItemDone(itemId);
        event.target.checked = false;
    },
    render: function () {
        var seft = this;
        var items = this.props.data.map(function (item) {
            return (
            <li className="ui-state-default">
              <div className="checkbox">
                <label>
                  <input onClick={seft.handleDoneItem} type="checkbox" data-id={item.Id} defaultValue />{item.Description}
                </label>
              </div>
            </li>
            );
        });
        return (
      <ul id="sortable" className="list-unstyled">
          {items}
      </ul>
    );
    }
});


var AlreadyDone = React.createClass({
    handleDeleteItem: function (event) {
        console.log(event)
        this.props.onItemDelete(event.currentTarget.getAttribute("data-id"))
    },
    render: function () {
        var doneItem = this.props.data.map(function (item) {
            return (
                <li>
                    {item.Description} <button onClick={this.handleDeleteItem} data-id={item.Id} className="remove-item btn btn-default btn-xs pull-right">
                <span className="glyphicon glyphicon-remove" />
                    </button>
                </li>
            );
        }.bind(this));
        return (
          <div className="col-md-6">
            <div className="todolist">
              <h1>Already Done</h1>
              <ul id="done-items" className="list-unstyled">
                  {doneItem}
              </ul>
            </div>
          </div>
      );
    }
});

var ItemsLeft = React.createClass({
    render: function () {
        return (
          <div className="todo-footer">
            <strong><span className="count-todos" /></strong>{this.props.data} Items Left
          </div>
      );
    }
});