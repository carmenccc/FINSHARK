import React, { useEffect, useState } from "react";
import { useOutletContext } from "react-router";
import { CompanyKeyMetrics } from "../../company";
import { getKeyMetrics } from "../../api";
import RatioList from "../RatioList/RatioList";
import Spinner from "../Spinner/Spinner";

type Props = {};

const tableConfig = [
  {
    label: "Market Cap",
    render: (company: CompanyKeyMetrics) => company.marketCapTTM,
    subTitle:
      "Measures the companies ability to pay short term debt obligations",
  },
  {
    label: "Current Ratio",
    render: (company: CompanyKeyMetrics) => company.currentRatioTTM,
    subTitle:
      "A liquidity ratio that measures a company's ability to pay short-term obligations or those due within one year.",
  },
  {
    label: "Return On Equity",
    render: (company: CompanyKeyMetrics) => company.roeTTM,
  },
  {
    label: "Cash Per Share",
    render: (company: CompanyKeyMetrics) => company.cashPerShareTTM,
  },
  {
    label: "Current Ratio",
    render: (company: CompanyKeyMetrics) => company.currentRatioTTM,
  },
  {
    label: "Return On Equity",
    render: (company: CompanyKeyMetrics) => company.roeTTM,
  },
];

function CompanyProfile({}: Props) {
  // returns the parent route
  const ticker = useOutletContext<string>();
  const [companyData, setCompanyData] = useState<CompanyKeyMetrics>();

  useEffect(() => {
    const getCompanyKeyRatios = async () => {
      const value = await getKeyMetrics(ticker);
      setCompanyData(value?.data[0]);
    };

    getCompanyKeyRatios();
  }, []);

  return (
    <>
      {companyData ? (
        <>
          <RatioList config={tableConfig} data={companyData} />
        </>
      ) : (
        <Spinner />
      )}
    </>
  );
}

export default CompanyProfile;
