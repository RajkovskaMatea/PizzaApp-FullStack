import http from "./http";

const getAllOrders = async (userId) => {
    return await http.get(`order/${userId}`);
};

const submitOrder = async (order) => {
    await http.post("order", order);
};

export { getAllOrders, submitOrder }