import { BrowserRouter as Router, Routes, Route, Navigate, Link } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import PizzaListContainer from "./components/pizza/pizza-list-container";
import Order from "./components/order/order"
import User from "./components/user/user";
import { userActions } from "./store/slices/userSlice";
import { StyledRouterLink, Button } from "./App.styles";


function App() {
  const isAuthenticated = useSelector((state) => state.user.isAuthenticated);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleLogout = () => {
    dispatch(userActions.logout());
    navigate("/user");
  };

  return (
    <>
      <nav>
        {isAuthenticated && (
          <>
            <StyledRouterLink to="/pizza">Pizza Menu</StyledRouterLink>
            <StyledRouterLink to="/order">Orders</StyledRouterLink>
            <Button onClick={handleLogout}>Logout</Button>
          </>
        )}
      </nav>
      <Routes>
        <Route path="/user" element={<User />} />
        <Route path="/pizza" element={isAuthenticated ? <PizzaListContainer /> : <Navigate to="/user" />} />
        <Route path="/order" element={isAuthenticated ? <Order /> : <Navigate to="/user" />} />
        <Route path="*" element={<Navigate to="/user" />} />
      </Routes>
    </>
  );
}

export default App;
