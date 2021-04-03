import axios from 'axios';
import React, { useState } from 'react';

function AddBrand(props) {
    const url = process.env.REACT_APP_URL+"/api/brand"
    const[values, setValues] = useState({"name":"", "price":0})

    const postData = () =>{
        axios.post(url, values).then(res =>{
            if(res.data.error === true){
                alert(res.data.message)
            }else{
                alert("Brand added")
                props.update();
            }
        })
    }

    return (
        <div className="border m-4 p-4">
        <div className="row g-3">
            <div className="col-md-4">
                <label className="visually-hidden">Name</label>
                <input type="text" className="form-control" placeholder="Name" onChange={e => setValues({...values, "name":e.target.value})} />
            </div>
            <div className="col-md-4">
                <label className="visually-hidden">Price</label>
                <input type="number" className="form-control" placeholder="Price" onChange={e => setValues({...values, "price":parseFloat(e.target.value)})} />
            </div>
            <div className="col-md-3 offset-md-1">
                <button type="submit" className="btn btn-primary mb-3" onClick={() => postData()} >Add Brand</button>
            </div>
        </div>
        </div>
    );
}

export default AddBrand;