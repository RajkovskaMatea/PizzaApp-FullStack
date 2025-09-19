import http from "./http";

const getPizzas = async () => {
    return await http.get("pizza");
};

export { getPizzas }