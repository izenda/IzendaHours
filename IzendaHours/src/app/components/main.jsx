import IzAppBar from './IzAppBar';
import RaisedButton from 'material-ui/lib/raised-button';
import IzPopover from './IzPopover'
import IzFloatingButton from './IzFloatingButton'
import ThemeManager from 'material-ui/lib/styles/theme-manager';
import IzTheme from './IzTheme';

const IzThemeComponent = React.createClass({

  //the key passed through context must be called "muiTheme"
  childContextTypes : {
    muiTheme: React.PropTypes.object,
  },

  getChildContext() {
    return {
      muiTheme: ThemeManager.getMuiTheme(IzTheme),
    };
  },

  //the app bar and button will receive our theme through
  //context and style accordingly
  render () {
    return (
        <div>
          <IzAppBar title="Izenda Hours" style={{ margin: 0 }} />
            <IzPopover />
        </div>
    );
  },
});

module.exports = IzThemeComponent;
