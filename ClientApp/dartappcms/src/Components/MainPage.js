import React from  'react';
import {Switch,Route, Redirect, NavLink } from "react-router-dom";
import ZoneList from './ZoneRelated/ZoneList'
import ZoneDetail from './ZoneRelated/ZoneDetail';
import WelcomePage from './WelcomePage';
import LocationList from './LocationRelated/LocationList'
const MainPage = () => 
{
    return(
        <div className="MainPage">
        <nav>
          <NavLink to={"/zone"}>Zones</NavLink>
          <NavLink to={"/location"}>Locations</NavLink>
          <NavLink to={"/venue"}>Venues</NavLink>
        </nav>
        <Switch>
          <Route path={"/"} exact component={WelcomePage}/>
          <Route path={"/zone"} exact component={ZoneList}/>
          <Route path={"/zone/:zoneId"} exact component={ZoneDetail}/>
          <Route path={"/location"} exact component={LocationList}/>
          <Route path={"/location/:locationId"} exact component={ZoneDetail}/>
          <Redirect to={"/"}/>
        </Switch>
      </div>
    )
};
export default MainPage