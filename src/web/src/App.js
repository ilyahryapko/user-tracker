import './App.css';
import React from 'react'
import {
  BrowserRouter as Router,
  Switch,
  Route,
} from 'react-router-dom';
import Header from './components/Header'
import Home from './components/Home'
import Second from './components/Second';
import Third from './components/Third';
import Logs from './components/Logs';
import LogsAll from './components/LogsAll';

function App() {

  return (
    <div className='App'>
      <Header></Header>
      <div className='main-content'>
        <Router>
          <Switch>

            <Route exact path='/'>
              <Home></Home>
            </Route>

            <Route exact path='/second'>
              <Second></Second>
            </Route>

            <Route exact path='/third'>
              <Third></Third>
            </Route>

            <Route exact path='/logs'>
              <Logs></Logs>
            </Route>

            <Route exact path='/logs/all'>
              <LogsAll></LogsAll>
            </Route>

          </Switch>
        </Router>
      </div>
    </div>
  );
}

export default App;