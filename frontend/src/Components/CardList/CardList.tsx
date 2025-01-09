import React from "react";
import Card from "../Card/Card";
import { CompanySearch } from "../../company.e";
import { v4 as uuidv4 } from "uuid";

interface Props {
  searchResults: CompanySearch[];
}

const CardList: React.FC<Props> = ({ searchResults }: Props): JSX.Element => {
  return (
    <div>
      {searchResults.length > 0 ? (
        searchResults.map((result) => {
          return (
            <Card searchResult={result} id={result.symbol} key={uuidv4()} />
          );
        })
      ) : (
        <h1>No results found</h1>
      )}
    </div>
  );
};

export default CardList;
