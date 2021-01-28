import {combineReducers} from "redux";
import LocationListReducer from "./LocationListReducer";
import ZoneDetailReducer from "./ZoneDetailReducer";
import ZoneListReducer from './ZoneListReducer';
const RootReducer = combineReducers(
{
    ZoneList: ZoneListReducer,
    ZoneDetail: ZoneDetailReducer,
    LocationList:LocationListReducer 
});

export default RootReducer;