import { createSlice } from "@reduxjs/toolkit";
import { getPizzas } from "../../services/pizza"

const initialState = {
    pizzaList: [],
    pizza: null,
};

const pizzaSlice = createSlice({
    name: "pizza",
    initialState,
    reducers: {
        setPizzaList(state, action) {
            state.pizzaList = action.payload;
        },
    },
});

export const pizzaActions = pizzaSlice.actions;
export default pizzaSlice.reducer;


export const initialLoad = () => async (dispatch) => {
    try {
        const response = await getPizzas();
        const imageMap = {
            "BBQ Chicken": "/pizzas/bbqchicken.png",
            "Hawaiian": "/pizzas/hawaiyan.png",
            "Meat Lovers": "/pizzas/meat.png",
            "Neapolitan": "/pizzas/neapolitan.png",
            "Pepperoni": "/pizzas/pepperoni.png",
            "Sicilian": "/pizzas/sicilian.png",
            "Veggie": "/pizzas/veggie.png"
        };
        const pizzasWithImages = response.data
            .filter(pizza => imageMap[pizza.pizzaName])
            .map(pizza => ({ ...pizza, image: imageMap[pizza.pizzaName] }));
        dispatch(pizzaActions.setPizzaList(pizzasWithImages));
    } catch (err) {
        console.error("Failed to load pizzas", err);
    }
};
