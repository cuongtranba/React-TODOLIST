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
    getInitialState: function () {
        return { data: this.props.initialData };
    },
    render: function () {
        return (
          <div className="row">
            <div className="col-md-6 todolist not-done">
              <AddToDo onItemSubmit={this.handleItemSubmit}></AddToDo>
              <MaskAllDone></MaskAllDone>
              <ListItem data={this.state.data}></ListItem>
              <ItemsLeft data={this.state.data.length}></ItemsLeft>
            </div>
            <AlreadyDone></AlreadyDone>
          </div>
      );
    }
});

var ToDoListNotDone = React.createClass({
    render: function () {
        return (
          <div>
            <h1>To Do</h1>
            <AddToDo></AddToDo>
            <MaskAllDone></MaskAllDone>
            <ListItem></ListItem>
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
    render: function () {
        return (
            <button id="checkAll" className="btn btn-success">Mark all as done</button>
    );
    }
});

var ListItem = React.createClass({
    render: function () {
        var items = this.props.data.map(function (item) {
            return (
            <li className="ui-state-default">
              <div className="checkbox">
                <label>
                  <input type="checkbox" id={item.Id} defaultValue />{item.Description}
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

var ItemsLeft = React.createClass({
    render: function () {
        return (
          <div className="todo-footer">
            <strong><span className="count-todos" /></strong>{this.props.data} Items Left
          </div>
      );
    }
});