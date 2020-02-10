import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { SearchHistory } from './components/SearchHistory';
import { Search } from './components/Search';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={Search} />
            <Route path='/search' component={Search} />
            <Route path='/history' component={SearchHistory} />
      </Layout>
    );
  }
}
