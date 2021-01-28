const DefaultState= {
    loading:false,
    data:[],
    errorMessage:""
}

const LocationListReducer= (state = DefaultState,action)=>{
    switch(action.type){
        case "LOCATIONS_LIST_LOADING":
            return{
                ...state,
                loading: true,
                errorMessage:""
            }
        case "LOCATIONS_LOADED":
            return{
                ...state,
                loading: false,
                data: action.payload,
                errorMessage:""
            }
        case "LOCATIONS Failed to Load":  
            return{
            ...state,
            loading: false,
            errorMessage: "Failed to load LOCATIONS"
        }
        default:
            return state
    }
}

export default LocationListReducer