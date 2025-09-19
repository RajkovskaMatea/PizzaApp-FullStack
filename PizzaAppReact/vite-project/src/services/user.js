import http from "./http";

const login = async (username, password) => {
    const payload = {
        username: username,
        password: password
    };

    return await http.post("User/authenticate", payload);
};

const register = async ({
    firstName,
    lastName,
    username,
    password,
    confirmPassword,
    phoneNumber,
    address
}) => {
    const payload = {
        firstName: firstName,
        lastName: lastName,
        username: username,
        password: password,
        confirmPassword: confirmPassword,
        phoneNumber: phoneNumber,
        address: address
    };

    return await http.post("User/register", payload);
};

export {
    login,
    register
}