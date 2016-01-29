
var ItemDetailList = React.createClass({
    render: function() {
        var emptyResults;
        var itemTable = this.props.data.map(function (itemarray) {

            return (
                               
              <ItemArray>
                  
                   <table id="ReactTable">
                    <tbody>
                        <tr >
                        <td id="customer" width="140" align="center" >
                            {itemarray.Project}
                        </td>
                        <td id="notes" width="140" align="center" >
                            {itemarray.Notes}   
                        </td>
                        <td id="hours" width="80" align="right">
                            {itemarray.Hours}
                        </td>
                        </tr>
                    </tbody>
                   </table>
            

            </ItemArray>
           
          );
        });

        if (this.props.data.length == 0) {
            emptyResults = (<div id="noRecords">Nothing recorded today...</div>)
        };

        return (
          <div >
              {itemTable}
              {emptyResults}
          </div>
            );
    }
});

var ItemArray = React.createClass({
    render: function() {       
        return (
          <div>
              {this.props.children}
          </div>
      );
    }
});

var ItemContainer = React.createClass({

    getInitialState: function(){
        return{data: this.props.initialData};
    },

    loadItemsFromServer: function(){
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function() {
            var itemData = JSON.parse(xhr.responseText);

            this.setState({ data: itemData });
        }.bind(this);
        xhr.send();
    },

    componentDidMount: function () {
        window.setInterval(this.loadItemsFromServer, this.props.pollInterval);
    },

    render: function(){
        return(
   
             <ItemDetailList data={this.state.data } />   
           
        );
}
});

