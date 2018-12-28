import React, { Component } from 'react';

export class FetchData extends Component {
    displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };

        fetch('api/SampleData/ReturnProducts')
            .then(response => response.json())
            .then(data => {
                this.setState({ products: data, loading: false });
            });
    }

    static renderForecastsTable(products) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Company</th>
                        <th>Name</th>
                        <th>Location</th>
                        <th>Date Purchased</th>
                        <th>Quantity</th>
                        <th>Type</th>
                        <th>Color</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(product =>
                        <tr key={product.Id}>
                            <td>{product.Company}</td>
                            <td>{product.Name}</td>
                            <td>{product.Location}</td>
                            <td>{product.DatePurchased}</td>
                            <td>{product.Quantity}</td>
                            <td>{product.Type}</td>
                            <td>{product.Color}</td>
                           
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.products);

        return (
            <div>
                <h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}
