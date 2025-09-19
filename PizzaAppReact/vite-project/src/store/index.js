import { configureStore } from "@reduxjs/toolkit";
import pizzaReducer from "./slices/pizzaSlice.js";
import userReducer from "./slices/userSlice.js";
import orderReducer from "./slices/orderSlice.js";

const store = configureStore({
    reducer: {
        pizza: pizzaReducer,
        user: userReducer,
        order: orderReducer
    },
});

export default store;
