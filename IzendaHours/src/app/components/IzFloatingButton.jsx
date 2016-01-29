import FloatingActionButton from 'material-ui/lib/floating-action-button';
import ContentAdd from 'material-ui/lib/svg-icons/content/add';

const style = {
  marginRight: 20,
};

const IzFloatingButton = () => (
  <div>
    <FloatingActionButton style={style}>
      <ContentAdd />
    </FloatingActionButton>
  </div>
);

module.exports = IzFloatingButton;
