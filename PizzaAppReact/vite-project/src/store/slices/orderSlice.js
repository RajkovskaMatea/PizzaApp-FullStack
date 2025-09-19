import { createSlice } from "@reduxjs/toolkit";
import { getAllOrders, submitOrder } from "../../services/order"

const initialState = {
    cart: [],
    submitedOrders: [],
    paymentMethod: 0
};

const orderSlice = createSlice({
    name: "order",
    initialState,
    reducers: {
        addToCart(state, action) {
            const pizza = action.payload;

            const cartItem = state.cart.find((c) => c.id === pizza.id && c.size === pizza.size);
            if (cartItem) {
                cartItem.count += 1;
            } else {
                state.cart.push({ ...pizza, count: 1 });
            }
        },
        removeFromCart(state, action) {
            const pizza = action.payload;

            const cartItem = state.cart.find((c) => c.id === pizza.id && c.size === pizza.size);
            if (cartItem) {
                cartItem.count -= 1;
                if (cartItem.count === 0) {
                    state.cart = state.cart.filter((c) => c.id !== pizza.id && c.size === pizza.size);
                }
            }
        },
        clearCart(state) {
            state.cart = [];
        },
        setOrderList(state, action) {
            state.submitedOrders = action.payload;
        },
        setCardPayment(state) {
            state.paymentMethod = 1;
        },
        setCashPayment(state) {
            state.paymentMethod = 0;
        },
    },
});

export const { addToCart, removeFromCart, clearCart, setOrderList, setCardPayment, setCashPayment } = orderSlice.actions;
export default orderSlice.reducer;


export const initialLoad = () => async (dispatch, getState) => {
    try {
        const state = getState();
        const userId = state.user.loggedUser.id;
        const response = await getAllOrders(userId);
        dispatch(setOrderList(response.data));
    } catch (err) {
        console.error("Failed to submit order", err);
    }
};

export const submit = () => async (dispatch, getState) => {
    try {
        const state = getState();
        const pizzasForOrder = state.order.cart.map(p => ({
            pizzaId: p.id,
            pizzaSize: +p.size,
            pizzaPrice: p.pizzaPrice,
            count: +p.count
        }));

        const order = {
            userId: state.user.loggedUser.id,
            paymentMethod: state.order.paymentMethod,
            pizzasForOrder
        };

        await submitOrder(order);
        dispatch(clearCart());
        dispatch(initialLoad());
    } catch (err) {
        console.error("Failed to submit order", err);
    }
};
