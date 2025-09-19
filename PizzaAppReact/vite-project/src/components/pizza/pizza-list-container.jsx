import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { initialLoad } from "../../store/slices/pizzaSlice";
import PizzaRow from "./pizza-row/pizza-row";
import { PizzaCaption } from "./pizza-list.styles";

const PizzaListContainer = () => {
    const dispatch = useDispatch();
    const pizzaList = useSelector((state) => state.pizza.pizzaList);

    useEffect(() => {
        dispatch(initialLoad());
    }, [dispatch]);

    return (
        <div>
            <PizzaCaption>Pizza Menu</PizzaCaption>
            {pizzaList.map((pizza) => (
                <PizzaRow key={pizza.id} pizza={pizza} />
            ))}
        </div>
    );
};

export default PizzaListContainer;
