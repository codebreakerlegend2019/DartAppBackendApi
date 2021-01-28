import React from  'react';
import { useDispatch, useSelector } from 'react-redux';
import { GetZoneById } from '../../Actions/ZoneActions';
import _ from 'lodash'

const ZoneDetail = (props) =>
{
    const zoneId = props.match.params.zoneId;
    const dispatch = useDispatch();
    const zone = useSelector(state=> state.ZoneDetail);
    React.useEffect(()=>{
        dispatch(GetZoneById(zoneId));
    },[])
    const ShowData = ()=>{
        const zoneData = zone.data[`Z${zoneId}`];
        console.log(zone);
        console.log(zoneData);
        if(!_.isEmpty(zoneData)){
            return (
            <div className={"zoneDetailContainer"}>
                <h1>Selected Zone: {zoneData.name}</h1>
            </div>
            )
        }
        if(zone.loading){
            return (<p> Loading data....</p>)
        }
        if(zone.errorMessage!==""){
            return (<p>No Data Returned</p>)
        }

    }
    return(
        <div>
            {ShowData()}
        </div>
    )
};
export default ZoneDetail