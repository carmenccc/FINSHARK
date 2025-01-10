// Router provid
import { createBrowserRouter } from "react-router";
import HomePage from "../HomePage/HomePage";
import SearchPage from "../SearchPage/SearchPage";
import CompanyPage from "../CompanyPage/CompanyPage";
import App from "../../App";
import CompanyProfile from "../../Components/CompanyProfile/CompanyProfile";
import IncomeStatement from "../../Components/IncomeStatement/IncomeStatement";
import DesignGuide from "../DesignGuide/DesignGuide";
import BalanceSheet from "../../Components/BalanceSheet/BalanceSheet";
import CashFlowStatement from "../../Components/CashFlowStatement/CashFlowStatement";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "search", element: <SearchPage /> },
      { path: "dg", element: <DesignGuide /> },
      //   :ticker as param
      {
        path: "company/:ticker",
        element: <CompanyPage />,
        children: [
          { path: "company-profile", element: <CompanyProfile /> },
          { path: "income-statement", element: <IncomeStatement /> },
          { path: "balance-sheet", element: <BalanceSheet /> },
          { path: "cash-flow-statement", element: <CashFlowStatement /> },
        ],
      },
    ],
  },
]);
