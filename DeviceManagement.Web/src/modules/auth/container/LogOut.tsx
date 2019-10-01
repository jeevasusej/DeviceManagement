import * as React from 'react';
import { connect } from 'react-redux';
import LogOutComponent from '../components/Logout';
import { logIn } from '../../actions/current';

interface Props {
  logInConnect: () => void;
}

const LogIn = ({ logInConnect }: Props) => (
  <>
    <LogOutComponent />
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
