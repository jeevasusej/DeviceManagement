import * as React from 'react';
import { NavLink } from 'react-router-dom';

const Nav = () => (
  <>
    <ul>
      <li>
        <NavLink to="/">Landing</NavLink>
      </li>
      <li>
        <NavLink to="/home">Home</NavLink>
      </li>
      <li>
        <NavLink to="/about">About</NavLink>
      </li>
      <li>
        <NavLink to="/terms">Terms</NavLink>
      </li>
      <li>
        <NavLink to="/broken-link">Broken link</NavLink>
      </li>
      <li>
        <NavLink to="/log-in">Log in</NavLink>
      </li>
      <li>
        <NavLink to="/log-out">Log out</NavLink>
      </li>
    </ul>
  </>
);
export default Nav;
