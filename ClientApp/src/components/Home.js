import React, { Component, useState } from 'react';
import WelcomeContainer from './WelcomeContainer';
import './css/Home.css';

export class Home extends Component {
  static displayName = Home.name;
  
  render() {
    return (
      <div>
        <WelcomeContainer />
      </div>
    );
  }
}
