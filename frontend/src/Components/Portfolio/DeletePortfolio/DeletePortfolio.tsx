import React, { SyntheticEvent } from "react";

interface Props {
  portfolioValue: string;
  onPortfolioDelete: (e: SyntheticEvent) => void;
}
const DeletePortfolio = ({ portfolioValue, onPortfolioDelete }: Props) => {
  return (
    <>
      <form onSubmit={onPortfolioDelete}>
        <input readOnly={true} hidden={true} value={portfolioValue} />
        <button type="submit">x</button>
      </form>
    </>
  );
};

export default DeletePortfolio;
