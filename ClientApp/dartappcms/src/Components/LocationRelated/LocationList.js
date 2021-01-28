import React from 'react'
import {GetLocationList} from '../../Actions/LocationActions';
import { useDispatch, useSelector } from 'react-redux';
import _ from "lodash";
import {Link} from 'react-router-dom';

const LocationList = ()=>{
    const dispatcher = useDispatch();
    const locations = useSelector(state=> state.LocationList);
    React.useEffect(()=>
    {
        dispatcher(GetLocationList());
    },[])
    const ShowData = ()=>{
        if(!_.isEmpty(locations.data)){
            return (
            <div className={"list-wrapper"}>
                {locations.data.map(item=>{
                    return(
                        <div className={"zone-item"}
                        key={item.id}>
                            <p>{item.name}</p>
                            <Link to={`/zone/${item.id}`}>View Details</Link>
                        </div>
                    )
                })}
            </div>
            )
        }
        if(locations.loading){
            return (<p> Loading data....</p>)
        }
        if(locations.errorMessage!==""){
            return (<p>No Data Returned</p>)
        }
    }
    return (
        <div className={"zoneListContainer center"}>
            {ShowData()}
        </div>
    )
}

export default LocationList