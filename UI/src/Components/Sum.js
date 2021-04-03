import axios from 'axios';
import React, { useEffect, useState } from 'react';
import SelectComp from './SelectComp';
import AddBrand from './AddBrand';
import AddConf from './AddConf';

function Sum() {
    const brandUrl = process.env.REACT_APP_URL+"/api/brand";
    const confUrl = process.env.REACT_APP_URL+"/api/configuration";
    const cartUrl = process.env.REACT_APP_URL+"/api/cart";

    const[brand, setBrand] = useState({})
    const[conf, setConf] = useState({})
    const[values, setValues] = useState({'brandId':0, 'ramId':0, 'diskId':0, 'colourId':0});

    useEffect(()=>{
        getBrand();
        getConf();
    }, [brandUrl, confUrl])

    const getBrand = async () =>{
        axios.get(brandUrl).then(res =>{
            setBrand(res.data)
        }).catch(err =>{
            alert(err);
        })
    }

    const getConf = async () =>{
        axios.get(confUrl).then(res =>{
            setConf(res.data)
        }).catch(err =>{
            alert(err);
        })
    }

    const postData = async () =>{
        axios.post(cartUrl, values).then(res =>{
            if(res.data.error === true){
                alert('Not added to cart: '+res.data.message)
            } else{
                alert('Added to Cart')
            }
        })
    }
    let confList = conf && conf.length>0 ? conf : "";

    const updateValues = (key, value) =>{
        setValues({...values, [key]:value})
    }

    return (
        <>
        <AddBrand update={()=> getBrand()}/>
        <AddConf update={()=> getConf()}/>
        <div className="container mt-4">
            <div className="row">
                <div className="col-3">
                    <label>Brand</label>
                    <SelectComp list={brand} update={(val) => updateValues('brandId',parseInt(val))}/>
                </div>
                <div className="col-3">
                    <label>Ram</label>
                    <SelectComp list={Object.values(conf).filter(f=>f.type===0)} update={(val) => updateValues('ramId',parseInt(val))}/>
                </div>
                <div className="col-3">
                    <label>Disk</label>
                    <SelectComp list={Object.values(conf).filter(f=>f.type===1)} update={(val) => updateValues('diskId',parseInt(val))}/>
                </div>
                <div className="col-3">
                    <label>Colour</label>
                    <SelectComp list={Object.values(conf).filter(f=>f.type===2)} update={(val) => updateValues('colourId',parseInt(val))}/>
                </div>
                <div className="col-2 m-3">
                    <button className="btn btn-primary" onClick={() => postData()}>Add to Cart</button>
                </div>
            </div>
        </div>
        </>
    );
}

export default Sum;