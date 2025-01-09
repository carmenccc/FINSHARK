import { SyntheticEvent } from "react";
import { CompanySearch } from "../../company.e";
import AddPortfolio from "../Portfolio/AddPortfolio/AddPortfolio";

// Data type checking
interface Props {
  id: string;
  searchResult: CompanySearch;
  onPortfolioCreate: (e: SyntheticEvent) => void;
}

// Type the function:
//      React.FC<Props> -- defines the type and prop types for the whole function
//                          <Props>is equivalant to Props, it's more official to write both
//      : JSX.Element   -- defines he return types
const Card: React.FC<Props> = ({
  id,
  searchResult,
  onPortfolioCreate,
}: Props): JSX.Element => {
  return (
    <div key={id} id={id} className="card">
      <div className="details">
        <h2>
          {searchResult.name}({searchResult.symbol})
        </h2>
        <p>${searchResult.currency}</p>
      </div>
      <p className="info">
        {searchResult.exchangeShortName} - {searchResult.stockExchange}
      </p>
      <AddPortfolio
        onPortfolioCreate={onPortfolioCreate}
        symbol={searchResult.symbol}
      />
    </div>
  );
};

export default Card;
