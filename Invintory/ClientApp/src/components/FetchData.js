import React, { Component } from 'react';

export class FetchData extends Component {
    displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = { products: [], loading: true };

        fetch('api/SampleData/ReturnProducts',
            {
                method: 'GET',
                headers: {
                    Accept: 'application/json'
                }
            })
            .then(response => response.json())
            .then(json => {
                this.setState({ products: json, loading: false });
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
                        <tr key={product.id}>
                            <td>{product.company}</td>
                            <td>{product.name}</td>
                            <td>{product.location}</td>
                            <td>{product.datePurchased}</td>
                            <td>{product.quantity}</td>
                            <td>{product.type}</td>
                            <td>{product.color}</td>
                           
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
                <h1>All items in the Inventory</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}
