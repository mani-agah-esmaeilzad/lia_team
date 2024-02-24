import { Outlet, Navigate } from "react-router-dom";

function PrivateRoute({ isAuthenticated, children }) {
  return isAuthenticated ? (
    <>
      {children}
      <Outlet />
    </>
  ) : (
    <Navigate replace to="/login" />
  );
}

export default PrivateRoute;