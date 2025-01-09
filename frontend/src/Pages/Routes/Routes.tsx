// Router provid
import { createBrowserRouter } from "react-router";
import HomePage from "../HomePage/HomePage";
import SearchPage from "../SearchPage/SearchPage";
import CompanyPage from "../CompanyPage/CompanyPage";
import App from "../../App";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "search", element: <SearchPage /> },
      //   :ticker as param
      { path: "company/:ticker", element: <CompanyPage /> },
    ],
  },
]);
