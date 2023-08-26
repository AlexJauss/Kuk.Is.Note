import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Hello, Kuk.Is!</h1>
        <p>This is my attempt for the coding challange 2022_V02. Since the challenge was about coding I disregarded the visuals. Also I didn't bother to add a confirmation pop-up on the delete button.</p>
        <p>Please enjoy: <Link to="/notes">Notes</Link></p>
        <p>Best Regerds,<br/>Alexander</p>
      </div>
    );
  }
}
