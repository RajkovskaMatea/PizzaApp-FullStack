import styled from "styled-components";

export const Container = styled.div`
  padding: 20px;
  max-width: 900px;
  margin: 0 auto;
`;

export const SectionTitle = styled.h2`
  font-size: 1.8rem;
  margin-bottom: 15px;
  color: #333;
`;

export const Card = styled.div`
  border: 1px solid #ccc;
  border-radius: 12px;
  padding: 15px;
  margin-bottom: 20px;
  background: #fafafa;
  box-shadow: 0 4px 8px rgba(0,0,0,0.05);
`;

export const PizzaItem = styled.li`
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 10px;
  font-size: 1rem;
  color: #444;
`;

export const PizzaImage = styled.img`
  width: 50px;
  height: 50px;
  margin-right: 10px;
  border-radius: 6px;
  object-fit: cover;
`;

export const Button = styled.button`
  background: #ff7f50;
  border: none;
  color: white;
  padding: 6px 12px;
  border-radius: 6px;
  cursor: pointer;
  font-weight: bold;
  transition: 0.2s all;
  &:hover {
    background: #ff6347;
  }
`;

export const Total = styled.h3`
  font-size: 1.5rem;
  margin-top: 15px;
`;

export const PaymentOptions = styled.div`
  margin-top: 15px;
  display: flex;
  gap: 20px;
  align-items: center;
`;

export const PaymentLabel = styled.label`
  display: flex;
  align-items: center;
  gap: 8px;
  font-size: 16px;
  cursor: pointer;

  input {
    accent-color: #e63946; /* nice red accent */
    transform: scale(1.2);
  }
`;
