import { createSlice } from "@reduxjs/toolkit";
import { login, register } from "../../services/user"

const initialUserState = {
    isAuthenticated: !!localStorage.getItem("token"),
    token: localStorage.getItem("token") || "",
    form: {
        username: "",
        password: "",
        confirmPassword: "",
        firstName: "",
        lastName: "",
        phoneNumber: "",
        address: "",
    },
    loggedUser: {
        address: "",
        firstName: "",
        id: 0,
        lastName: "",
        password: "",
        phoneNumber: 0,
        token: "",
        username: ""
    }
};

const userSlice = createSlice({
    name: 'user',
    initialState: initialUserState,
    reducers: {
        setIsLoggedIn(state) {
            state.isAuthenticated = true;
        },
        setToken(state, action) {
            state.token = action.payload;
        },
        setUser(state, action) {
            state.loggedUser = {
                id: action.payload.id,
                firstName: action.payload.firstName,
                lastName: action.payload.lastName,
                username: action.payload.username,
                address: action.payload.address,
                phoneNumber: action.payload.phoneNumber,
                token: action.payload.token,
                password: ""
            };
        },
        setUsername(state, action) {
            state.form.username = action.payload;
        },
        setPassword(state, action) {
            state.form.password = action.payload;
        },
        setRegisterForm(state, action) {
            state.form = { ...state.form, ...action.payload };
        },
        logout(state) {
            state.isAuthenticated = false;
            state.token = "";
            localStorage.removeItem("token");
        }
    }
});
export const userActions = userSlice.actions;
export default userSlice.reducer;

export const loginUser = () => async (dispatch, getState) => {
    try {
        const state = getState();


        const { username, password } = state.user.form;
        const loggedUser = await login(username, password);

        if (!!loggedUser.data.token) {

            dispatch(userActions.setIsLoggedIn());
            dispatch(userActions.setToken(loggedUser.data.token));
            dispatch(userActions.setUser(loggedUser.data));
            localStorage.setItem("token", loggedUser.data.token);

        }
        alert(`User logged in. Welcome ${loggedUser.data.firstName} ${loggedUser.data.lastName}`);
    } catch (err) {
        alert("Failed to load log in", err);
    }
};

export const registerUser = () => async (dispatch, getState) => {
    try {
        const state = getState();
        const form = state.user.form;

        await register(form);

        alert("User registered. Go to log in");
    } catch (err) {
        alert("Failed to register", err);
    }
};

