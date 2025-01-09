// Router provid
import { createBrowserRouter } from "react-router";
import HomePage from "../HomePage/HomePage";
import SearchPage from "../SearchPage/SearchPage";
import CompanyPage from "../CompanyPage/CompanyPage";
import App from "../../App";
import CompanyProfile from "../../Components/CompanyProfile/CompanyProfile";
import IncomeStatement from "../../Components/IncomeStatement/IncomeStatement";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "search", element: <SearchPage /> },
      //   :ticker as param
      {
        path: "company/:ticker",
        element: <CompanyPage />,
        children: [
          { path: "company-profile", element: <CompanyProfile /> },
          { path: "income-statement", element: <IncomeStatement /> },
        ],
      },
    ],
  },
]);
