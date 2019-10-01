import * as React from 'react';
import { connect } from 'react-redux';

import { logIn } from '../../actions/current';
import LogInComponent from '../components/LogIn';

interface Props {
  logInConnect: () => void;
}

const LogIn = ({ logInConnect }: Props) => (
  <>
    <LogInComponent />
    <button onClick={logInConnect}>log me in</button>
  </>
);

const mapDispatchToProps = {
  logInConnect: logIn
};

export default connect(
  null,
  mapDispatchToProps,
)(LogIn);
