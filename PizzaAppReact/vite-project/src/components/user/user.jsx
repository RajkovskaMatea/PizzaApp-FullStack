import { useState } from "react";
import { loginUser, registerUser } from "../../store/slices/userSlice"
import { useDispatch } from "react-redux";
import useForm from "../../custom-hooks/useForm"
import { userActions } from "../../store/slices/userSlice";
import { Container, ModeSwitch, ModeButton, Form, Input, SubmitButton, Caption } from "./user.styles";

const User = () => {
    const [mode, setMode] = useState("login");

    const dispatch = useDispatch();

    const handleUsernameChange = (username) => {
        dispatch(userActions.setUsername(username));
    }

    const handlePasswordChange = (password) => {
        dispatch(userActions.setPassword(password));
    }

    const handleLogin = () => {
        dispatch(loginUser())
    }

    const handleRegister = (formData) => {
        dispatch(userActions.setRegisterForm(formData));
        dispatch(registerUser());
    };

    return (
        <Container>
            <Caption>Pizza App</Caption>
            <ModeSwitch>
                <ModeButton type="button" $active={mode === "login"} onClick={() => setMode("login")}>I have an account</ModeButton>
                <ModeButton type="button" $active={mode === "register"} onClick={() => setMode("register")}>I want to create an account</ModeButton>
            </ModeSwitch>
            {mode === "login" ?
                <LoginForm
                    handleLogin={handleLogin}
                    handleUsernameChange={handleUsernameChange}
                    handlePasswordChange={handlePasswordChange}
                    mode={mode} /> :
                <RegisterForm handleRegister={handleRegister}
                    mode={mode} />
            }
        </Container>
    );
};


const LoginForm = ({ handleLogin, handleUsernameChange, handlePasswordChange, mode }) => (
    <Form onSubmit={(e) => e.preventDefault()}>
        <Input name="username" placeholder="Username" onChange={(e) => handleUsernameChange(e.target.value)} />
        <Input name="password" type="password" placeholder="Password" onChange={(e) => handlePasswordChange(e.target.value)} />
        <SubmitButton type="submit" $active={mode === "login"} onClick={() => handleLogin()}>Login</SubmitButton >
    </Form>
);

const RegisterForm = ({ handleRegister, mode }) => {
    const [formData, handleChange] = useForm({
        username: "",
        password: "",
        confirmPassword: "",
        firstName: "",
        lastName: "",
        phoneNumber: "",
        address: "",
    });

    const submitHandler = (e) => {
        e.preventDefault();
        handleRegister(formData);
    };

    return (
        <Form onSubmit={submitHandler}>
            <Input name="firstName" value={formData.firstName} onChange={handleChange} placeholder="First Name" />
            <Input name="lastName" value={formData.lastName} onChange={handleChange} placeholder="Last Name" />
            <Input name="phoneNumber" value={formData.phoneNumber} onChange={handleChange} placeholder="Phone Number" />
            <Input name="address" value={formData.address} onChange={handleChange} placeholder="Address" />
            <Input name="username" value={formData.username} onChange={handleChange} placeholder="Username" />
            <Input name="password" type="password" value={formData.password} onChange={handleChange} placeholder="Password" />
            <Input name="confirmPassword" type="password" value={formData.confirmPassword} onChange={handleChange} placeholder="Confirm Password" />
            <SubmitButton type="submit" $active={mode === "register"} onClick={submitHandler}>Register</SubmitButton >
        </Form>
    );
};

export default User;
