import React from 'react';

function SelectComp(props) {

    let content;
    if(props.list && props.list.length>0){
        content = props.list.map( item =>
            <option key={item.id} value={item.id}>{item.name} -- {item.price}£</option>
            )
    }
    return (
        <select className="form-select" aria-label="Default select example" onChange={(e) => props.update(e.target.value)}>
            <option selected>--Select--</option>
            {
                content
            }
        </select>
    );
}

export default SelectComp;