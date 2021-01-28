import axios from 'axios';

export const baseUrl = window.location.origin;
export const GetZoneList = () => async dispatch=>{
    try {

        dispatch({
            type:"ZONE_LIST_LOADING"
        });
        const res = await axios.get(`${baseUrl}/api/zone`);

        dispatch({
            type:"ZONES_LOADED",
            payload:res.data
        });
    }
    catch (e){
        dispatch({
            type:"ZONES Failed to Load"
        });
    }
};

export const GetZoneById = (id) => async dispatch=>{
    try {

        dispatch({
            type:"FETCHING_ZONE"
        });
        const res = await axios.get(`${baseUrl}/api/zone/${id}`);

        console.log(res.data);
        dispatch({
            type:"ZONE_FETCHED",
            payload:res.data
        });
    }
    catch (e){
        dispatch({
            type:"ZONE_FETCH_FAILED"
        });
    }
};