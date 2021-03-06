import React, { Component } from 'react';
//import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-balham.css';
import { Grid } from 'ag-grid-community';
import $ from 'jquery';
import ChildApp from './ChildApp';
class App extends Component {
  constructor(props){
    super();
    this.getRequiredCountries=this.getRequiredCountries.bind(this);
    this.getRequiredCities=this.getRequiredCities.bind(this);
    this.getAllRows=this.getAllRows.bind(this);
    this.handleChangeValue = e => this.setState({namevalue: e.target.value});
    this.handleChangeContinentValue= e => this.setState({continentValue: $('#con').val()});
    this.handleChangeCountryValue=e=>this.setState({countryValue:$('cou').val()});
    this.handleChangeCityValue=e=>this.setState({cityValue:$('#cit').val()});
this.handleChangeRememberValue=e=>this.setState({rememberValue:$('#rem').is(':checked')?true:false});
    this.state={
      //alertit: "Name="+ document.getElementById("name").value
      continents:[],
      countries:[],
      cities:[],
        columnDefs: [
            {headerName: "S. No.", field: "SnoId"},
            {headerName: "Name", field: "Name"},
            {headerName: "Continent", field: "ContinentName"},
            {headerName: "Country", field: "CountryName"},
            {headerName: "City", field: "CityName"},
            {headerName: "Remember", field: "RememberMe", cellRenderer:(params)=>{return `<input type="checkbox" ${params.value ? "checked" : ""} className="tblrem" />`}}

        ],
        rowData: [],
        rowSelection: "single",
        gridId:0,
        namevalue:'',
        continentValue:'',
        countryValue:'',
        cityValue:'',
        rememberValue:false
    }
   // this.getAllRows=this.getAllRows.bind(this);
  }

 
  componentDidMount(){
    axios.post('http://localhost:38808//api/continents')
    .then(response=>{
      this.setState({continents:response.data});
    })

    axios.post('http://localhost:38808//api/showgrid')
    .then(response=>{
      alert(JSON.stringify(response.data));
      this.setState({rowData:response.data});
    })
  }
  shouldComponentUpdate() {
    return true; // Will cause component to never re-render.
}
 // checkCellRendererFun=(param)=>{
//return '<input type="checkbox" />'
 // }

   getAllRows(){
    axios.post('http://localhost:38808//api/showgrid')
    .then(response=>{
      this.setState({rowData:response.data});
      this.setState({gridId:0});
    })
  }
  getRequiredCountries(){
    axios.post('http://localhost:38808//api/countries',{
      continentId:document.getElementById('con').value
    })
    .then(response=>{
      this.setState({countries:response.data});
      var a=this.gridApi.getSelectedRows();
      if(a.length>0){
      $('#cou').val(a[0].cutId);
      }
      this.getRequiredCities();
    })
  }

  getRequiredCities(){
    axios.post('http://localhost:38808//api/cities',{
      countryId:document.getElementById('cou').value
    })
    .then(response=>{
      this.setState({cities:response.data});
      var a=this.gridApi.getSelectedRows();
      if(a.length>0){
      $('#cit').val(a[0].ctyId);
      }
    })
  }



  getDetail(){
    this.setState({gridId:0},function(){
      axios.post('http://localhost:38808//api/details',{
        name:document.getElementById('name').value,
        continentId:document.getElementById('con').value,
        countryId:document.getElementById('cou').value,
        cityId:document.getElementById('cit').value,
        remember:$("#rem").is(':checked')?true:false 
      })
      .then(response=>{
        if(response.data>0){
          alert("Data Saved.");
          this.getAllRows();
          $('#name').val('');
    $('#con').val('');
    $('#cou').val('');
    $('#cit').val('');
    $('#rem').removeProp('checked');
          
        }
        else{
          alert("Data Not Saved.");
        }
      })
    });
    
  }

  updateDetail(){
    //alert($('#hddnid').val());
    
    axios.post('http://localhost:38808//api/updatedetail',{
      id:this.state.gridId,
      name:document.getElementById('name').value,
      continentId:document.getElementById('con').value,
      countryId:document.getElementById('cou').value,
      cityId:document.getElementById('cit').value,
      remember:$("#rem").is(':checked')?true:false 
    })
    .then(response=>{
      if(response.data>0){
        alert("Data Updated.");
        this.getAllRows();
        
        $('#name').val('');
  $('#con').val('');
  $('#cou').val('');
  $('#cit').val('');
  $('#rem').removeProp('checked');
      }
      else{
        alert("Data Not Updated.");
      }
    })
  }


