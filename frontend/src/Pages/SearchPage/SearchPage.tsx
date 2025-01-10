import React, { SyntheticEvent, useState } from "react";
import { CompanySearch } from "../../company";
import { searchCompanies } from "../../api";
import Search from "../../Components/Search/Search";
import ListPortfolio from "../../Components/Portfolio/ListPortfolio/ListPortfolio";
import CardList from "../../Components/CardList/CardList";

interface Props {}

function SearchPage({}: Props) {
  // Define state
  const [search, setSearch] = useState<string>("");
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);
  const [portfolioValues, setPortfolioValues] = useState<string[]>([]);

  // Search event Handlers
  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
  };

  // SynthethicEvent -- a general event type
  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    // Call Api
    const result = await searchCompanies(search);

    // Type narrowing
    if (typeof result === "string") {
      setServerError(result);
    } else if (Array.isArray(result.data)) {
      setSearchResult(result.data);
    }
  };

  // Portfolio event handlers
  const onPortfolioCreate = (e: any) => {
    e.preventDefault();
    // Ensure no duplicate add
    const exists = portfolioValues.find((value) => value === e.target[0].value);
    if (exists) return;
    // Add to portfolio
    setPortfolioValues([...portfolioValues, e.target[0].value]);
  };

  const onPortfolioDelete = (e: any) => {
    e.preventDefault();
    setPortfolioValues(
      portfolioValues.filter((value) => value !== e.target[0].value)
    );
  };

  // Return JSX
  return (
    <>
      <Search
        search={search}
        handleSearchChange={handleSearchChange}
        onSearchSubmit={onSearchSubmit}
      />
      <ListPortfolio
        portfolioValues={portfolioValues}
        onPortfolioDelete={onPortfolioDelete}
      />
      <CardList
        searchResults={searchResult}
        onPortfolioCreate={onPortfolioCreate}
      />
      {serverError && <div>unable to connecct to API</div>}
    </>
  );
}

export default SearchPage;
