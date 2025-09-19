import PizzaRowContainer from "./pizza-row.styles";
import { ImageContainer, PizzaDetailsContainer, PizzaImage, ButtonContainer, Button, Counter } from "./pizza-row.styles";
import { addToCart, removeFromCart } from "../../../store/slices/orderSlice.js";
import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";

const PizzaRow = ({ pizza }) => {
    const dispatch = useDispatch();

    const [selectedSize, setSelectedSize] = useState(1);

    const getPriceBySize = () => {
        switch (+selectedSize) {
            case 0:
                return pizza.pizzaPriceSmall;
            case 1:
                return pizza.pizzaPriceMedium;
            case 2:
                return pizza.pizzaPriceLarge;
            default:
                return pizza.pizzaPriceLarge;
        }
    };
    const cartItem = useSelector((state) =>
        state.order.cart.find((c) => c.id === pizza.id && c.size === selectedSize
        )
    );
    const handleAdd = () => {
        dispatch(
            addToCart({
                ...pizza,
                size: selectedSize,
                pizzaPrice: getPriceBySize(),
            })
        );
    };

    const handleRemove = () => {
        dispatch(
            removeFromCart({
                ...pizza,
                size: selectedSize,
            })
        );
    };
    const count = cartItem ? cartItem.count : 0;

    return (
        <PizzaRowContainer key={pizza.id}>
            <ButtonContainer>
                <Button onClick={handleAdd}>Add</Button>
                <Counter>{count}</Counter>
                <Button disabled={count === 0} onClick={handleRemove}>Remove</Button>
            </ButtonContainer>
            <ImageContainer>
                <PizzaImage src={pizza.image} alt="pizza-img" />
            </ImageContainer>
            <PizzaDetailsContainer>
                <p>Name: {pizza.pizzaName}</p>
                <p>Description: {pizza.ingredients}</p>
                <label>
                    Size:{" "}
                    <select
                        value={selectedSize}
                        onChange={(e) => setSelectedSize(e.target.value)}
                    >
                        <option value={0}>Small</option>
                        <option value={1}>Medium</option>
                        <option value={2}>Large</option>
                    </select>
                </label>

                <p>Price: {getPriceBySize().toFixed(2)}</p>
            </PizzaDetailsContainer>
        </PizzaRowContainer>
    );
};

export default PizzaRow;