  deleteDetail(){
    axios.post('http://localhost:38808//api/deletedetail',{
      id:this.state.gridId
    })
    .then(response=>{
      if(response.data>0){
        alert("Data Deleted.");
        this.getAllRows();
        $('#name').val('');
  $('#con').val('');
  $('#cou').val('');
  $('#cit').val('');
  $('#rem').removeProp('checked');
      }
      else{
        alert("Data Not Deleted.");
      }
    }).catch(res=>{

      alert(res.data);
    })
  }


  onGridReady(params) {
    this.gridApi = params.api;
  }

  onSelectionChangedFunc(){
    var a=this.gridApi.getSelectedRows();
    //alert(JSON.stringify(a));
      if(a.length>0){
    this.setState({gridId:a[0].Id},function(){
      $('#name').val(a[0].name);
    $('#con').val(a[0].cntId);
    this.getRequiredCountries();
    //alert(a[0].rememberMe);
    a[0].rememberMe?$('#rem').prop('checked','checked'):$('#rem').removeProp('checked');
    });
   
      }

    
  }
  render() {
   // var selectedRows = this.gridApi.getSelectedRows();
   var getButton=null;
   if(this.state.gridId===0){
     getButton=(
<button type="submit" style={{margin:'8px'}} onClick={this.getDetail.bind(this)} className="btn btn-default">Submit</button>
     )
   }
   else{
     getButton=(
       <div>
<button type="submit" style={{margin:'8px 4px'}} onClick={this.updateDetail.bind(this)} className="btn btn-default">Update</button>
<button type="submit" style={{margin:'8px 4px'}} onClick={this.deleteDetail.bind(this)} className="btn btn-default">Delete</button>
</div>
     )
   }
const continents=this.state.continents.map(continent=>{
  return <option key={continent.Id} value={continent.Id}>{continent.Continent_Name}</option>
})

const countries=this.state.countries.map(country=>{
  return <option key={country.Id} value={country.Id}>{country.Country_Name}</option>
})

const cities=this.state.cities.map(city=>{
  return <option key={city.Id} value={city.Id}>{city.City_Name}</option>
})
    return (
      <div className="container">
 <h1 style={{color:'white',backgroundColor:'green',padding:'8px 0'}}>Add Details</h1>
 {/*<div className="form-group">
    <label>Name:</label>
    <input type="text" className="form-control" id="name" />
  </div>*/}
  <ChildApp 
  namevalue={this.state.namevalue}
  continentValue={this.state.continentValue} 
  onChangeTextValue={this.handleChangeValue} 
  continents={continents} 
  countries={countries} 
  cities={cities}
  getRequiredCountries={this.getRequiredCountries}
  getRequiredCities={this.getRequiredCities}
  handleChangeContinentValue={this.handleChangeContinentValue}
  handleChangeCountryValue={this.handleChangeCountryValue}
  handleChangeCityValue={this.handleChangeCityValue}
  handleChangeRememberValue={this.handleChangeRememberValue} ></ChildApp>
  {/*<div className="row">
  <div className="form-group col-sm-6">
    <label for="con">Continent:</label>
  <select id="con" className="form-control" onChange={this.getRequiredCountries.bind(this)}>
    <option value="">--Select Continent--</option>
    {continents}
  </select>
  </div>
  <div className="form-group col-sm-6">
    <label for="cou">Country:</label>
    <select id="cou" className="form-control" onChange={this.getRequiredCities.bind(this)}>
    <option value="">--Select Country--</option>
    {countries}
  </select>
  </div>
  </div>
  <div className="row">
  <div className="form-group col-sm-6">
    <label for="cit">City:</label>
    <select id="cit" className="form-control">
    <option value="">--Select City--</option>
    {cities}
  </select>
  </div>
  <div className="checkbox form-group col-sm-6" style={{paddingTop:'38px'}}>
    <label><input type="checkbox" id="rem" /> Remember me</label>
  </div>
  </div>*/}
  {getButton}
  
  <div 
                  className="ag-theme-balham"
                  style={{ 
	                height: '500px', 
	                width: '1200px' }} 
		            >
                    <AgGridReact
                        columnDefs={this.state.columnDefs}
                        rowData={this.state.rowData}
                        rowSelection={this.state.rowSelection}
                        onSelectionChanged={this.onSelectionChangedFunc.bind(this)}
                        onGridReady={this.onGridReady.bind(this)}>
                    </AgGridReact>
                </div>
 </div>     
    )}
}




export default App;
