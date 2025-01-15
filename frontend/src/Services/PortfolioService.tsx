import axios from "axios";
import { PortfolioGet, PortfolioPost } from "../Models/Portfolio";
import { handleError } from "../Helpers/ErrorHandler";

const api =
  "https://finshark-api-demo-bnabd7efc5avb6b6.canadacentral-01.azurewebsites.net/api/portfolio/";

export const portfolioGetAPI = async () => {
  try {
    const data = await axios.get<PortfolioGet[]>(api);
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const portfolioAddAPI = async (symbol: string) => {
  try {
    const data = await axios.post<PortfolioPost>(api + `?symbol=${symbol}`);
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const portfolioDeleteAPI = async (symbol: string) => {
  try {
    const data = await axios.delete<PortfolioPost>(api + `?symbol=${symbol}`);
    return data;
  } catch (error) {
    handleError(error);
  }
};
