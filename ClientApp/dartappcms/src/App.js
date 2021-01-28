import logo from './logo.svg';
import './App.css';
import {Switch,Route, Redirect, NavLink } from "react-router-dom";
import MainPage from './Components/MainPage';
import ZoneList from './Components/ZoneRelated/ZoneList';
import ZoneDetail from './Components/ZoneRelated/ZoneDetail';

function App() {
  return (
    <div className="App">
      <MainPage/>
    </div>
  );
}

export default App;
