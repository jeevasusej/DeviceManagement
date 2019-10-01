import * as React from 'react';
import { Route } from 'react-router-dom';

interface Props<P> {
  exact?: boolean;
  path: string;
  component: React.ComponentType<P>;
}

const LoggedOutRoute: React.FC<Props> = ({
  component: Component,
  ...otherProps
}: Props) => (
  <div>
    <header>Logged Out Header</header>
    <Route
      render={() => (
        <>
          <Component {...otherProps} />
        </>
      )}
    />
    <footer>Logged Out Footer</footer>
  </div>
);

export default LoggedOutRoute;
