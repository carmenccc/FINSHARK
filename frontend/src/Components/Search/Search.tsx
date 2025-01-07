import React, { SyntheticEvent, useState } from "react";

// Define props types
interface Props {
  search: string | undefined;
  handleTextChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  handleClick: (e: SyntheticEvent) => void;
}

const Search: React.FC<Props> = ({
  search,
  handleTextChange,
  handleClick,
}: Props): JSX.Element => {
  return (
    <div>
      <input value={search} onChange={(e) => handleTextChange(e)} />
      <button onClick={(e) => handleClick(e)}>Search</button>
    </div>
  );
};

export default Search;
