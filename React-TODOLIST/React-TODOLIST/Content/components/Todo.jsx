﻿var Helper = require('./helper.js');
class ToDoListSkeleton extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            doneItem: [],
            expireItems: []
        };
    }

    getDoneItem(data) {
        return data.filter(c=>c.IsActive === false);
    }

    getExpireItems(data) {
        return data.filter(c=>c.IsExpired === true);
    }

    getDataItems(data) {
        return data.filter(c=>c.IsActive && c.IsExpired === false);
    }

    componentWillMount() {
        $.get(this.props.urlGetToDoList,
            function (data) {
                this.setState(
                {
                    data: this.getDataItems(data),
                    doneItem: this.getDoneItem(data),
                    expireItems: this.getExpireItems(data)
                });
            }.bind(this));
    }



    handleItemSubmit(item) {
        var todolist = this.state.data;
        var seft = this;
        $.post(this.props.addTodoUrl, { Description: item },
            function (data) {
                if (data.success) {
                    var newitems = todolist.concat(data.data);
                    seft.setState({ data: newitems });
                }
            });
    }
    handleItemAllDone() {
        var seft = this;
        $.post(this.props.markAllDoneUrl, function (data) {
            if (data.success) {
                var newDoneItems = seft.state.doneItem.concat(seft.state.data);
                seft.setState({ doneItem: newDoneItems, data: [] });
            }
        });
    }
    handleDoneItem(todoId) {
        var itemDone = this.state.data.filter(c=>c.Id === todoId);
        var newData = this.state.data.filter(c=>c.Id !== todoId);
        $.post(this.props.markItemDone, { id: todoId }, function (data) {
            if (data.success) {
                var newDoneItems = this.state.doneItem.concat(itemDone);
                this.setState({ data: newData, doneItem: newDoneItems });
            }
        }.bind(this));
    }
    handleDeleteItem(todoId) {
        $.post(this.props.deleteItemUrl,
            { id: todoId },
            function (data) {
                if (data.success) {
                    this.setState({
                        doneItem: this.state.doneItem.filter(c => c.Id !== todoId), expireItems: this.state.expireItems.filter(c => c.Id !== todoId)
                    });
                }
            }.bind(this));
    }
    render() {
        return (
            <div>
                <div className="row">
                    <div className="col-md-6 todolist not-done">
                      <AddToDo onItemSubmit={this.handleItemSubmit.bind(this)}></AddToDo>
                      <MaskAllDone onItemDoneAll={this.handleItemAllDone.bind(this)}></MaskAllDone>
                      <ListItem onItemDone={this.handleDoneItem.bind(this)} data={this.state.data}></ListItem>
                      <ItemsLeft data={this.state.data.length}></ItemsLeft>
                    </div>
                    <AlreadyDone onItemDelete={this.handleDeleteItem.bind(this)} data={this.state.doneItem}></AlreadyDone>
                </div>
                <div className="col-md-6 todolist row">
                    <h1>Expired Items</h1>
                    <ExpireItem onItemDelete={this.handleDeleteItem.bind(this)} data={this.state.expireItems}></ExpireItem>
                    <ItemsLeft data={this.state.expireItems.length}></ItemsLeft>
                </div>
            </div>

      );
    }
}

class ExpireItem extends React.Component {
    constructor(props) {
        super(props);
    }
    handleDeleteItem(event) {
        this.props.onItemDelete(event.currentTarget.getAttribute("data-id"));
    }
    render() {
        var items = this.props.data.map(function (item) {
            return (
            <li className="ui-state-default">
              <div className="checkbox">
                  {item.Description}
                    <button onClick={this.handleDeleteItem.bind(this)} data-id={item.Id} className="remove-item btn btn-default btn-xs pull-right">
                <span className="glyphicon glyphicon-remove" />
                    </button>
              </div>
            </li>
            );
        }.bind(this));
        return (
            <ul id="sortable" className="list-unstyled">
                {items}
            </ul>
     );
    }
}


class AddToDo extends React.Component {
    constructor(props) {
        super(props);
    }
    handleAddItem(event) {
        event.preventDefault();
        if (Helper.FormValidate(event.target.id)) {
            this.props.onItemSubmit(this.refs.Description.value.trim());
            this.refs.Description.value = "";
        }
        
    }
    render() {
        return (
      <div className="row">
          <form id="add-item-form" onSubmit={this.handleAddItem.bind(this)} role="form" data-toggle="validator">
              <div className="form-group">
                  <h1>Todos</h1>
                    <input type="text" data-minlength="6" data-error="Minimum of 6 characters" required ref="Description" className="form-control add-todo" placeholder="Add todo" />
                      <div className="help-block with-errors"></div>
              </div>
            <button className="btn btn-success" type="submit">Add new item</button>
          </form>
      </div>
    );
    }
}

class MaskAllDone extends React.Component {
    constructor(props) {
        super(props);
    }
    HandleDoneAllItem() {
        this.props.onItemDoneAll();
    }
    render() {
        return (
            <div className="row">
                <button id="checkAll" onClick={this.HandleDoneAllItem
                .bind(this)} className="btn btn-success">
                    Mark all as done
                </button>
            </div>
        );
    }
}

class ListItem extends React.Component {
    constructor(props) {
        super(props);
    }
    handleDoneItem(event) {
        var itemId = event.target.getAttribute('data-id');
        this.props.onItemDone(itemId);
        event.target.checked = false;
    }
    render() {
        var items = this.props.data.map(function (item) {
            return (
            <li key={item.Id} className="ui-state-default">
              <div className="checkbox">
                <label>
                  <input onClick={this.handleDoneItem.bind(this)} type="checkbox" data-id={item.Id} defaultValue />{item.Description}
                </label>
              </div>
            </li>
            );
        }.bind(this));
        return (
            <div className="row">
                <ul id="sortable" className="list-unstyled">
                    {items}
                </ul>
            </div>
    );
    }
}

class AlreadyDone extends React.Component {
    constructor(props) {
        super(props);
    }
    handleDeleteItem(event) {
        this.props.onItemDelete(event.currentTarget.getAttribute("data-id"));
    }
    render() {
        var doneItem = this.props.data.map(function (item) {
            return (
                <li key={item.Id}>
                    {item.Description} <button onClick={this.handleDeleteItem.bind(this)} data-id={item.Id} className="remove-item btn btn-default btn-xs pull-right">
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
              <ItemsLeft data={this.props.data.length}></ItemsLeft>
            </div>
          </div>
  );
    }
}

class ItemsLeft extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
          <div className="row todo-footer">
            <strong><span className="count-todos" /></strong>{this.props.data} Items Left
          </div>
      );
    }
}

ReactDOM.render(
    <ToDoListSkeleton urlGetToDoList="/home/gettodo"
                      addTodoUrl="/home/addtodo"
                      markAllDoneUrl="/home/markalldone"
                      deleteItemUrl="/home/deleteitem"
                      markItemDone="/home/marktododone" />,
  document.getElementById('content')
);
module.exports = ToDoListSkeleton