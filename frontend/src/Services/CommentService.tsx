import axios from "axios";
import { CommentGet, CommentPost } from "../Models/Comment";
import { handleError } from "../Helpers/ErrorHandler";

const api =
  "https://finshark-api-demo-bnabd7efc5avb6b6.canadacentral-01.azurewebsites.net/api/comment/";

export const commentPostAPI = async (
  title: string,
  content: string,
  symbol: string
) => {
  try {
    const data = await axios.post<CommentPost>(api + `${symbol}`, {
      title: title,
      content: content,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const commentGetAPI = async (symbol: string) => {
  try {
    const data = await axios.get<CommentGet[] | null>(
      api + `?Symbol=${symbol}`
    );
    return data;
  } catch (error) {
    handleError(error);
  }
};
