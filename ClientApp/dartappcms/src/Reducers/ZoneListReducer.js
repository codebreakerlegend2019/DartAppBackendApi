const DefaultState= {
    loading:false,
    data:[],
    errorMessage:""
}

const ZoneListReducer= (state = DefaultState,action)=>{
    switch(action.type){
        case "ZONE_LIST_LOADING":
            return{
                ...state,
                loading: true,
                errorMessage:""
            }
        case "ZONES_LOADED":
            return{
                ...state,
                loading: false,
                data: action.payload,
                errorMessage:""
            }
        case "ZONES Failed to Load":  
            return{
            ...state,
            loading: false,
            errorMessage: "Failed to load Zones"
        }
        default:
            return state
    }
}

export default ZoneListReducer