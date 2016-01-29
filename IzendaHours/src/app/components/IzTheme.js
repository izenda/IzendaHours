import Colors from 'material-ui/lib/styles/colors';
import ColorManipulator from 'material-ui/lib/utils/color-manipulator';
import Spacing from 'material-ui/lib/styles/spacing';
import zIndex from 'material-ui/lib/styles/zIndex';

module.exports = {
spacing: Spacing,
    zIndex: zIndex,
fontFamily: 'Roboto, sans-serif',
palette: {
    primary1Color: Colors.blue800,
    primary2Color: Colors.lightBlue800,
    primary3Color: Colors.lightBlack,
    accent1Color: Colors.blueGrey600,
    accent2Color: Colors.grey100,
    accent3Color: Colors.grey500,
    textColor: Colors.darkBlack,
    alternateTextColor: Colors.white,
    canvasColor: Colors.grey100,
    borderColor: Colors.grey300,
    disabledColor: ColorManipulator.fade(Colors.darkBlack, 0.3),
    pickerHeaderColor: Colors.blue800,
    }
};