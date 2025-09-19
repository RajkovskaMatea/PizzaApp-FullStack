import styled from "styled-components";

export const Caption = styled.h2`
  text-align: center;
  text-transform: uppercase;
  color: #ffffff;
  text-shadow: 1px 1px 4px rgba(0,0,0,0.7);
`;


export const Container = styled.div`
  max-width: 400px;
  max-height: 600px;
  margin: 40px auto;
  padding: 2rem;
  background: url("/pizzas/pizza.jpg") center/cover no-repeat;
  background-color: #fff;
  border-radius: 12px;
  box-shadow: 0px 4px 12px rgba(0, 0, 0, 0.1);
`;

export const ModeSwitch = styled.div`
  display: flex;
  justify-content: space-between;
  margin-bottom: 1.5rem;
`;

export const ModeButton = styled.button`
  flex: 1;
  padding: 0.75rem;
  margin: 0 0.25rem;
  border: none;
  border-radius: 8px;
  font-weight: bold;
  background: ${(props) => (props.$active ? "#4caf50" : "#ccc")};
  color: ${(props) => (props.$active ? "white" : "black")};
  cursor: pointer;
  transition: background 0.3s, color 0.3s;

  &:hover {
  background: ${(props) => (props.$active ? "#45a049" : "#bbb")};
  }
`;

export const Form = styled.form`
  display: flex;
  flex-direction: column;
`;

export const Input = styled.input`
  margin: 0.5rem 0;
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 8px;
  font-size: 1rem;
  transition: border 0.2s;

  &:focus {
    border-color: #4caf50;
    outline: none;
  }
`;

export const SubmitButton = styled.button`
  margin-top: 1rem;
  padding: 0.75rem;
  border: none;
  border-radius: 8px;
  background: ${(props) => (props.$active ? "#ccc" : "#4caf50")};
  color: ${(props) => (props.$active ? "white" : "black")};
  color: black;
  font-weight: bold;
  font-size: 1rem;
  cursor: pointer;
  transition: background 0.3s;

    &:hover {
  background: ${(props) => (props.$active ? "#45a049" : "#bbb")};
  }
`;
