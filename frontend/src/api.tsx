import axios from "axios";
import { CompanySearch } from "./company.e";

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
