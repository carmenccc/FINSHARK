import { SyntheticEvent, useState } from "react";
import "./App.css";
import CardList from "./Components/CardList/CardList";
import Search from "./Components/Search/Search";
import { CompanySearch } from "./company.e";
import { searchCompanies } from "./api";

function App() {
  // Define state
  const [search, setSearch] = useState<string>("");
  const [searchResult, setSearchResult] = useState<CompanySearch[]>();
  const [serverError, setServerError] = useState<string | null>(null);

  const handleTextChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
  };

  // SynthethicEvent -- a general event type
  const handleClick = async (e: SyntheticEvent) => {
    // Call Api
    const result = await searchCompanies(search);

    // Type narrowing
    if (typeof result === "string") {
      setServerError(result);
    } else if (Array.isArray(result.data)) {
      setSearchResult(result.data);
    }
  };

  return (
    <div className="App">
      <Search
        search={search}
        handleTextChange={handleTextChange}
        handleClick={handleClick}
      />
      {serverError && <div>unable to connecct to API</div>}
      <CardList />
    </div>
  );
}

export default App;
