import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './App.css'
//import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    const currYr = new Date().getFullYear();
    return (
      <Layout>
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
        <p>© {currYr} Joseph Hooker</p>
      </Layout>
    );
  }
}
