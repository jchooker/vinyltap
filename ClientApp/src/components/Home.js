import React, { Component } from 'react';
import './css/Home.css';

export class Home extends Component {
  static displayName = Home.name;



  render() {
    return (
      <div>
        <h1>Welcome to VinylTap, the hub for buying LPs!</h1> <br />
        <div className='card'>
          <div className='card-header'> 
            <h4>If you simply want to start exploring music, and our LP seller catalogue:</h4>
          </div>
          <div className='card-body'>
            <form>
              <div className='row'>
                <div className='col-9'>
                  <input type="search" placeholder="Explore artists, albums, genres and more!" className='form-control input-img-placeholder'/>
                </div>
                <div className='d-grid col-2'>
                  <button type='submit' className='btn btn-success'>Search</button>
                </div>
              </div>
            </form>
          </div>
        </div>
        <br />
        <ul>
          <li><strong>Find rare LPs that others are selling</strong>. Our community links you to out-of-print vinyl records that might be more 
          abundant in certain geographical areas.</li>
        </ul>
        <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>
      </div>
    );
  }
}
