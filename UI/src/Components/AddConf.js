import axios from 'axios';
import React, { useState } from 'react';

function AddConf(props) {
    const url = process.env.REACT_APP_URL+"/api/configuration"
    const[values, setValues] = useState({"name":"", "price":0, "type":""})

    const postData = () =>{
        axios.post(url, values).then(res =>{
            if(res.data.error === true){
                alert(res.data.message)
            }else{
                alert("Configuration added")
                props.update();
            }
        })
    }

    return (
        <div className="border m-4 p-4">
            <div className="row g-3">
                <div className="col-3">
                    <label className="visually-hidden">Name</label>
                    <input type="text" className="form-control" placeholder="Name" onChange={e => setValues({...values, "name":e.target.value})} />
                </div>
                <div className="col-3">
                    <label className="visually-hidden">Price</label>
                    <input type="number" className="form-control" placeholder="Price" onChange={e => setValues({...values, "price":parseFloat(e.target.value)})} />
                </div>
                <div className="col-3">
                    <select className="form-select" aria-label="Default select example" onChange={e => setValues({...values, "type":parseInt(e.target.value)})}>
                        <option selected>--Select--</option>
                        <option value="0">Ram</option>
                        <option value="1">Disk</option>
                        <option value="2">Colour</option>
                    </select>
                </div>
                <div className="col-3">
                    <button type="submit" className="btn btn-primary mb-3" onClick={() => postData()}>Add Configuration</button>
                </div>
            </div>
        </div>
    );
}

export default AddConf;