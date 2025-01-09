import React, { SyntheticEvent } from "react";

// Define props types
interface Props {
  search: string | undefined;
  handleSearchChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onSearchSubmit: (e: SyntheticEvent) => void;
}

const Search: React.FC<Props> = ({
  search,
  handleSearchChange,
  onSearchSubmit,
}: Props): JSX.Element => {
  return (
    <div>
      <form onSubmit={onSearchSubmit}>
        <input value={search} onChange={(e) => handleSearchChange(e)} />
        <button type="submit">Search</button>
      </form>
    </div>
  );
};

export default Search;
