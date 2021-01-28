import axios from 'axios';

export const baseUrl = window.location.origin;
export const GetLocationList = () => async dispatch=>{
    try {

        dispatch({
            type:"LOCATIONS_LIST_LOADING"
        });
        const res = await axios.get(`${baseUrl}/api/location`);

        dispatch({
            type:"LOCATIONS_LOADED",
            payload:res.data
        });
    }
    catch (e){
        dispatch({
            type:"LOCATIONS Failed to Load"
        });
    }
};

export const GetLocationById = (id) => async dispatch=>{
    try {

        dispatch({
            type:"FETCHING_LOCATION"
        });
        const res = await axios.get(`${baseUrl}/api/location/${id}`);

        console.log(res.data);
        dispatch({
            type:"LOCATION_FETCHED",
            payload:res.data
        });
    }
    catch (e){
        dispatch({
            type:"LOCATION_FETCH_FAILED"
        });
    }
};