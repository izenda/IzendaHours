var RecordForm = React.createClass({
    getInitialState: function () {
        return { date: '', project: '', task: '', caseno: '', hours: '', wiki: '', notes: '' };
    },
    handleDateChange: function (e) {
        this.setState({ date: e.target.value });
    },
    handleCustomerChange: function (e) {
        this.setState({ project: e.target.value });
    },
    handleTaskChange: function (e) {
        this.setState({ task: e.target.value });
    },
    handleCaseChange: function (e) {
        this.setState({ caseno: e.target.value });
    },
    handleHoursChange: function (e) {
        this.setState({ hours: e.target.value });
    },
    handleWikiChange: function (e) {
        this.setState({ wiki: e.target.value });
    },
    handleNotesChange: function (e) {
        this.setState({ notes: e.target.value });
    },
    handleSubmit: function (e) {
        e.preventDefault();
        var project = this.state.project.trim();
        var task = this.state.task.trim();
        var hours = this.state.hours.trim();
        var caseno = this.state.caseno.trim();
        var wiki = this.state.wiki.trim();
        var notes = this.state.notes.trim();
        var date = this.state.date.trim();
        if (!project || !task || !hours) {
            return;
        }
        
        this.props.onRecordSubmit({ Task1: task, CaseNo: caseno, Project1: project, Hours: hours, WikiLink: wiki, Notes: notes, RecordDate: date });
        this.setState({ date: '', project: '', task: '', caseno: '', hours: '', wiki: '', notes: '' });
    },
    render: function() {
        return (
          <form className="recordForm" onSubmit={this.handleSubmit}>
              <input type="date"
                     value={this.state.date}
                     onChange={this.handleDateChange}
                     ref="date" />
               <input type="text"
                      placeholder="Customer"
                      value={this.state.project}
                      onChange={this.handleCustomerChange}
                      ref="project" />
                <input type="text"
                      placeholder="Task"
                      value={this.state.task}
                      onChange={this.handleTaskChange}
                       ref="task" />
              <input type="text"
                     placeholder="Case Number"
                     value={this.state.caseno}
                     onChange={this.handleCaseChange}
                     ref="caseno" />
              <input type="text"
                     placeholder="Hours"
                     value={this.state.hours}
                     onChange={this.handleHoursChange}
                     ref="hours" />
              <input type="text"
                     placeholder="Wiki Link"
                     value={this.state.wiki}
                     onChange={this.handleWikiChange}
                     ref="wiki" />
              <textarea placeholder="Notes"
                     value={this.state.notes}
                     onChange={this.handleNotesChange}
                        ref="notes" />
               <input type="submit" value="Post" />
          </form>
      );
    }
});

var RecordBox = React.createClass({
    handleRecordSubmit: function (record) {
        var data = new FormData();
        data.append('Task1', record.task);
        data.append('CaseNo', record.caseno);
        data.append('Project1', record.project);
        data.append('Hours', record.hours);
        data.append('WikiLink', record.wiki);
        data.append('Notes', record.notes);
        data.append('RecordDate', record.date);

        var xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                alert(xhr.responseText);
            }
        }
        xhr.send(JSON.stringify(data));
    },
    render: function () {
        return (
      <div className="recordBox">
        <h1>Create a New Record</h1>
          <RecordForm onRecordSubmit={this.handleRecordSubmit} />
      </div>
    );
    }
});