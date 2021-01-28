const Default ={
    loading: false,
    data:{},
    errorMessage:""
}
const ZoneDetailReducer= (state = Default,action)=>{
    switch(action.type){
        
        case "FETCHING_ZONE":
            return{
                ...state,
                loading: true,
                errorMessage:""
            }
        case "ZONE_FETCHED":
            return{
                ...state,
                loading: false,
                data: {
                    ...state.data,
                   [`Z${action.payload.id}`]: action.payload
                }
            }
        case "ZONE_FETCH_FAILED":  
            return{
            ...state,
            loading: false,
            errorMessage: "Failed to load Zone"
        }
        
        default:
            return state
            
    }
}

export default ZoneDetailReducer