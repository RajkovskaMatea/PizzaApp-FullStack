import styled from "styled-components";

const PizzaRowContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
  margin: 15px 0;
  borcer: 1px green solid;
  font-size: 15px;
  font-family: Sans-serif;
`;
export const ImageContainer = styled.div`
  width: 550px;
  height: 300px;
  overflow: hidden;
  border-radius: 5%;
`
export const PizzaImage = styled.img`
  width: 100%;
  height: 100%;
  object-fit: cover;
`
export const PizzaDetailsContainer = styled.div`
  width: 550px;
  background-color: #FFF9C4;
  margin-top: 10px;
  border-radius: 5%;
`
export const ButtonContainer = styled.div`
  display: flex;
  justify-content: space-between;
  width: 80%;
  padding: 1rem;
  
`;
export const Button = styled.button`
  background-color: #FFF9C4;
  border-radius: 10%;
  position: relative; top: 180px;
  width: 100px;
  height: 40px;
`;
export const Counter = styled.div`
  background-color: #FFF9C4;
  width: 80px;
  height: 30px;
  text-align: center;
  border-radius: 10%;
  border: 1px solid;
`;

export default PizzaRowContainer;
