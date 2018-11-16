import React, { Component } from 'react';
import axios from 'axios';
import $ from 'jquery';

class ChildApp extends Component{
    render(){
     // alert(JSON.stringify(this.props.continents));
      
        return (
          <div>
            <div className="form-group">
    <label>Name:</label>
    <input type="text" onChange={this.props.handleChangeValue} className="form-control" id="name" />
  </div>
  <div className="row">
  <div className="form-group col-sm-6">
    <label for="con">Continent:</label>
  <select id="con" className="form-control" onChange={()=>{this.props.getRequiredCountries();this.props.handleChangeContinentValue()}}>
    <option value="">--Select Continent--</option>
    {this.props.continents}
  </select>
  </div>
  <div className="form-group col-sm-6">
    <label for="cou">Country:</label>
    <select id="cou" className="form-control" onChange={()=>{this.props.getRequiredCities();this.props.handleChangeCountryValue()}}>
    <option value="">--Select Country--</option>
    {this.props.countries}
  </select>
  </div>
  </div>
  <div className="row">
  <div className="form-group col-sm-6">
    <label for="cit">City:</label>
    <select id="cit" className="form-control" onChange={this.props.handleChangeCityValue}>
    <option value="">--Select City--</option>
    {this.props.cities}
  </select>
  </div>
  <div className="checkbox form-group col-sm-6" style={{paddingTop:'38px'}}>
    <label><input type="checkbox" id="rem" onChange={this.props.handleChangeRememberValue} /> Remember me</label>
  </div>
  </div>
  </div>
        )
    }
}

export default ChildApp;