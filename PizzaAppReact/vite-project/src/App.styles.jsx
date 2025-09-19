import styled from "styled-components";
import { Link } from "react-router-dom";

export const StyledRouterLink = styled(Link)`
  display: inline-block;
  padding: 4px 10px;
  border-radius: 8px;
  background: #c0c0c0ff;
  color: black;
  font-weight: bold;
  text-decoration: none;
  cursor: pointer;
  transition: background 0.3s;

  &:hover {
    background: #dae6daff;
  }
`;
export const Button = styled.button`
  display: inline-block;
  padding: 6px 14px;
  border-radius: 8px;
  background: #c0c0c0ff;
  color: black;
  font-weight: bold;
  text-decoration: none;
  cursor: pointer;
  transition: background 0.3s;
  border: none;

  &:hover {
    background: #dae6daff;
  }
`;