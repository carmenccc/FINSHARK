import axios from "axios";
import { CompanyKeyMetrics, CompanyProfile, CompanySearch } from "./company";

const API_KEY = "Ql8mgRFJzAKbNFtxtTG83MakJ4SRGqvB";
// CONST API_KEY = process.env.REACT_APP_API_KEY;

// Response Type
interface SearchResponse {
  data: CompanySearch[];
}

export const searchCompanies = async (query: string) => {
  try {
    const result = await axios.get<SearchResponse>(
      `https://financialmodelingprep.com/api/v3/search?query=${query}&limit=10&exchange=NASDAQ&apikey=${API_KEY}`
    );
    return result;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.log("error: ", error.message);
      return error.message;
    } else {
      console.log("unexpected error: ", error);
      return "An unexpected error has occured.";
    }
  }
};

export const getCompanyProfile = async (query: string) => {
  try {
    const result = await axios.get<CompanyProfile[]>(
      `https://financialmodelingprep.com/api/v3/profile/${query}?apikey=${API_KEY}`
    );
    return result;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};

export const getKeyMetrics = async (query: string) => {
  try {
    const result = await axios.get<CompanyKeyMetrics[]>(
      `https://financialmodelingprep.com/api/v3/key-metrics-ttm/AAPL?limit=40&apikey=${API_KEY}`
    );
    return result;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};
