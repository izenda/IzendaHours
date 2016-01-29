import injectTapEventPlugin from 'react-tap-event-plugin';
import IzThemeComponent from './components/main'

//Needed for onTouchTap
//Can go away when react 1.0 release
//Check this repo:
//https://github.com/zilverline/react-tap-event-plugin
injectTapEventPlugin();

var Components = require('expose?Components!./components').default;
ReactDOM.render(<IzThemeComponent />, document.getElementById('app'));
