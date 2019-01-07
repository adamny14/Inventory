import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

    render() {
        return (
            <nav class="navbar navbar-inverse navrbar-fixed-top">
                <div class="container-fluid">
                    <Navbar.Header>
                        <Navbar.Brand>
                            <Link to={'/'}>Inventory</Link>
                        </Navbar.Brand>
                        <Navbar.Toggle />
                    </Navbar.Header>
                    <Navbar.Collapse >
                        <Nav>
                            <LinkContainer to={'/'} exact>
                                <NavItem>
                                    <Glyphicon glyph='home' /> Home
              </NavItem>
                            </LinkContainer>
                            <LinkContainer to={'/additem'}>
                                <NavItem>
                                    <Glyphicon glyph='plus' /> Add New Item
              </NavItem>
                            </LinkContainer>
                            <LinkContainer to={'/fetchdata'}>
                                <NavItem>
                                    <Glyphicon glyph='th-list' /> View data
              </NavItem>
                            </LinkContainer>
                            <LinkContainer to={'/search'}>
                                <NavItem>
                                    <Glyphicon glyph='search' /> Search
              </NavItem>
                            </LinkContainer>
                        </Nav>
                    </Navbar.Collapse>
                </div>
            </nav>
    );
  }
}
