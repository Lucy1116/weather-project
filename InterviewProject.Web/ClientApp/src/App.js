import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Weather } from './components/Weather';
import { Counter } from './components/Counter';
import { WeatherLocation } from './components/WeatherLocation';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/weather' component={Weather} />
        <Route path='/WeatherLocation' component={WeatherLocation} />
      </Layout>
    );
  }
}
