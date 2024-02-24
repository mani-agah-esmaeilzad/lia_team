import { BrowserRouter as Router, Routes, Route, Navigate, Outlet } from "react-router-dom";
import LoginPage from "./Component/Login/LoginPage";
import User from "./Component/User/User";
import Home from "./Component/Home/Home";
import PrivateRoute from "./PrivateRoute";
import ResponsiveAppBar from "./Component/Navbar/Navbar";

function App() {
  const isAuthenticated = localStorage.getItem("user") === "true";

  return (
    <Router>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route element={<PrivateRoute isAuthenticated={isAuthenticated} />}>
          <Route element={<ResponsiveAppBar />}>
            <Route path="/user/*" element={<User />} />
            <Route path="/home/*" element={<Home />} />
          </Route>
        </Route>
        <Route path="/" element={<Navigate replace to="/home" />} />
      </Routes>
    </Router>
  );
}

export default App;