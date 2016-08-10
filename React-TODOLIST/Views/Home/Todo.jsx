var ToDoListSkeleton = React.createClass({
    render: function() {
        return (
          <div className="row">
            <div className="col-md-6 todolist not-done">
              <AddToDo></AddToDo>
              <MaskAllDone></MaskAllDone>
              <ListItem></ListItem>
              <ItemsLeft></ItemsLeft>
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
    render: function() {
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
    render: function () {
        return (
      <div>
        <h1>Todos</h1>
        <input type="text" className="form-control add-todo" placeholder="Add todo" />
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
        return (
      <ul id="sortable" className="list-unstyled">
        <li className="ui-state-default">
          <div className="checkbox">
            <label>
              <input type="checkbox" defaultValue />Take out the trash
            </label>
          </div>
        </li>
        <li className="ui-state-default">
          <div className="checkbox">
            <label>
              <input type="checkbox" defaultValue />Buy bread
            </label>
          </div>
        </li>
        <li className="ui-state-default">
          <div className="checkbox">
            <label>
              <input type="checkbox" defaultValue />Teach penguins to fly
            </label>
          </div>
        </li>
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
    render: function() {
        return (
          <div className="todo-footer">
            <strong><span className="count-todos" /></strong> Items Left
          </div>
      );
    }
});