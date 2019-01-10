import React, { Component } from 'react';

export class AddItem extends Component {
    displayName = AddItem.name

    constructor(props) {
        super(props);
        this.state = {
            itemName: '',
            location: 'Adam\'s Room',
            dateBought: '',
            numItems: '1',
            type: '',
            color: '',
            company: '',
            serial: '',
            selectedFile: File

        };

        this.handleInputChange = this.handleInputChange.bind(this);

        this.handleSubmit = this.handleSubmit.bind(this);

    }

    handleSubmit(event) {
       // alert('Name: ' + this.state.itemName + '\n' + 'Location: ' + this.state.location + '\n' + 'Date: ' + this.state.dateBought + '\n' + 'Quantity: ' + this.state.numItems + '\n' + 'Type: ' + this.state.type + '\n' + 'Color: ' + this.state.color + '\n' + 'Company: ' + this.state.company + '\n' + 'Serial: ' + this.state.serial + '\n' + 'File Name: ' + this.state.selectedFile + '\n');
        event.preventDefault();

        const data = new FormData(event.target);

        fetch('api/UploadData/Upload', {
            method: 'POST',
            body: data
        }).then((response) => response.json())
            .then((responseJson) => {
                this.props.history.push("/fetchData");
            });

    }

    

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }
    render() {
        return (
            <div>
                <div class="row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4">
                        <h1>Add a new Item to the database</h1>

                        <p>Fill out the form below to add a new item to the database.</p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4">
                        <form onSubmit={this.handleSubmit}>
                            <div class="form-group">
                                <label for="itemName">Item Name:</label>
                                <input type="text" class="form-control" name="itemName" value={this.state.itemName} onChange={this.handleInputChange}/>
                                
                            </div>
                            
                            <div class="form-group">
                                <label for="location">Item location:</label>
                                <select class="form-control" name="location" value={this.state.location} onChange={this.handleInputChange} >
                                    <option>Adam's Room</option>
                                    <option>Zoe's Room</option>
                                    <option>Master Bedroom</option>
                                    <option>Dining Room</option>
                                    <option>Living Room</option>
                                    <option>Kitchen</option>
                                    <option>First Floor Bathroom</option>
                                    <option>Second Floor Bathroom</option>
                                    <option>Basement</option>
                                    <option>Outside</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label for="dateBought">Date Purchased:</label>
                                <input type="date" class="form-control" name="dateBought" onChange={this.handleInputChange} />
                            </div>
                            <div class="form-group">
                                <label for="numItems">Number of Items:</label>
                                <input type="number" class="form-control" name="numItems" defaultValue={this.state.numItems} onChange={this.handleInputChange} />
                            </div>
                            <div class="form-group">
                                <label for="type">Item Type:</label>
                                <input type="text" class="form-control" name="type" onChange={this.handleInputChange} />
                            </div>
                            <div class="form-group">
                                <label for="color">Color:</label>
                                <input type="text" class="form-control" name="color" onChange={this.handleInputChange} />
                            </div>
                            <div class="form-group">
                                <label for="company">Company:</label>
                                <input type="text" class="form-control" name="company" onChange={this.handleInputChange} />
                            </div>
                            <div class="form-group">
                                <label for="serial">Serial Number:</label>
                                <input type="text" class="form-control" name="serial" onChange={this.handleInputChange} />
                            </div>
                            <div class="form-group">
                                <label for="selectedFile">Item Picture:</label>
                                <input type="file" class="form-control" name="selectedFile" onChange={this.handleInputChange}/>
                            </div>
                            <button type="submit" class="btn btn-default">Submit</button>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}

