import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { initialLoad } from "../../store/slices/orderSlice";
import { removeFromCart, clearCart, submit, setCashPayment, setCardPayment } from "../../store/slices/orderSlice";
import { Container, SectionTitle, Card, PizzaItem, PizzaImage, Button, Total, PaymentOptions, PaymentLabel } from "./order.styles";

const Orders = () => {
    const cart = useSelector((state) => state.order.cart);
    const allOrders = useSelector((state) => state.order.submitedOrders);
    const paymentMethod = useSelector((state) => state.order.paymentMethod);
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(initialLoad());
    }, [dispatch]);

    if (cart.length === 0 && allOrders.length === 0) {
        return <p>No pizzas in your order yet.</p>;
    }

    const getPizzaSizeLabel = (size) => {
        switch (+size) {
            case 0:
                return "Small";
            case 1:
                return "Medium";
            case 2:
                return "Large";
            default:
                return "Large";
        }
    };

    const total = cart.reduce((sum, pizza) => sum + pizza.pizzaPrice * pizza.count, 0);

    return (
        <Container>
            <SectionTitle>Your Order</SectionTitle>
            {cart.length === 0 ? (
                <p>No pizzas in your order yet.</p>
            ) : (
                <Card>
                    <ul>
                        {cart.map(pizza => (
                            <PizzaItem key={`${pizza.id}-${pizza.size}`}>
                                <div style={{ display: "flex", alignItems: "center" }}>
                                    <PizzaImage src={pizza.image} alt={pizza.pizzaName} />
                                    {pizza.pizzaName} ({getPizzaSizeLabel(pizza.size)}) x {pizza.count} : {pizza.pizzaPrice.toFixed(2)}€
                                </div>
                                <Button onClick={() => dispatch(removeFromCart(pizza))}>Remove</Button>
                            </PizzaItem>
                        ))}
                    </ul>
                    <Total>Total: {total.toFixed(2)}€</Total>
                    <PaymentOptions>
                        <PaymentLabel>
                            <input
                                type="radio"
                                name="paymentMethod"
                                value={0}
                                checked={paymentMethod === 0}
                                onChange={() => dispatch(setCashPayment())}
                            />
                            Cash
                        </PaymentLabel>
                        <PaymentLabel>
                            <input
                                type="radio"
                                name="paymentMethod"
                                value={1}
                                checked={paymentMethod === 1}
                                onChange={() => dispatch(setCardPayment())}
                            />
                            Card
                        </PaymentLabel>
                    </PaymentOptions>
                    <div style={{ marginTop: "10px" }}>
                        <Button onClick={() => dispatch(clearCart())} style={{ marginRight: "10px" }}>Clear Order</Button>
                        <Button onClick={() => dispatch(submit())}>Submit Order</Button>
                    </div>
                </Card>
            )}

            {allOrders.length > 0 && (
                <div>
                    <SectionTitle>Submitted Orders</SectionTitle>
                    {allOrders.map((order, index) => (
                        <Card key={order.id}>
                            <h4>Order #{index + 1}</h4>
                            <ul>
                                {order.pizzasInOrder.map(pizza => (
                                    <PizzaItem key={`${pizza.id}-${pizza.pizzaSize}`}>
                                        {pizza.pizzaName} ({getPizzaSizeLabel(pizza.pizzaSize)}) x {pizza.count} : {pizza.pizzaPrice.toFixed(2)}€
                                    </PizzaItem>
                                ))}
                            </ul>
                        </Card>
                    ))}
                </div>
            )}
        </Container>
    );
};

export default Orders;