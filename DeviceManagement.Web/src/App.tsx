import React from 'react';
import './App.css';
import { Router } from 'react-router-dom';
import history from './common/History';
import Nav from './common/Nav';

const App: React.FC = () => (
  <Router history={history}>
    <Nav />
  </Router>
);

export default App;
