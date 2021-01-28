import React from  'react';
import { useDispatch, useSelector } from 'react-redux';
import _ from "lodash";
import { GetZoneList } from '../../Actions/ZoneActions';
import {Link} from 'react-router-dom';

const ZoneList = () =>
{
    const dispatch = useDispatch();
    const zones = useSelector(state=> state.ZoneList);
    React.useEffect(()=>
    {
        FetchZones();
    },[])
    const FetchZones = () =>{
        dispatch(GetZoneList());
    }
    const ShowData = ()=>{
        if(!_.isEmpty(zones.data)){
            return (
            <div className={"list-wrapper"}>
                {zones.data.map(item=>{
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
        if(zones.loading){
            return (<p> Loading data....</p>)
        }
        if(zones.errorMessage!==""){
            return (<p>No Data Returned</p>)
        }
    }
    return(
        <div className="zoneListContainer">
            {ShowData()}
        </div>
    )
};
export default ZoneList