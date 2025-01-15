import axios from "axios";
import { UserProfileToken } from "../Models/User";
import { handleError } from "../Helpers/ErrorHandler";

const api = "https://finshark-api-demo-bnabd7efc5avb6b6.canadacentral-01.azurewebsites.net/api/";

export const loginAPI = async (username: string, password: string) => {
  try {
    const data = await axios.post<UserProfileToken>(
      api + "account/login",
      {
        username: username,
        password: password,
      },
      { withCredentials: true }
    );
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const registerAPI = async (
  email: string,
  username: string,
  password: string
) => {
  try {
    const data = await axios.post<UserProfileToken>(api + "account/register", {
      email: email,
      username: username,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};
