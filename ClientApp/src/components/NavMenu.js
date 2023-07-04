import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
// import { fab, faFacebookSquare } from '@fortawesome/free-brands-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faUser, faUsers, faHome, faShoppingCart } from '@fortawesome/free-solid-svg-icons'
import './css/NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
          <div className='navbar-left-group d-flex'>
            <NavbarBrand tag={Link} to="/"><img src='https://i.ibb.co/71b6j63/LP-icon-1.png' className='nav-icon' alt='disc-icon-1' title='disc-icon-1'></img>VinylTap</NavbarBrand>
            <div className='row'>
              <div className='col d-flex align-items-end socials'>
                <a href='#'><FontAwesomeIcon icon={['fab', 'fa-twitter']}></FontAwesomeIcon></a>
                <a href='#'><FontAwesomeIcon icon={['fab', 'fa-instagram']}></FontAwesomeIcon></a>
                <a href='#'><FontAwesomeIcon icon={['fab', 'fa-facebook-square']}></FontAwesomeIcon></a>
              </div>
            </div>
          </div>
          <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/"><FontAwesomeIcon icon={faHome}></FontAwesomeIcon>Home</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/counter"><FontAwesomeIcon icon={faUser}></FontAwesomeIcon>Log In</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/fetch-data"><FontAwesomeIcon icon={faUsers}></FontAwesomeIcon>Community</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/shopping-cart"><FontAwesomeIcon icon={faShoppingCart}></FontAwesomeIcon>Shopping Cart (0)</NavLink>
              </NavItem>
            </ul>
          </Collapse>
        </Navbar>
      </header>
    );
  }
}
