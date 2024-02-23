import logo from "./logo.svg";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
  Outlet,
} from "react-router-dom";
import LoginPage from "./Component/Login/LoginPage";
import User from "./Component/User/User";
import ResponsiveAppBar from "./Component/Navbar/Navbar"; // فرض کردم که این مسیر درست است
import "./App.css";
import Home from "./Component/Home/Home";

function App() {
  return (
    <Router>
      <Routes>
      <Route path="/login" element={<LoginPage />} />
        <Route path="/" element={<ResponsiveAppBar />}>
          <Route index element={<Navigate replace to="/login" />} />
          <Route path="User" element={<User />} />
          <Route path="Home" element={<Home />}/>
        </Route>
      </Routes>
    </Router>
  );
}

export default App;
