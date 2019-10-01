import * as React from 'react';
import { Route, Switch, RouteComponentProps } from 'react-router-dom';
import LoggedInRoute from './routes/LoggedInRoute';
import LoggedOutRoute from './routes/LoggedOutRoute';

interface MatchParams {
  id: string;
}

interface Props extends RouteComponentProps<MatchParams> {}

const Home: React.FC = () => <h2>Home</h2>;
const About: React.FC = () => <h2>About</h2>;

const Landing: React.FC = () => (
  <>
    <div>Landing</div>
  </>
);

const NotFound: React.FC = () => (
  <>
    <div>NotFound</div>
  </>
);

const Pages: React.FC = () => (
  <>
    <Switch>
      <LoggedOutRoute path="/" exact component={Landing} />
      <LoggedOutRoute path="/about" exact component={About} />
      <LoggedOutRoute path="/log-in" exact component={LogIn} />
      <LoggedInRoute path="/log-out" exact component={LogOut} />
      <LoggedInRoute path="/home" exact component={Home} />
      <Route component={NotFound} />
    </Switch>
  </>
);

export default Pages;
