import React, { useEffect, useState } from "react";
import { getTenK } from "../../api";
import Spinner from "../Spinner/Spinner";
import { CompanyTenK } from "../../company";
import TenKFinderItem from "./TenKFinderItem/TenKFinderItem";

type Props = {
  ticker: string;
};

const TenKFinder = ({ ticker }: Props) => {
  const [companyData, setCompanyData] = useState<CompanyTenK[]>();

  useEffect(() => {
    const getTenKData = async () => {
      const result = await getTenK(ticker);
      setCompanyData(result?.data);
    };
    getTenKData();
  }, [ticker]);

  return (
    <div>
      {companyData ? (
        companyData?.slice(0, 5).map((tenK) => {
          return <TenKFinderItem tenK={tenK} />;
        })
      ) : (
        <Spinner />
      )}
    </div>
  );
};

export default TenKFinder;
