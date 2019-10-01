import * as React from 'react';
import { Route } from 'react-router-dom';

interface Props<P> {
  exact?: boolean;
  path: string;
  component: React.ComponentType<P>;
}

const LoggedInRoute: React.FC<Props> = ({
  component: Component,
  ...otherProps
}: Props) => (
  <div>
    <header>Logged In Header</header>
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

export default LoggedInRoute;
