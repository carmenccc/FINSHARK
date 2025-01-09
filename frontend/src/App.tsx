import { SyntheticEvent, useState } from "react";
import "./App.css";
import CardList from "./Components/CardList/CardList";
import Search from "./Components/Search/Search";
import { CompanySearch } from "./company.e";
import { searchCompanies } from "./api";
import ListPortfolio from "./Components/Portfolio/ListPortfolio/ListPortfolio";

function App() {
  // Define state
  const [search, setSearch] = useState<string>("");
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);
  const [portfolioValues, setPortfolioValues] = useState<string[]>([]);

  // Event Handlers
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

  const onPortfolioCreate = (e: any) => {
    e.preventDefault();
    // Ensure no duplicate add
    const exists = portfolioValues.find((value) => value === e.target[0].value);
    if (exists) return;
    // Add to portfolio
    setPortfolioValues([...portfolioValues, e.target[0].value]);
  };

  // Return JSX
  return (
    <div className="App">
      <Search
        search={search}
        handleSearchChange={handleSearchChange}
        onSearchSubmit={onSearchSubmit}
      />
      <ListPortfolio portfolioValues={portfolioValues} />
      <CardList
        searchResults={searchResult}
        onPortfolioCreate={onPortfolioCreate}
      />
      {serverError && <div>unable to connecct to API</div>}
    </div>
  );
}

export default App;
