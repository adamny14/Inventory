import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
    displayName = Layout.name

    render() {
        return (

            <div class="container-fluid">
                <div class="row">
                    <Col sm={12}>
                        <NavMenu />
                        <br></br>
                    </Col>
                </div>
                
                    <div class="col-sm-12">

                        {this.props.children}

                    </div> 
                    
               
            </div>
        );
    }
}
